using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace allyoucaneat
{
    // Display della cucina: avvia il server, mostra gli ordini in arrivo come scontrini
    // (uno per ordine) e permette al cuoco di cambiarne lo stato (il tablet del tavolo viene avvisato).
    public partial class Form1 : Form
    {
        private const int Porta = 5000;

        private readonly Server _server = new Server();
        private readonly List<Scontrino> _scontrini = new List<Scontrino>();   // in ordine di arrivo

        public Form1()
        {
            InitializeComponent();

            _server.Log += testo => EseguiSuUI(() => txtLog.AppendText(testo + Environment.NewLine));
            _server.OrdineRicevuto += ordine => EseguiSuUI(() => AggiungiOrdine(ordine));
            _server.TavoliCambiati += () => EseguiSuUI(AggiornaStatoServer);

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
            AggiornaStatoServer();
        }

        private void AggiornaStatoServer()
        {
            bool attivo = _server.InEsecuzione;

            btnAvvia.Enabled = !attivo;
            btnFerma.Enabled = attivo;

            lblStato.Text = attivo
                ? "In ascolto - tavoli connessi: " + _server.TavoliConnessi
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

            _scontrini.Add(scontrino);
            flowScontrini.Controls.Add(scontrino);
            RiordinaScontrini();
        }

        // Prima gli scontrini ancora da gestire, poi quelli serviti (in fondo).
        private void RiordinaScontrini()
        {
            int posizione = 0;

            foreach (Scontrino da in _scontrini.Where(x => !x.Servito))
                flowScontrini.Controls.SetChildIndex(da, posizione++);

            foreach (Scontrino servito in _scontrini.Where(x => x.Servito))
                flowScontrini.Controls.SetChildIndex(servito, posizione++);
        }

        private void CambiaStato(Scontrino scontrino, StatoOrdine nuovoStato)
        {
            _server.CambiaStato(scontrino.Ordine, nuovoStato);
            scontrino.Aggiorna();
            RiordinaScontrini();
        }

        private void CancellaOrdine(Scontrino scontrino)
        {
            DialogResult risposta = MessageBox.Show(
                "Cancellare l'ordine del tavolo " + scontrino.Ordine.Tavolo + "?\n\n" + scontrino.Ordine.Riepilogo(),
                "Cancella ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (risposta != DialogResult.Yes)
                return;

            // il tablet del tavolo viene avvisato con lo stato "Annullato"
            _server.CambiaStato(scontrino.Ordine, StatoOrdine.Annullato);

            _scontrini.Remove(scontrino);
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
