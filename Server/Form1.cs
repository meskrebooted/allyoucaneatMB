using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace allyoucaneat
{
    // Display della cucina: avvia il server, mostra gli ordini in arrivo
    // e permette al cuoco di cambiarne lo stato (l'aggiornamento arriva al tablet del tavolo).
    public partial class Form1 : Form
    {
        private readonly Server _server = new Server();
        private readonly HashSet<int> _tavoliConnessi = new HashSet<int>();

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
                _server.Avvia((int)numPorta.Value);
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
            numPorta.Enabled = !attivo;

            lblStato.Text = attivo
                ? "In ascolto - tavoli connessi: " + _tavoliConnessi.Count
                : "Server fermato";
        }

        // ---------- Ordini ----------

        private void AggiungiOrdine(Ordine ordine)
        {
            int indice = dgvOrdini.Rows.Add(
                ordine.Id,
                ordine.Tavolo,
                ordine.Ora.ToString("HH:mm:ss"),
                ordine.Riepilogo(),
                ordine.Stato.ToString());

            ColoraRiga(dgvOrdini.Rows[indice], ordine.Stato);
        }

        private void btnInPreparazione_Click(object sender, EventArgs e)
        {
            CambiaStatoSelezionato(StatoOrdine.InPreparazione);
        }

        private void btnPronto_Click(object sender, EventArgs e)
        {
            CambiaStatoSelezionato(StatoOrdine.Pronto);
        }

        private void btnServito_Click(object sender, EventArgs e)
        {
            CambiaStatoSelezionato(StatoOrdine.Servito);
        }

        private void CambiaStatoSelezionato(StatoOrdine nuovoStato)
        {
            DataGridViewRow riga = dgvOrdini.CurrentRow;
            if (riga == null)
            {
                MessageBox.Show("Seleziona prima un ordine.", "Cucina",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string idOrdine = riga.Cells[colId.Index].Value as string;
            if (_server.CambiaStato(idOrdine, nuovoStato))
            {
                riga.Cells[colStato.Index].Value = nuovoStato.ToString();
                ColoraRiga(riga, nuovoStato);
            }
        }

        private static void ColoraRiga(DataGridViewRow riga, StatoOrdine stato)
        {
            switch (stato)
            {
                case StatoOrdine.InPreparazione:
                    riga.DefaultCellStyle.BackColor = Color.LemonChiffon;
                    break;
                case StatoOrdine.Pronto:
                    riga.DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
                case StatoOrdine.Servito:
                    riga.DefaultCellStyle.BackColor = Color.LightGray;
                    break;
                default:
                    riga.DefaultCellStyle.BackColor = Color.White;
                    break;
            }
        }

        // ---------- Chiusura ----------

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.Ferma();
        }
    }
}
