using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace allyoucaneat
{
    // Logica di rete del server (cucina): accetta i tablet e tiene lo stato degli ordini.
    // Gli eventi vengono sollevati dai thread di rete: la form deve usare Invoke per aggiornare i controlli.
    public class Server
    {
        private readonly object _lock = new object();
        private readonly Dictionary<int, ClientManager> _tavoli = new Dictionary<int, ClientManager>();
        private readonly List<ClientManager> _connessi = new List<ClientManager>();
        private readonly List<Ordine> _ordini = new List<Ordine>();
        private List<Piatto> _menu = new List<Piatto>();

        private Socket _listener;
        private Thread _threadAccept;
        private volatile bool _inEsecuzione;

        public event Action<string> Log;
        public event Action<Ordine> OrdineRicevuto;
        public event Action<int> TavoloConnesso;
        public event Action<int> TavoloDisconnesso;

        public bool InEsecuzione { get { return _inEsecuzione; } }

        // ---------- Avvio / arresto ----------

        public void Avvia(int porta)
        {
            if (_inEsecuzione)
                return;

            CaricaMenu();

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(new IPEndPoint(IPAddress.Any, porta));
                listener.Listen(10);
            }
            catch
            {
                listener.Close();
                throw; // la form mostra l'errore (es. porta gia' in uso)
            }

            _listener = listener;
            _inEsecuzione = true;
            _threadAccept = new Thread(CicloAccept);
            _threadAccept.IsBackground = true;
            _threadAccept.Start();

            ScriviLog("Server in ascolto sulla porta " + porta);
        }

        public void Ferma()
        {
            if (!_inEsecuzione)
                return;

            _inEsecuzione = false;
            try { _listener.Close(); } catch { }

            List<ClientManager> copia;
            lock (_lock)
            {
                copia = new List<ClientManager>(_connessi);
            }
            foreach (ClientManager c in copia)
                c.Chiudi();

            ScriviLog("Server fermato");
        }

        private void CicloAccept()
        {
            while (_inEsecuzione)
            {
                try
                {
                    Socket socket = _listener.Accept();

                    ClientManager cm = new ClientManager(socket, this);
                    lock (_lock)
                    {
                        _connessi.Add(cm);
                    }

                    Thread t = new Thread(cm.DoClient);
                    t.IsBackground = true;
                    t.Start();
                }
                catch (SocketException)
                {
                    if (!_inEsecuzione) break;   // listener chiuso da Ferma()
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
            }
        }

        // ---------- Menu ----------

        private void CaricaMenu()
        {
            string percorso = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "menu.json");
            try
            {
                string json = File.ReadAllText(percorso, Encoding.UTF8);
                List<Piatto> menu = JsonConvert.DeserializeObject<List<Piatto>>(json);
                lock (_lock)
                {
                    _menu = menu ?? new List<Piatto>();
                }
                ScriviLog("Menu caricato: " + _menu.Count + " piatti");
            }
            catch (Exception ex)
            {
                ScriviLog("Errore nel caricamento di menu.json: " + ex.Message);
            }
        }

        public List<Piatto> GetMenu()
        {
            lock (_lock)
            {
                return new List<Piatto>(_menu);
            }
        }

        // ---------- Chiamati dai ClientManager ----------

        public void RegistraTavolo(int tavolo, ClientManager cm)
        {
            ClientManager vecchio = null;
            lock (_lock)
            {
                _tavoli.TryGetValue(tavolo, out vecchio);
                _tavoli[tavolo] = cm;
            }

            // Se il tavolo era gia' connesso (es. tablet riavviato) chiudo la vecchia connessione.
            if (vecchio != null && vecchio != cm)
                vecchio.Chiudi();

            ScriviLog("Tavolo " + tavolo + " connesso");
            TavoloConnesso?.Invoke(tavolo);
        }

        public void RiceviOrdine(Ordine ordine)
        {
            lock (_lock)
            {
                _ordini.Add(ordine);
            }
            ScriviLog("Nuovo ordine dal tavolo " + ordine.Tavolo + ": " + ordine.Riepilogo());
            OrdineRicevuto?.Invoke(ordine);
        }

        public void ClientChiuso(ClientManager cm)
        {
            int tavolo = cm.Tavolo;
            bool rimosso = false;

            lock (_lock)
            {
                _connessi.Remove(cm);

                ClientManager registrato;
                if (tavolo > 0 && _tavoli.TryGetValue(tavolo, out registrato) && registrato == cm)
                {
                    _tavoli.Remove(tavolo);
                    rimosso = true;
                }
            }

            if (rimosso)
            {
                ScriviLog("Tavolo " + tavolo + " disconnesso");
                TavoloDisconnesso?.Invoke(tavolo);
            }
        }

        // ---------- Chiamato dalla form della cucina ----------

        // Cambia lo stato di un ordine e avvisa il tablet del tavolo.
        public bool CambiaStato(string idOrdine, StatoOrdine stato)
        {
            Ordine ordine;
            ClientManager cm;

            lock (_lock)
            {
                ordine = _ordini.FirstOrDefault(o => o.Id == idOrdine);
                if (ordine == null)
                    return false;

                ordine.Stato = stato;
                _tavoli.TryGetValue(ordine.Tavolo, out cm);
            }

            if (cm == null)
            {
                ScriviLog("Tavolo " + ordine.Tavolo + " non connesso: stato salvato ma non notificato");
                return true;
            }

            cm.Invia(Message.Crea(Comandi.OrderStatus, ordine.Id, stato.ToString()));
            return true;
        }

        public List<Ordine> GetOrdini()
        {
            lock (_lock)
            {
                return new List<Ordine>(_ordini);
            }
        }

        private void ScriviLog(string testo)
        {
            Log?.Invoke(DateTime.Now.ToString("HH:mm:ss") + "  " + testo);
        }
    }
}
