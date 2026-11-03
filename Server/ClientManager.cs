using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace allyoucaneat
{
    // Gestisce UN tablet connesso. Viene eseguito in un thread dedicato.
    //
    // Responsabilita':
    //  - leggere messaggi JSON terminati da '\n' (framing su linea)
    //  - dispatchare il comando al handler giusto
    //  - inviare risposte al tablet (invio completo, byte per byte se necessario)
    //  - validare l'ordine lato server (piatti esistenti e disponibili)
    //  - chiudere in modo idempotente e notificare il Server.
    public class ClientManager
    {
        // Protezione: un singolo messaggio non puo' superare 1 MB.
        private const int MaxLunghezzaRiga = 1000000;
        // Timeout di ricezione: client inattivo per troppo tempo viene disconnesso.
        private const int TimeoutRicezioneMs = 600000; // 10 minuti

        private readonly Socket _socket;
        private readonly Server _server;
        private readonly byte[] _buffer = new byte[4096];
        private readonly char[] _chars = new char[Encoding.UTF8.GetMaxCharCount(4096)];
        private readonly Decoder _decoder = Encoding.UTF8.GetDecoder();
        private readonly object _lockInvio = new object();

        private string _pending = "";
        private int _tavolo = -1;
        private int _chiuso = 0;

        public int Tavolo { get { return _tavolo; } }

        public ClientManager(Socket socket, Server server)
        {
            _socket = socket;
            _server = server;

            // NoDelay: i messaggi del protocollo vanno inviati subito, senza buffering di Nagle.
            try { _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, 1); } catch { }
            // Timeout: evita che un tablet "morto" blocchi il thread per sempre.
            try { _socket.ReceiveTimeout = TimeoutRicezioneMs; } catch { }
            try { _socket.SendTimeout = 10000; } catch { }
        }

        // Metodo eseguito dal thread del client.
        public void DoClient()
        {
            try
            {
                string riga;
                while ((riga = LeggiRiga()) != null)
                {
                    if (riga.Length == 0)
                        continue;

                    Message m;
                    try
                    {
                        m = Message.FromJson(riga);
                    }
                    catch (JsonException)
                    {
                        Invia(Message.Crea(Comandi.Error, "JSON non valido"));
                        continue;
                    }

                    if (m == null || string.IsNullOrEmpty(m.CommandName))
                    {
                        Invia(Message.Crea(Comandi.Error, "Messaggio vuoto"));
                        continue;
                    }

                    if (!Gestisci(m))
                        break; // "quit": il client ha chiesto di chiudere
                }
            }
            catch (SocketException) { } // connessione interrotta o timeout
            catch (ObjectDisposedException) { } // socket gia' chiusa
            catch (InvalidDataException) { } // messaggio troppo lungo
            finally
            {
                Chiudi();
            }
        }

        // Ritorna false se il client ha chiesto di chiudere ("quit").
        private bool Gestisci(Message m)
        {
            switch (m.CommandName)
            {
                case Comandi.Hello:
                    GestisciHello(m);
                    return true;

                case Comandi.GetMenu:
                    if (!TavoloRegistrato()) return true;
                    string jsonMenu = JsonConvert.SerializeObject(_server.GetMenu());
                    Invia(Message.Crea(Comandi.Menu, jsonMenu));
                    return true;

                case Comandi.NewOrder:
                    if (!TavoloRegistrato()) return true;
                    GestisciNuovoOrdine(m);
                    return true;

                case Comandi.Quit:
                    return false;

                default:
                    Invia(Message.Crea(Comandi.Error, "Comando sconosciuto: " + m.CommandName));
                    return true;
            }
        }

        private void GestisciHello(Message m)
        {
            int tavolo;
            if (!int.TryParse(m.Parametro(0), out tavolo) || tavolo <= 0)
            {
                Invia(Message.Crea(Comandi.Error, "Numero di tavolo non valido"));
                return;
            }

            _tavolo = tavolo;
            _server.RegistraTavolo(tavolo, this);
            Invia(Message.Crea(Comandi.Hello, "ok"));
        }

        private void GestisciNuovoOrdine(Message m)
        {
            string json = m.Parametro(0);
            Ordine ordine;
            try
            {
                ordine = string.IsNullOrEmpty(json) ? null : JsonConvert.DeserializeObject<Ordine>(json);
            }
            catch (JsonException)
            {
                Invia(Message.Crea(Comandi.Error, "Ordine non valido"));
                return;
            }

            if (ordine == null || ordine.Righe == null || ordine.Righe.Count == 0)
            {
                Invia(Message.Crea(Comandi.Error, "Ordine vuoto"));
                return;
            }

            // Validazione lato server: ogni riga deve referenziare un piatto esistente e disponibile.
            var menu = _server.GetMenu();
            foreach (RigaOrdine r in ordine.Righe)
            {
                if (r == null || r.Quantita <= 0)
                {
                    Invia(Message.Crea(Comandi.Error, "Quantita non valida"));
                    return;
                }

                Piatto p = menu.FirstOrDefault(pi => pi.Id == r.PiattoId);
                if (p == null)
                {
                    Invia(Message.Crea(Comandi.Error, "Piatto non trovato: id " + r.PiattoId));
                    return;
                }
                if (!p.Disponibile)
                {
                    Invia(Message.Crea(Comandi.Error, "Piatto non disponibile: " + p.Nome));
                    return;
                }
                // NomePiatto e' scritto dal server per coerenza con il menu.
                r.NomePiatto = p.Nome;
            }

            // I dati importanti li decide il server, non il client.
            ordine.Id = Guid.NewGuid().ToString();
            ordine.Tavolo = _tavolo;
            ordine.Ora = DateTime.Now;
            ordine.Stato = StatoOrdine.Inviato;

            _server.RiceviOrdine(ordine);
            Invia(Message.Crea(Comandi.OrderReceived, ordine.Id));
        }

        private bool TavoloRegistrato()
        {
            if (_tavolo > 0)
                return true;
            Invia(Message.Crea(Comandi.Error, "Invia prima il comando hello con il numero di tavolo"));
            return false;
        }

        // Legge una riga completa (fino a '\n'). Ritorna null se il client si e' disconnesso.
        // _pending conserva i caratteri gia' ricevuti, quindi piu' messaggi arrivati insieme non si perdono.
        private string LeggiRiga()
        {
            while (true)
            {
                int idx = _pending.IndexOf('\n');
                if (idx >= 0)
                {
                    string riga = _pending.Substring(0, idx).TrimEnd('\r');
                    _pending = _pending.Substring(idx + 1);
                    return riga;
                }

                if (_pending.Length > MaxLunghezzaRiga)
                    throw new InvalidDataException("Messaggio troppo lungo");

                int n = _socket.Receive(_buffer);
                if (n == 0)
                    return null;

                int nc = _decoder.GetChars(_buffer, 0, n, _chars, 0);
                _pending += new string(_chars, 0, nc);
            }
        }

        // Invia un messaggio al tablet. Garantisce l'invio completo di tutti i byte
        // (Socket.Send puo' restituire meno di quanto richiesto). Thread-safe.
        // Ritorna false se il client e' gia' chiuso o l'invio fallisce.
        public bool Invia(Message m)
        {
            if (System.Threading.Interlocked.CompareExchange(ref _chiuso, 0, 0) != 0)
                return false;

            try
            {
                byte[] dati = Encoding.UTF8.GetBytes(m.ToJson() + "\n");
                int inviati = 0;
                lock (_lockInvio)
                {
                    if (_chiuso != 0)
                        return false;

                    while (inviati < dati.Length)
                    {
                        int n = _socket.Send(dati, inviati, dati.Length - inviati, SocketFlags.None);
                        if (n <= 0)
                            return false;
                        inviati += n;
                    }
                }
                return true;
            }
            catch (SocketException) { return false; }
            catch (ObjectDisposedException) { return false; }
        }

        // Puo' essere chiamato da qualsiasi thread (es. dal server quando il cuoco preme "Pronto").
        public void Chiudi()
        {
            if (System.Threading.Interlocked.Exchange(ref _chiuso, 1) == 1)
                return; // gia' chiuso

            try { _socket.Shutdown(SocketShutdown.Both); } catch { }
            try { _socket.Close(); } catch { }

            try { _server.ClientChiuso(this); } catch { }
        }
    }
}

