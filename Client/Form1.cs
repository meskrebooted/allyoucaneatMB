using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Client
{
    // Display del tablet: menu per categorie, carrello, invio dell'ordine alla cucina
    // e stato degli ordini inviati (aggiornato quando la cucina cambia lo stato o cancella l'ordine).
    public partial class Form1 : Form
    {
        private const int Porta = 5000;

        private static readonly Color Rosso = Color.FromArgb(192, 57, 43);
        private static readonly Font FontTesto = new Font("Segoe UI", 11F, FontStyle.Bold);
        private static readonly Size DimensioneFoto = new Size(196, 107);

        private readonly Client _client = new Client();
        private readonly List<RigaOrdine> _carrello = new List<RigaOrdine>();
        private readonly Queue<Ordine> _inAttesaConferma = new Queue<Ordine>();
        private readonly Dictionary<string, Image> _immagini = new Dictionary<string, Image>(); // foto gia' caricate
        private List<Piatto> _menu = new List<Piatto>();
        private string _categoriaCorrente;   // null = tutte le categorie
        private int _tavolo;                 // assegnato dal server dopo la connessione

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
                _client.Connetti(txtIp.Text.Trim(), Porta);
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
            _tavolo = 0;
            AggiornaStato();
            lblStato.Text = "Connessione chiusa";
        }

        private void AggiornaStato()
        {
            bool connesso = _client.Connesso;

            btnConnetti.Enabled = !connesso;
            btnDisconnetti.Enabled = connesso;
            txtIp.Enabled = !connesso;

            if (!connesso)
                lblStato.Text = "Non connesso";
            else if (_tavolo > 0)
                lblStato.Text = "Connesso - Tavolo " + _tavolo;
            else
                lblStato.Text = "Connessione in corso...";

            Text = (connesso && _tavolo > 0) ? "Tablet - Tavolo " + _tavolo : "Tablet - All You Can Eat";
            lblStato.ForeColor = connesso ? Color.LightGreen : Color.Silver;

            AggiornaPulsanti();
        }

        // ---------- Messaggi dal server ----------

        private void GestisciMessaggio(Message m)
        {
            switch (m.CommandName)
            {
                case Comandi.Hello:
                    int tavolo;
                    if (int.TryParse(m.Parametro(0), out tavolo))
                    {
                        _tavolo = tavolo;
                        AggiornaStato();
                        _client.Invia(Message.Crea(Comandi.GetMenu));
                    }
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
                MessageBox.Show("Menu ricevuto non valido.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pulsanti delle categorie: "Tutti" (categoria null) + una per ogni categoria del menu
            SvuotaPannello(flowCategorie);
            flowCategorie.Controls.Add(CreaPulsanteCategoria("Tutti", null));
            foreach (string categoria in _menu.Select(p => p.Categoria).Where(c => !string.IsNullOrEmpty(c)).Distinct())
                flowCategorie.Controls.Add(CreaPulsanteCategoria(categoria, categoria));

            _categoriaCorrente = null;
            EvidenziaCategoria();
            MostraPiatti();
        }

        private Button CreaPulsanteCategoria(string testo, string categoria)
        {
            Button b = new Button();
            b.Text = testo;
            b.Tag = categoria;   // null = tutte
            b.Size = new Size(150, 48);
            b.Margin = new Padding(0, 0, 0, 8);
            b.Font = FontTesto;
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Padding = new Padding(10, 0, 0, 0);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = Color.FromArgb(220, 210, 200);
            b.Click += CategoriaClick;
            return b;
        }

        private void CategoriaClick(object sender, EventArgs e)
        {
            _categoriaCorrente = (string)((Button)sender).Tag;
            EvidenziaCategoria();
            MostraPiatti();
        }

        private void EvidenziaCategoria()
        {
            foreach (Button b in flowCategorie.Controls.OfType<Button>())
            {
                bool selezionata = (string)b.Tag == _categoriaCorrente;
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

        // Ogni piatto e' un pulsante con la foto sopra e il nome sotto: un clic lo aggiunge al carrello.
        private Button CreaPulsantePiatto(Piatto p)
        {
            Button b = new Button();
            b.Size = new Size(214, 170);
            b.Margin = new Padding(8);
            b.Tag = p;
            b.Text = p.Disponibile ? p.Nome : p.Nome + " (esaurito)";
            b.UseMnemonic = false;   // un '&' nel nome non deve diventare una scorciatoia
            b.Font = FontTesto;
            b.Image = CaricaImmagine(p.Immagine);
            b.TextImageRelation = TextImageRelation.ImageAboveText;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = Color.FromArgb(220, 210, 200);
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(253, 236, 232);
            b.BackColor = Color.White;
            b.Enabled = p.Disponibile;   // un piatto esaurito non si puo' ordinare
            b.Click += PiattoClick;
            return b;
        }

        private void PiattoClick(object sender, EventArgs e)
        {
            Piatto p = (Piatto)((Button)sender).Tag;
            AggiungiAlCarrello(p.Id, p.Nome, 1);
        }

        // Le foto stanno nella cartella img_menu accanto all'exe (la copia il progetto in fase di build).
        // Sono grandi (1408x768): le riduco una volta sola e le tengo in memoria.
        private Image CaricaImmagine(string nomeFile)
        {
            if (string.IsNullOrEmpty(nomeFile))
                return null;

            Image foto;
            if (_immagini.TryGetValue(nomeFile, out foto))
                return foto;

            try
            {
                string percorso = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img_menu", nomeFile);
                using (Image originale = Image.FromFile(percorso))   // using: il file si chiude subito
                {
                    foto = new Bitmap(DimensioneFoto.Width, DimensioneFoto.Height);
                    using (Graphics g = Graphics.FromImage(foto))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(originale, 0, 0, DimensioneFoto.Width, DimensioneFoto.Height);
                    }
                }
            }
            catch (Exception)
            {
                foto = null;   // foto mancante o rovinata: il piatto resta senza foto
            }

            _immagini[nomeFile] = foto;
            return foto;
        }

        private static void SvuotaPannello(Control pannello)
        {
            while (pannello.Controls.Count > 0)
                pannello.Controls[0].Dispose(); // Dispose lo toglie anche dal pannello
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

            // dopo aver ricostruito la lista rimetto la selezione, cosi' + e - si possono premere piu' volte
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
            ordine.Righe = new List<RigaOrdine>(_carrello);   // copia della lista: dopo l'invio il carrello si svuota

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
            item.SubItems.Add("");
            item.Tag = idOrdine;
            MostraStato(item, StatoOrdine.Inviato);
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

                MostraStato(item, stato);

                if (stato == StatoOrdine.Pronto)
                    MostraBanner("Il tuo ordine è pronto!");
                else if (stato == StatoOrdine.Servito)
                    MostraBanner("Il tuo ordine sta arrivando al tavolo!");
                else if (stato == StatoOrdine.Annullato)
                    MostraBanner("L'ordine è stato annullato dalla cucina.");
                return;
            }
        }

        // Scrive il nome dello stato nella terza colonna e colora la riga.
        private static void MostraStato(ListViewItem item, StatoOrdine stato)
        {
            switch (stato)
            {
                case StatoOrdine.InPreparazione:
                    item.SubItems[2].Text = "In preparazione";
                    item.BackColor = Color.LemonChiffon;
                    break;
                case StatoOrdine.Pronto:
                    item.SubItems[2].Text = "Pronto";
                    item.BackColor = Color.LightGreen;
                    break;
                case StatoOrdine.Servito:
                    item.SubItems[2].Text = "Servito";
                    item.BackColor = Color.LightGray;
                    break;
                case StatoOrdine.Annullato:
                    item.SubItems[2].Text = "Annullato";
                    item.BackColor = Color.MistyRose;
                    break;
                default:
                    item.SubItems[2].Text = "Inviato";
                    item.BackColor = Color.White;
                    break;
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

            foreach (Image foto in _immagini.Values)
            {
                if (foto != null)
                    foto.Dispose();
            }
        }
    }
}
