using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace allyoucaneat
{
    // Display della cucina: avvia il server, mostra gli ordini in arrivo
    // come scontrini (uno per ordine) e permette al cuoco di cambiarne lo stato (l'aggiornamento arriva al tablet del tavolo).
    public partial class Form1 : Form
    {
        private const int Porta = 5000;

        private readonly Server _server = new Server();
        private readonly HashSet<int> _tavoliConnessi = new HashSet<int>();
        private readonly Dictionary<string, Scontrino> _scontrini = new Dictionary<string, Scontrino>();

        public Form1()
        {
            InitializeComponent();

            _server.Log += testo => EseguiSuUI(() => txtLog.AppendText(testo + Environment.NewLine));
            _server.OrdineRicevuto += ordine => EseguiSuUI(() => AggiungiOrdine(ordine));
            _server.TavoloConnesso += tavolo => EseguiSuUI(() => { _tavoliConnessi.Add(tavolo); AggiornaStatoServer(); });
            _server.TavoloDisconnesso += tavolo => EseguiSuUI(() => { _tavoliConnessi.Remove(tavolo); AggiornaStatoServer(); });

            AggiornaStatoServer();
        }

        // Gli eventi del server arrivano dai thread di rete: i controlli vanno toccati solo dal thread della UI.
        private void EseguiSuUI(Action azione)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            if (InvokeRequired)
                BeginInvoke(azione);
            else
                azione();
        }

        // ---------- Server ----------

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            try
            {
                _server.Avvia(Porta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossibile avviare il server:\n" + ex.Message, "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AggiornaStatoServer();
        }

        private void btnFerma_Click(object sender, EventArgs e)
        {
            _server.Ferma();
            _tavoliConnessi.Clear();
            AggiornaStatoServer();
        }

        private void AggiornaStatoServer()
        {
            bool attivo = _server.InEsecuzione;

            btnAvvia.Enabled = !attivo;
            btnFerma.Enabled = attivo;

            lblStato.Text = attivo
                ? "In ascolto - tavoli connessi: " + _tavoliConnessi.Count
                : "Server fermato";
            lblStato.ForeColor = attivo ? Color.LightGreen : Color.Silver;
        }

        // ---------- Scontrini ----------

        // Ogni ordine in arrivo diventa uno scontrino con i suoi pulsanti.
        private void AggiungiOrdine(Ordine ordine)
        {
            Scontrino scontrino = new Scontrino(ordine);
            scontrino.CambioStatoRichiesto += CambiaStato;
            scontrino.CancellaRichiesto += CancellaOrdine;

            _scontrini[ordine.Id] = scontrino;
            flowScontrini.Controls.Add(scontrino);

            // i nuovi scontrini vanno dopo quelli ancora da gestire ma prima di quelli gia' serviti
            flowScontrini.Controls.SetChildIndex(scontrino, ScontriniAttivi());
        }

        private int ScontriniAttivi()
        {
            int n = 0;
            foreach (Scontrino s in _scontrini.Values)
            {
                if (!s.Servito)
                    n++;
            }
            return n - 1; // il nuovo scontrino e' gia' nel dizionario ed e' attivo
        }

        private void CambiaStato(Scontrino scontrino, StatoOrdine nuovoStato)
        {
            if (!_server.CambiaStato(scontrino.Ordine.Id, nuovoStato))
                return;

            scontrino.Aggiorna();

            // gli scontrini serviti scivolano in fondo, cosi' a sinistra restano quelli da preparare
            if (nuovoStato == StatoOrdine.Servito)
                flowScontrini.Controls.SetChildIndex(scontrino, flowScontrini.Controls.Count - 1);
        }

        private void CancellaOrdine(Scontrino scontrino)
        {
            DialogResult risposta = MessageBox.Show(
                "Cancellare l'ordine del tavolo " + scontrino.Ordine.Tavolo + "?\n\n" + scontrino.Ordine.Riepilogo(),
                "Cancella ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (risposta != DialogResult.Yes)
                return;

            // il tablet del tavolo viene avvisato con lo stato "Annullato"
            if (!_server.CambiaStato(scontrino.Ordine.Id, StatoOrdine.Annullato))
                return;

            _scontrini.Remove(scontrino.Ordine.Id);
            flowScontrini.Controls.Remove(scontrino);
            scontrino.Dispose();
        }

        // ---------- Chiusura ----------

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.Ferma();
        }
    }
}