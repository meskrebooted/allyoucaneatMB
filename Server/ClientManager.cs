using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace allyoucaneat
{
    // Gestisce UN tablet connesso. Viene eseguito in un thread dedicato (come nello scheletro).
    public class ClientManager
    {
        private const int MaxLunghezzaRiga = 1000000; // protezione: 1 milione di caratteri

        private readonly Socket _socket;
        private readonly Server _server;
        private readonly byte[] _buffer = new byte[4096];
        private readonly char[] _chars;
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
            _chars = new char[Encoding.UTF8.GetMaxCharCount(_buffer.Length)];
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
                        break; // "quit"
                }
            }
            catch (SocketException) { }
            catch (ObjectDisposedException) { }
            catch (InvalidDataException) { }
            finally
            {
                Chiudi();
            }
        }

        // Ritorna false se il client ha chiesto di chiudere.
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

            foreach (RigaOrdine r in ordine.Righe)
            {
                if (r == null || r.Quantita <= 0)
                {
                    Invia(Message.Crea(Comandi.Error, "Quantita non valida"));
                    return;
                }
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

        // Puo' essere chiamato da qualsiasi thread (es. dal server quando il cuoco preme "Pronto").
        public bool Invia(Message m)
        {
            if (_chiuso != 0)
                return false;

            try
            {
                byte[] dati = Encoding.UTF8.GetBytes(m.ToJson() + "\n");
                lock (_lockInvio)
                {
                    _socket.Send(dati);
                }
                return true;
            }
            catch (SocketException) { return false; }
            catch (ObjectDisposedException) { return false; }
        }

        public void Chiudi()
        {
            if (Interlocked.Exchange(ref _chiuso, 1) == 1)
                return; // gia' chiuso

            try { _socket.Shutdown(SocketShutdown.Both); } catch { }
            try { _socket.Close(); } catch { }

            _server.ClientChiuso(this);
        }
    }
}
