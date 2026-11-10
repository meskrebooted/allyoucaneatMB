using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using allyoucaneat;
using Newtonsoft.Json;
using Message = allyoucaneat.Message; // evita il conflitto con System.Windows.Forms.Message

namespace Client
{
    // Display del tablet: menu per categorie, carrello, invio dell'ordine alla cucina
    // e stato degli ordini inviati (aggiornato quando la cucina preme "In preparazione" / "Pronto").
    public partial class Form1 : Form
    {
        private const int Porta = 5000;

        private static readonly Color Rosso = Color.FromArgb(192, 57, 43);
        private static readonly Font FontPiatto = new Font("Segoe UI", 11F, FontStyle.Bold);
        private static readonly Font FontCategoria = new Font("Segoe UI", 10F, FontStyle.Bold);

        private readonly Client _client = new Client();
        private List<Piatto> _menu = new List<Piatto>();
        private readonly List<RigaOrdine> _carrello = new List<RigaOrdine>();
        private readonly Queue<Ordine> _inAttesaConferma = new Queue<Ordine>();
        private string _categoriaCorrente = null; // null = tutte le categorie

        public Form1()
        {
            InitializeComponent();

            _client.MessaggioRicevuto += m => EseguiSuUI(() => GestisciMessaggio(m));
            _client.Disconnesso += () => EseguiSuUI(GestisciDisconnessione);

            AggiornaCarrello();
            AggiornaStato();
        }

        // Gli eventi del client arrivano dal thread di ascolto: i controlli vanno toccati solo dalla UI.
        private void EseguiSuUI(Action azione)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            if (InvokeRequired)
                BeginInvoke(azione);
            else
                azione();
        }

        // ---------- Connessione ----------

        private void btnConnetti_Click(object sender, EventArgs e)
        {
            try
            {
                _client.Connetti(txtIp.Text.Trim(), Porta, (int)numTavolo.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossibile connettersi:\n" + ex.Message, "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AggiornaStato();
        }

        private void btnDisconnetti_Click(object sender, EventArgs e)
        {
            _client.Disconnetti();
        }

        private void GestisciDisconnessione()
        {
            _inAttesaConferma.Clear();
            AggiornaStato();
            lblStato.Text = "Connessione chiusa";
        }

        private void AggiornaStato()
        {
            bool connesso = _client.Connesso;

            btnConnetti.Enabled = !connesso;
            btnDisconnetti.Enabled = connesso;
            txtIp.Enabled = !connesso;
            numTavolo.Enabled = !connesso;

            lblStato.Text = connesso ? "Connesso - Tavolo " + numTavolo.Value : "Non connesso";
            lblStato.ForeColor = connesso ? Color.LightGreen : Color.Silver;

            AggiornaPulsanti();
        }

        // ---------- Messaggi dal server ----------

        private void GestisciMessaggio(Message m)
        {
            switch (m.CommandName)
            {
                case Comandi.Hello:
                    if (m.Parametro(0) == "ok")
                        _client.Invia(Message.Crea(Comandi.GetMenu));
                    break;

                case Comandi.Menu:
                    CaricaMenu(m.Parametro(0));
                    break;

                case Comandi.OrderReceived:
                    OrdineConfermato(m.Parametro(0));
                    break;

                case Comandi.OrderStatus:
                    AggiornaStatoOrdine(m.Parametro(0), m.Parametro(1));
                    break;

                case Comandi.Error:
                    GestisciErrore(m.Parametro(0));
                    break;
            }
        }

        private void GestisciErrore(string testo)
        {
            // Se c'era un ordine in attesa di conferma, e' stato rifiutato: lo rimetto nel carrello.
            if (_inAttesaConferma.Count > 0)
            {
                Ordine rifiutato = _inAttesaConferma.Dequeue();
                foreach (RigaOrdine r in rifiutato.Righe)
                    AggiungiAlCarrello(r.PiattoId, r.NomePiatto, r.Quantita);

                MessageBox.Show("Il server ha rifiutato l'ordine: " + testo, "Ordine non inviato",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Errore dal server: " + testo, "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ---------- Menu ----------

        private void CaricaMenu(string json)
        {
            if (string.IsNullOrEmpty(json))
                return;

            try
            {
                _menu = JsonConvert.DeserializeObject<List<Piatto>>(json) ?? new List<Piatto>();
            }
            catch (JsonException)
            {
                MessageBox.Show("Menu ricevuto non valido.", "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CostruisciCategorie();
            MostraPiatti();
        }

        private void CostruisciCategorie()
        {
            SvuotaPannello(flowCategorie);

            flowCategorie.Controls.Add(CreaPulsanteCategoria("Tutti", ""));
            foreach (string categoria in _menu.Select(p => p.Categoria).Where(c => !string.IsNullOrEmpty(c)).Distinct())
                flowCategorie.Controls.Add(CreaPulsanteCategoria(categoria, categoria));

            _categoriaCorrente = null;
            EvidenziaCategoria();
        }

        private Button CreaPulsanteCategoria(string testo, string categoria)
        {
            Button b = new Button();
            b.Text = testo;
            b.Tag = categoria; // "" = tutte
            b.Size = new Size(120, 42);
            b.Margin = new Padding(0, 0, 8, 0);
            b.Font = FontCategoria;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = Color.FromArgb(220, 210, 200);
            b.Click += CategoriaClick;
            return b;
        }

        private void CategoriaClick(object sender, EventArgs e)
        {
            string categoria = (string)((Button)sender).Tag;
            _categoriaCorrente = string.IsNullOrEmpty(categoria) ? null : categoria;
            EvidenziaCategoria();
            MostraPiatti();
        }

        private void EvidenziaCategoria()
        {
            foreach (Button b in flowCategorie.Controls.OfType<Button>())
            {
                bool selezionata = (string)b.Tag == (_categoriaCorrente ?? "");
                b.BackColor = selezionata ? Rosso : Color.White;
                b.ForeColor = selezionata ? Color.White : Color.FromArgb(60, 60, 60);
            }
        }

        private void MostraPiatti()
        {
            flowPiatti.SuspendLayout();
            SvuotaPannello(flowPiatti);

            foreach (Piatto p in _menu.Where(x => _categoriaCorrente == null || x.Categoria == _categoriaCorrente))
                flowPiatti.Controls.Add(CreaPulsantePiatto(p));

            flowPiatti.ResumeLayout();
        }

        private Button CreaPulsantePiatto(Piatto p)
        {
            Button b = new Button();
            b.Text = p.Disponibile ? p.Nome : p.Nome + "\n(esaurito)";
            b.Enabled = p.Disponibile;
            b.Tag = p;
            b.Size = new Size(190, 90);
            b.Margin = new Padding(8);
            b.Font = FontPiatto;
            b.BackColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = Color.FromArgb(220, 210, 200);
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(253, 236, 232);
            b.Click += PiattoClick;
            return b;
        }

        private void PiattoClick(object sender, EventArgs e)
        {
            Piatto p = (Piatto)((Button)sender).Tag;
            AggiungiAlCarrello(p.Id, p.Nome, 1);
        }

        private static void SvuotaPannello(Control pannello)
        {
            while (pannello.Controls.Count > 0)
                pannello.Controls[0].Dispose(); // Dispose lo toglie anche dalla collezione
        }

        // ---------- Carrello ----------

        private void AggiungiAlCarrello(int piattoId, string nome, int quantita)
        {
            RigaOrdine riga = _carrello.FirstOrDefault(r => r.PiattoId == piattoId);
            if (riga == null)
                _carrello.Add(new RigaOrdine { PiattoId = piattoId, NomePiatto = nome, Quantita = quantita });
            else
                riga.Quantita += quantita;

            AggiornaCarrello();
        }

        private void AggiornaCarrello()
        {
            int selezionato = lvCarrello.SelectedIndices.Count > 0 ? lvCarrello.SelectedIndices[0] : -1;

            lvCarrello.BeginUpdate();
            lvCarrello.Items.Clear();
            foreach (RigaOrdine r in _carrello)
            {
                ListViewItem item = new ListViewItem(r.NomePiatto);
                item.SubItems.Add(r.Quantita.ToString());
                lvCarrello.Items.Add(item);
            }
            lvCarrello.EndUpdate();

            if (selezionato >= 0 && selezionato < lvCarrello.Items.Count)
                lvCarrello.Items[selezionato].Selected = true;

            lblTotale.Text = "Piatti nel carrello: " + _carrello.Sum(r => r.Quantita);
            AggiornaPulsanti();
        }

        private void AggiornaPulsanti()
        {
            bool haSelezione = lvCarrello.SelectedIndices.Count > 0;
            btnPiu.Enabled = haSelezione;
            btnMeno.Enabled = haSelezione;
            btnRimuovi.Enabled = haSelezione;
            btnInvia.Enabled = _client.Connesso && _carrello.Count > 0;
        }

        private void lvCarrello_SelectedIndexChanged(object sender, EventArgs e)
        {
            AggiornaPulsanti();
        }

        private RigaOrdine RigaSelezionata()
        {
            if (lvCarrello.SelectedIndices.Count == 0)
                return null;
            return _carrello[lvCarrello.SelectedIndices[0]];
        }

        private void btnPiu_Click(object sender, EventArgs e)
        {
            RigaOrdine riga = RigaSelezionata();
            if (riga == null) return;
            riga.Quantita++;
            AggiornaCarrello();
        }

        private void btnMeno_Click(object sender, EventArgs e)
        {
            RigaOrdine riga = RigaSelezionata();
            if (riga == null) return;
            riga.Quantita--;
            if (riga.Quantita <= 0)
                _carrello.Remove(riga);
            AggiornaCarrello();
        }

        private void btnRimuovi_Click(object sender, EventArgs e)
        {
            RigaOrdine riga = RigaSelezionata();
            if (riga == null) return;
            _carrello.Remove(riga);
            AggiornaCarrello();
        }

        // ---------- Invio ordine ----------

        private void btnInvia_Click(object sender, EventArgs e)
        {
            if (_carrello.Count == 0)
                return;

            Ordine ordine = new Ordine();
            ordine.Righe = _carrello
                .Select(r => new RigaOrdine { PiattoId = r.PiattoId, NomePiatto = r.NomePiatto, Quantita = r.Quantita })
                .ToList();

            string json = JsonConvert.SerializeObject(ordine);
            if (!_client.Invia(Message.Crea(Comandi.NewOrder, json)))
            {
                MessageBox.Show("Connessione al server persa: l'ordine non è stato inviato.", "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _inAttesaConferma.Enqueue(ordine);
            _carrello.Clear();
            AggiornaCarrello();
        }

        // Il server risponde alle richieste nello stesso ordine in cui le riceve,
        // quindi la conferma si riferisce al piu' vecchio ordine in attesa.
        private void OrdineConfermato(string idOrdine)
        {
            if (_inAttesaConferma.Count == 0 || string.IsNullOrEmpty(idOrdine))
                return;

            Ordine ordine = _inAttesaConferma.Dequeue();

            ListViewItem item = new ListViewItem(ordine.Ora.ToString("HH:mm"));
            item.SubItems.Add(ordine.Riepilogo());
            item.SubItems.Add(NomeStato(StatoOrdine.Inviato));
            item.Tag = idOrdine;
            ColoraOrdine(item, StatoOrdine.Inviato);
            lvOrdini.Items.Insert(0, item);
        }

        // ---------- Stato degli ordini ----------

        private void AggiornaStatoOrdine(string idOrdine, string statoTesto)
        {
            StatoOrdine stato;
            if (!Enum.TryParse(statoTesto, out stato))
                return;

            foreach (ListViewItem item in lvOrdini.Items)
            {
                if ((string)item.Tag != idOrdine)
                    continue;

                item.SubItems[2].Text = NomeStato(stato);
                ColoraOrdine(item, stato);

                if (stato == StatoOrdine.Pronto)
                    MostraBanner("Il tuo ordine è pronto!");
                return;
            }
        }

        private static string NomeStato(StatoOrdine stato)
        {
            switch (stato)
            {
                case StatoOrdine.InPreparazione: return "In preparazione";
                case StatoOrdine.Pronto: return "Pronto";
                case StatoOrdine.Servito: return "Servito";
                default: return "Inviato";
            }
        }

        private static void ColoraOrdine(ListViewItem item, StatoOrdine stato)
        {
            switch (stato)
            {
                case StatoOrdine.InPreparazione: item.BackColor = Color.LemonChiffon; break;
                case StatoOrdine.Pronto: item.BackColor = Color.LightGreen; break;
                case StatoOrdine.Servito: item.BackColor = Color.LightGray; break;
                default: item.BackColor = Color.White; break;
            }
        }

        private void MostraBanner(string testo)
        {
            lblBanner.Text = testo;
            lblBanner.Visible = true;
            timerBanner.Stop();
            timerBanner.Start();
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void timerBanner_Tick(object sender, EventArgs e)
        {
            timerBanner.Stop();
            lblBanner.Visible = false;
        }

        // ---------- Chiusura ----------

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client.Connesso)
                _client.Disconnetti();
        }
    }
}