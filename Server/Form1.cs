using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace allyoucaneat
{
    // Display della cucina: avvia il server, mostra gli ordini in arrivo
    // e permette al cuoco di cambiarne lo stato (l'aggiornamento arriva al tablet del tavolo).
    public partial class Form1 : Form
    {
        private readonly Server _server = new Server();
        private readonly HashSet<int> _tavoliConnessi = new HashSet<int>();
        private readonly Timer _timerTempi = new Timer();
        private readonly ToolTip _tt = new ToolTip();
        private string _filtroTavolo = "";

        // Trascinamento finestra (FormBorderStyle = None)
        private bool _dragging = false;
        private Point _dragStart = Point.Empty;

        public Form1()
        {
            InitializeComponent();

            // Titolo della finestra
            this.Text = "Cucina - All You Can Eat Sushi";

            // Colore selezione righe griglia
            dgvOrdini.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 77, 58);
            dgvOrdini.DefaultCellStyle.SelectionForeColor = Color.FromArgb(245, 245, 240);

            // Tooltip sui controlli
            _tt.SetToolTip(btnAvvia, "Avvia il server TCP in ascolto");
            _tt.SetToolTip(btnFerma, "Ferma il server e chiude i tablet");
            _tt.SetToolTip(btnRicaricaMenu, "Ricarica menu.json da disco");
            _tt.SetToolTip(dgvOrdini, "Seleziona un ordine per cambiarne lo stato");
            _tt.SetToolTip(txtFiltroTavolo, "Filtra ordini per numero di tavolo");
            _tt.SetToolTip(btnInPreparazione, "Passa l'ordine selezionato in preparazione");
            _tt.SetToolTip(btnPronto, "Segna l'ordine come pronto");
            _tt.SetToolTip(btnServito, "Segna l'ordine come servito");
            _tt.SetToolTip(btnEliminaServiti, "Rimuove gli ordini gia' serviti");
            _tt.SetToolTip(btnEsportaCSV, "Esporta gli ordini in file CSV");
            _tt.SetToolTip(txtLog, "Log delle operazioni del server");

            // Effetto hover sui pulsanti azione
            AggiungiHover(btnInPreparazione, Color.FromArgb(212, 175, 55), Color.FromArgb(240, 210, 100));
            AggiungiHover(btnPronto, Color.FromArgb(143, 188, 143), Color.FromArgb(180, 220, 180));
            AggiungiHover(btnServito, Color.FromArgb(143, 188, 143), Color.FromArgb(180, 220, 180));
            AggiungiHover(btnEliminaServiti, Color.FromArgb(42, 42, 42), Color.FromArgb(70, 70, 70));
            AggiungiHover(btnEsportaCSV, Color.FromArgb(42, 42, 42), Color.FromArgb(70, 70, 70));

            // Titolo bar hover
            AggiungiHover(btnRiduisci, Color.FromArgb(26, 26, 26), Color.FromArgb(60, 60, 60));
            AggiungiHover(btnChiudi, Color.FromArgb(224, 77, 58), Color.FromArgb(240, 110, 90));

            // Gli eventi del server arrivano dai thread di rete: i controlli vanno toccati solo dal thread della UI.
            _server.Log += testo => EseguiSuUI(() => txtLog.AppendText(testo + Environment.NewLine));
            _server.OrdineRicevuto += ordine => EseguiSuUI(() => AggiungiOrdine(ordine));
            _server.OrdineStatoCambiato += (ordine, stato) => EseguiSuUI(() => AggiornaRigaStato(ordine, stato));
            _server.TavoloConnesso += tavolo => EseguiSuUI(() => { _tavoliConnessi.Add(tavolo); AggiornaTavoliEContatori(); });
            _server.TavoloDisconnesso += tavolo => EseguiSuUI(() => { _tavoliConnessi.Remove(tavolo); AggiornaTavoliEContatori(); });

            // Aggiorna ogni secondo la colonna "Trascorsi" di ogni ordine.
            _timerTempi.Interval = 1000;
            _timerTempi.Tick += (s, e) => AggiornaTempiTrascorsi();
            _timerTempi.Start();

            AggiornaStatoServer();
            AggiornaTavoliEContatori();
        }

        // Effetto hover: cambia colore al passaggio del mouse.
        private void AggiungiHover(Button btn, Color coloreNormale, Color coloreHover)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = coloreHover;
            btn.MouseLeave += (s, e) => btn.BackColor = coloreNormale;
        }

        // ---------- Trascinamento finestra (title bar personalizzata) ----------

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                _dragStart = e.Location;
            }
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point delta = new Point(e.X - _dragStart.X, e.Y - _dragStart.Y);
                this.Location = new Point(this.Location.X + delta.X, this.Location.Y + delta.Y);
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void btnRiduisci_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Gli eventi del server arrivano dai thread di rete: i controlli vanno toccati solo dal thread della UI.
        private void EseguiSuUI(Action azione)
        {
            try
            {
                if (IsDisposed || !IsHandleCreated)
                    return;

                if (InvokeRequired)
                    BeginInvoke(azione);
                else
                    azione();
            }
            catch
            {
                // Form in chiusura: ignora.
            }
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
            AggiornaTavoliEContatori();
        }

        private void btnRicaricaMenu_Click(object sender, EventArgs e)
        {
            _server.RicaricaMenu();
        }

        private void AggiornaStatoServer()
        {
            bool attivo = _server.InEsecuzione;

            btnAvvia.Enabled = !attivo;
            btnFerma.Enabled = attivo;
            btnRicaricaMenu.Enabled = attivo;
            numPorta.Enabled = !attivo;

            lblStato.Text = attivo
                ? "In ascolto - tavoli connessi: " + _tavoliConnessi.Count
                : "Server fermato";
            lblStato.ForeColor = attivo ? Color.FromArgb(143, 188, 143) : Color.FromArgb(224, 77, 58);
        }

        // ---------- Ordini ----------

        private void AggiungiOrdine(Ordine ordine)
        {
            int indice = dgvOrdini.Rows.Add(
                ordine.Id,
                ordine.Tavolo,
                ordine.Ora.ToString("HH:mm:ss"),
                "00:00",
                ordine.Riepilogo(),
                ordine.Stato.ToString());

            DataGridViewRow riga = dgvOrdini.Rows[indice];
            riga.Tag = ordine;
            ColoraRiga(riga, ordine.Stato);

            AggiornaTavoliEContatori();
        }

        private void AggiornaRigaStato(Ordine ordine, StatoOrdine nuovoStato)
        {
            foreach (DataGridViewRow riga in dgvOrdini.Rows)
            {
                if (riga.Tag == ordine)
                {
                    riga.Cells[colStato.Index].Value = nuovoStato.ToString();
                    ColoraRiga(riga, nuovoStato);
                    AggiornaTavoliEContatori();
                    AggiornaPulsantiSelezione();
                    break;
                }
            }
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

            Ordine ordine = riga.Tag as Ordine;
            if (ordine == null)
                return;

            if (!_server.CambiaStato(ordine.Id, nuovoStato))
            {
                MessageBox.Show("Non e' possibile passare l'ordine allo stato '" + nuovoStato + "'.",
                    "Cucina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            riga.Cells[colStato.Index].Value = nuovoStato.ToString();
            ColoraRiga(riga, nuovoStato);
            AggiornaTavoliEContatori();
        }

        private void btnEliminaServiti_Click(object sender, EventArgs e)
        {
            int rimossi = _server.RimuoviOrdiniServiti();
            if (rimossi == 0)
            {
                MessageBox.Show("Non ci sono ordini serviti da rimuovere.", "Cucina",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Rimuovi le righe corrispondenti dalla griglia.
            for (int i = dgvOrdini.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow riga = dgvOrdini.Rows[i];
                Ordine ordine = riga.Tag as Ordine;
                if (ordine != null && ordine.Stato == StatoOrdine.Servito)
                    dgvOrdini.Rows.RemoveAt(i);
            }

            AggiornaTavoliEContatori();
        }

        private void btnEsportaCSV_Click(object sender, EventArgs e)
        {
            List<Ordine> ordini = _server.GetOrdini();
            if (ordini.Count == 0)
            {
                MessageBox.Show("Non ci sono ordini da esportare.", "Cucina",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Esporta ordini";
                dlg.Filter = "File CSV|*.csv";
                dlg.FileName = "ordini_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Id,Tavolo,Ora,Piatti,Stato");
                    foreach (Ordine o in ordini)
                    {
                        sb.Append(o.Id).Append(',');
                        sb.Append(o.Tavolo).Append(',');
                        sb.Append('"').Append(o.Ora.ToString("yyyy-MM-dd HH:mm:ss")).Append('"').Append(',');
                        sb.Append('"').Append(o.Riepilogo().Replace("\"", "\"\"")).Append('"').Append(',');
                        sb.AppendLine(o.Stato.ToString());
                    }
                    File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
                    ScriviLog("Ordini esportati: " + dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Esportazione fallita:\n" + ex.Message, "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOrdini_SelectionChanged(object sender, EventArgs e)
        {
            AggiornaPulsantiSelezione();
        }

        private void AggiornaPulsantiSelezione()
        {
            bool haSelezione = dgvOrdini.CurrentRow != null;
            StatoOrdine stato = StatoOrdine.Inviato;

            if (haSelezione)
            {
                DataGridViewRow riga = dgvOrdini.CurrentRow;
                string testoStato = riga.Cells[colStato.Index].Value as string;
                if (!Enum.TryParse(testoStato, out stato))
                    stato = StatoOrdine.Inviato;
            }

            btnInPreparazione.Enabled = haSelezione && stato == StatoOrdine.Inviato;
            btnPronto.Enabled = haSelezione && stato == StatoOrdine.InPreparazione;
            btnServito.Enabled = haSelezione && stato == StatoOrdine.Pronto;
        }

        private static void ColoraRiga(DataGridViewRow riga, StatoOrdine stato)
        {
            switch (stato)
            {
                case StatoOrdine.InPreparazione:
                    riga.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 200);
                    break;
                case StatoOrdine.Pronto:
                    riga.DefaultCellStyle.BackColor = Color.FromArgb(210, 240, 210);
                    break;
                case StatoOrdine.Servito:
                    riga.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
                    riga.DefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 160);
                    break;
                default:
                    riga.DefaultCellStyle.BackColor = Color.FromArgb(26, 26, 26);
                    riga.DefaultCellStyle.ForeColor = Color.FromArgb(245, 245, 240);
                    break;
            }
        }

        // ---------- Filtro tavoli ----------

        private void txtFiltroTavolo_TextChanged(object sender, EventArgs e)
        {
            _filtroTavolo = txtFiltroTavolo.Text;
            ApplicaFiltro();
        }

        private void txtFiltroTavolo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo cifre e tasti di controllo.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void ApplicaFiltro()
        {
            foreach (DataGridViewRow riga in dgvOrdini.Rows)
            {
                if (riga.IsNewRow)
                    continue;

                string tavolo = riga.Cells[colTavolo.Index].Value as string;
                bool visibile = string.IsNullOrEmpty(_filtroTavolo) || tavolo == _filtroTavolo;
                riga.Visible = visibile;
            }
        }

        // ---------- Contatori e tavoli ----------

        private void AggiornaTavoliEContatori()
        {
            lblTavoliConnessi.Text = "Tavoli: " + _tavoliConnessi.Count;

            int inviato = 0, inPreparazione = 0, pronto = 0, servito = 0;
            foreach (DataGridViewRow riga in dgvOrdini.Rows)
            {
                if (riga.IsNewRow)
                    continue;
                string testoStato = riga.Cells[colStato.Index].Value as string;
                switch (testoStato)
                {
                    case "Inviato": inviato++; break;
                    case "InPreparazione": inPreparazione++; break;
                    case "Pronto": pronto++; break;
                    case "Servito": servito++; break;
                }
            }

            lblContatori.Text = "Totale: " + dgvOrdini.Rows.Count +
                "  |  Inviato: " + inviato +
                "  |  In preparazione: " + inPreparazione +
                "  |  Pronto: " + pronto +
                "  |  Servito: " + servito;
        }

        private void AggiornaTempiTrascorsi()
        {
            DateTime ora = DateTime.Now;
            foreach (DataGridViewRow riga in dgvOrdini.Rows)
            {
                if (riga.IsNewRow || riga.Tag == null)
                    continue;

                Ordine ordine = riga.Tag as Ordine;
                if (ordine == null)
                    continue;

                TimeSpan trascorsi = ora - ordine.Ora;
                string testo = trascorsi.TotalSeconds < 60
                    ? "00:" + trascorsi.Seconds.ToString("D2")
                    : trascorsi.Minutes.ToString("D2") + ":" + trascorsi.Seconds.ToString("D2");

                if (riga.Cells[colTrascorsi.Index].Value as string != testo)
                    riga.Cells[colTrascorsi.Index].Value = testo;
            }
        }

        private void ScriviLog(string testo)
        {
            txtLog.AppendText(DateTime.Now.ToString("HH:mm:ss") + "  " + testo + Environment.NewLine);
            if (txtLog.Lines.Length > 500)
            {
                var righe = txtLog.Lines;
                var nuove = new string[righe.Length - 100];
                Array.Copy(righe, 100, nuove, 0, nuove.Length);
                txtLog.Lines = nuove;
            }
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }

        // ---------- Chiusura ----------

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timerTempi.Stop();
            _server.Ferma();
        }
    }
}
