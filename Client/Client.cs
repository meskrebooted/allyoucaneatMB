using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace Client
{
    // Parte di rete del tablet. Gli eventi partono dal thread di ascolto:
    // la form deve usare BeginInvoke per toccare i controlli.
    // Sul socket viaggiano righe di JSON terminate da '\n' (UTF-8): StreamReader/StreamWriter
    // leggono e scrivono una riga alla volta sopra lo stesso socket.
    public class Client
    {
        private Socket _socket;
        private StreamReader _reader;
        private StreamWriter _writer;
        private readonly object _lockInvio = new object();
        private readonly object _lockChiusura = new object();
        private volatile bool _connesso;

        public event Action<Message> MessaggioRicevuto;
        public event Action Disconnesso;

        public bool Connesso { get { return _connesso; } }

        public void Connetti(string ip, int porta)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // Connessione con timeout di 3 secondi
                IAsyncResult ar = s.BeginConnect(IPAddress.Parse(ip), porta, null, null);
                if (!ar.AsyncWaitHandle.WaitOne(3000))
                    throw new TimeoutException("Il server non risponde");
                s.EndConnect(ar);
            }
            catch
            {
                s.Close();
                throw; // la form mostra l'errore
            }

            _socket = s;
            NetworkStream stream = new NetworkStream(s);
            _reader = new StreamReader(stream, Encoding.UTF8);
            _writer = new StreamWriter(stream, new UTF8Encoding(false)); // false = senza BOM
            _writer.NewLine = "\n";
            _writer.AutoFlush = true;
            _connesso = true;

            Thread t = new Thread(Ascolta);
            t.IsBackground = true;
            t.Start();

            Invia(Message.Crea(Comandi.Hello)); // il server risponde con il tavolo assegnato
        }

        public bool Invia(Message m)
        {
            if (!_connesso)
                return false;

            try
            {
                lock (_lockInvio)
                {
                    _writer.WriteLine(m.ToJson());
                }
                return true;
            }
            catch (IOException) { return false; }
            catch (ObjectDisposedException) { return false; }
        }

        public void Disconnetti()
        {
            Invia(Message.Crea(Comandi.Quit));
            Chiudi();
        }

        // Thread di ascolto: legge un messaggio alla volta finche' la connessione resta aperta.
        private void Ascolta()
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
                        continue; // riga non valida: la ignoro
                    }

                    if (m != null)
                        MessaggioRicevuto?.Invoke(m);
                }
            }
            catch (IOException) { }                  // connessione interrotta o chiusa
            catch (ObjectDisposedException) { }
            finally
            {
                Chiudi();
            }
        }

        private void Chiudi()
        {
            lock (_lockChiusura)
            {
                if (!_connesso)
                    return;   // gia' chiuso
                _connesso = false;
            }

            try { _socket.Shutdown(SocketShutdown.Both); } catch { }
            _socket.Close();

            Disconnesso?.Invoke();
        }
    }
}
