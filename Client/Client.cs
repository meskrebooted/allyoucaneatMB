using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using allyoucaneat;
using Newtonsoft.Json;

namespace Client
{
    // Logica di rete del tablet. Gli eventi arrivano dal thread di ascolto:
    // la form deve usare Invoke/BeginInvoke per toccare i controlli.
    public class Client
    {
        private Socket _socket;
        private readonly object _lockInvio = new object();
        private int _chiuso = 1; // 1 = non connesso

        public event Action<Message> MessaggioRicevuto;
        public event Action Disconnesso;

        public bool Connesso { get { return _chiuso == 0; } }

        public void Connetti(string ip, int porta, int tavolo)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
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
            _chiuso = 0;

            Thread t = new Thread(Ascolta);
            t.IsBackground = true;
            t.Start();

            Invia(Message.Crea(Comandi.Hello, tavolo.ToString()));
        }

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

        public void Disconnetti()
        {
            Invia(Message.Crea(Comandi.Quit));
            Chiudi();
        }

        // Thread di ascolto: legge righe JSON dal server finche' la connessione resta aperta.
        private void Ascolta()
        {
            byte[] buffer = new byte[4096];
            Decoder decoder = Encoding.UTF8.GetDecoder();
            char[] chars = new char[Encoding.UTF8.GetMaxCharCount(buffer.Length)];
            StringBuilder pending = new StringBuilder();

            try
            {
                while (true)
                {
                    int n = _socket.Receive(buffer);
                    if (n == 0)
                        break; // il server ha chiuso

                    int nc = decoder.GetChars(buffer, 0, n, chars, 0);
                    pending.Append(chars, 0, nc);

                    // Estraggo tutte le righe complete, tengo il resto per il prossimo giro.
                    string testo = pending.ToString();
                    int start = 0;
                    int idx;
                    while ((idx = testo.IndexOf('\n', start)) >= 0)
                    {
                        string riga = testo.Substring(start, idx - start).TrimEnd('\r');
                        start = idx + 1;
                        if (riga.Length > 0)
                            Elabora(riga);
                    }
                    pending.Clear();
                    pending.Append(testo, start, testo.Length - start);
                }
            }
            catch (SocketException) { }
            catch (ObjectDisposedException) { }
            finally
            {
                Chiudi();
            }
        }

        private void Elabora(string riga)
        {
            Message m = null;
            try
            {
                m = Message.FromJson(riga);
            }
            catch (JsonException) { }

            if (m != null)
                MessaggioRicevuto?.Invoke(m);
        }

        private void Chiudi()
        {
            if (Interlocked.Exchange(ref _chiuso, 1) == 1)
                return; // gia' chiuso

            try { _socket.Shutdown(SocketShutdown.Both); } catch { }
            try { _socket.Close(); } catch { }

            Disconnesso?.Invoke();
        }
    }
}