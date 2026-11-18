using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;

namespace allyoucaneat
{
    // Il server accetta i tablet (uno per tavolo) e passa gli ordini alla cucina.
    // Gli eventi partono dai thread di rete: la form usa BeginInvoke per toccare i controlli.
    public class Server
    {
        private readonly object _lock = new object();
        private readonly List<ClientManager> _clients = new List<ClientManager>();
        private Socket _listener;
        private volatile bool _inEsecuzione;

        public List<Piatto> Menu { get; private set; } = new List<Piatto>();

        public event Action<string> Log;
        public event Action<Ordine> OrdineRicevuto;
        public event Action TavoliCambiati;   // un tavolo si e' connesso o disconnesso

        public bool InEsecuzione { get { return _inEsecuzione; } }

        public int TavoliConnessi
        {
            get
            {
                lock (_lock)
                {
                    return _clients.Count(c => c.Tavolo > 0);
                }
            }
        }

        // ---------- Avvio / arresto ----------

        public void Avvia(int porta)
        {
            CaricaMenu();

            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                _listener.Bind(new IPEndPoint(IPAddress.Any, porta));
                _listener.Listen(10);
            }
            catch
            {
                _listener.Close();
                throw; // la form mostra l'errore (es. porta gia' in uso)
            }

            _inEsecuzione = true;
            Thread t = new Thread(AccettaClient);
            t.IsBackground = true;
            t.Start();

            ScriviLog("Server in ascolto sulla porta " + porta);
        }

        public void Ferma()
        {
            if (!_inEsecuzione)
                return;

            _inEsecuzione = false;
            _listener.Close();

            // Lavoro su una copia: Chiudi() rimuove il client dalla lista.
            List<ClientManager> copia;
            lock (_lock)
            {
                copia = new List<ClientManager>(_clients);
            }
            foreach (ClientManager c in copia)
                c.Chiudi();

            ScriviLog("Server fermato");
        }

        // Thread che aspetta i tablet: per ognuno crea un ClientManager con il suo thread.
        private void AccettaClient()
        {
            while (_inEsecuzione)
            {
                try
                {
                    Socket socket = _listener.Accept();

                    ClientManager cm = new ClientManager(socket, this);
                    lock (_lock)
                    {
                        _clients.Add(cm);
                    }

                    Thread t = new Thread(cm.DoClient);
                    t.IsBackground = true;
                    t.Start();
                }
                catch (SocketException) { }          // listener chiuso da Ferma(): il while termina
                catch (ObjectDisposedException) { }
            }
        }

        private void CaricaMenu()
        {
            try
            {
                string percorso = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "menu.json");
                Menu = JsonConvert.DeserializeObject<List<Piatto>>(File.ReadAllText(percorso));
                ScriviLog("Menu caricato: " + Menu.Count + " piatti");
            }
            catch (Exception ex)
            {
                ScriviLog("Errore nel caricamento di menu.json: " + ex.Message);
            }
        }

        // ---------- Chiamati dai ClientManager ----------

        // Il tavolo non lo sceglie il tablet: il server assegna il primo numero libero (1, 2, 3...).
        public void AssegnaTavolo(ClientManager cm)
        {
            int tavolo = 1;
            lock (_lock)
            {
                while (_clients.Any(c => c.Tavolo == tavolo))
                    tavolo++;
                cm.Tavolo = tavolo;
            }

            ScriviLog("Tavolo " + tavolo + " connesso");
            TavoliCambiati?.Invoke();
        }

        public void RiceviOrdine(Ordine ordine)
        {
            ScriviLog("Nuovo ordine dal tavolo " + ordine.Tavolo + ": " + ordine.Riepilogo());
            OrdineRicevuto?.Invoke(ordine);
        }

        public void ClientChiuso(ClientManager cm)
        {
            lock (_lock)
            {
                _clients.Remove(cm);
            }

            if (cm.Tavolo > 0)
            {
                ScriviLog("Tavolo " + cm.Tavolo + " disconnesso");
                TavoliCambiati?.Invoke();
            }
        }

        // ---------- Chiamato dalla form della cucina ----------

        // Cambia lo stato di un ordine e avvisa il tablet del tavolo.
        public void CambiaStato(Ordine ordine, StatoOrdine stato)
        {
            ordine.Stato = stato;

            ClientManager cm;
            lock (_lock)
            {
                cm = _clients.FirstOrDefault(c => c.Tavolo == ordine.Tavolo);
            }

            if (cm == null)
                ScriviLog("Tavolo " + ordine.Tavolo + " non connesso: stato salvato ma non notificato");
            else
                cm.Invia(Message.Crea(Comandi.OrderStatus, ordine.Id, stato.ToString()));
        }

        private void ScriviLog(string testo)
        {
            Log?.Invoke(DateTime.Now.ToString("HH:mm:ss") + "  " + testo);
        }
    }
}
