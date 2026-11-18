using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace allyoucaneat
{
    // Gestisce UN tablet connesso. DoClient gira in un thread dedicato (uno per client).
    // Sul socket viaggiano righe di JSON terminate da '\n' (UTF-8): StreamReader/StreamWriter
    // leggono e scrivono una riga alla volta sopra lo stesso socket.
    public class ClientManager
    {
        private readonly Socket _socket;
        private readonly Server _server;
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        private readonly object _lockInvio = new object();
        private readonly object _lockChiusura = new object();
        private bool _chiuso;

        public int Tavolo { get; set; }   // 0 = non ancora assegnato (lo imposta il Server)

        public ClientManager(Socket socket, Server server)
        {
            _socket = socket;
            _server = server;

            NetworkStream stream = new NetworkStream(socket);
            _reader = new StreamReader(stream, Encoding.UTF8);
            _writer = new StreamWriter(stream, new UTF8Encoding(false)); // false = senza BOM
            _writer.NewLine = "\n";
            _writer.AutoFlush = true;
        }

        // Eseguito dal thread del client: legge un messaggio alla volta fino alla disconnessione.
        public void DoClient()
        {
            try
            {
                string riga;
                while ((riga = _reader.ReadLine()) != null)
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

                    if (m.CommandName == Comandi.Quit)
                        break;

                    Gestisci(m);
                }
            }
            catch (IOException) { }                  // connessione interrotta o chiusa
            catch (ObjectDisposedException) { }
            finally
            {
                Chiudi();
            }
        }

        private void Gestisci(Message m)
        {
            // Menu e ordini si possono chiedere solo dopo "hello" (quando il tavolo e' assegnato).
            bool serveTavolo = m.CommandName == Comandi.GetMenu || m.CommandName == Comandi.NewOrder;
            if (serveTavolo && Tavolo == 0)
            {
                Invia(Message.Crea(Comandi.Error, "Invia prima il comando hello con il numero di tavolo"));
                return;
            }

            switch (m.CommandName)
            {
                case Comandi.Hello:
                    if (Tavolo == 0)
                        _server.AssegnaTavolo(this);
                    Invia(Message.Crea(Comandi.Hello, Tavolo.ToString()));
                    break;

                case Comandi.GetMenu:
                    Invia(Message.Crea(Comandi.Menu, JsonConvert.SerializeObject(_server.Menu)));
                    break;

                case Comandi.NewOrder:
                    GestisciNuovoOrdine(m);
                    break;

                default:
                    Invia(Message.Crea(Comandi.Error, "Comando sconosciuto: " + m.CommandName));
                    break;
            }
        }

        private void GestisciNuovoOrdine(Message m)
        {
            string json = m.Parametro(0);
            Ordine ordine = null;
            try
            {
                if (!string.IsNullOrEmpty(json))
                    ordine = JsonConvert.DeserializeObject<Ordine>(json);
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

            if (ordine.Righe.Any(r => r == null || r.Quantita <= 0))
            {
                Invia(Message.Crea(Comandi.Error, "Quantita non valida"));
                return;
            }

            // I dati importanti li decide il server, non il tablet.
            ordine.Id = Guid.NewGuid().ToString();
            ordine.Tavolo = Tavolo;
            ordine.Ora = DateTime.Now;
            ordine.Stato = StatoOrdine.Inviato;

            _server.RiceviOrdine(ordine);
            Invia(Message.Crea(Comandi.OrderReceived, ordine.Id));
        }

        // Puo' essere chiamato da qualsiasi thread (es. dal server quando il cuoco cambia lo stato).
        public void Invia(Message m)
        {
            try
            {
                lock (_lockInvio)
                {
                    _writer.WriteLine(m.ToJson());
                }
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }
        }

        public void Chiudi()
        {
            lock (_lockChiusura)
            {
                if (_chiuso)
                    return;   // gia' chiuso
                _chiuso = true;
            }

            try { _socket.Shutdown(SocketShutdown.Both); } catch { }
            _socket.Close();

            _server.ClientChiuso(this);
        }
    }
}
