using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace allyoucaneat
{
    // Scontrino di un ordine: tavolo, ora, piatti e i tre pulsanti (in preparazione / servito / cancella).
    // Il controllo non parla con il server: avvisa la form con gli eventi e la form decide cosa fare.
    public class Scontrino : Panel
    {
        private const int Larghezza = 250;
        private const int Margine = 14;
        private const int RaggioAngoli = 16;

        private static readonly Color ColoreInPreparazione = Color.FromArgb(212, 160, 23);
        private static readonly Color ColoreServito = Color.FromArgb(120, 120, 120);
        private static readonly Color ColoreCancella = Color.FromArgb(200, 40, 40);
        private static readonly Color ColoreDisabilitato = Color.FromArgb(215, 215, 215);

        private readonly Label _lblStato = new Label();
        private readonly Button _btnInPreparazione = new Button();
        private readonly Button _btnServito = new Button();
        private readonly Button _btnCancella = new Button();

        public Ordine Ordine { get; private set; }

        // La form si iscrive a questi eventi per cambiare lo stato / cancellare l'ordine.
        public event Action<Scontrino, StatoOrdine> CambioStatoRichiesto;
        public event Action<Scontrino> CancellaRichiesto;

        public bool Servito { get { return Ordine.Stato == StatoOrdine.Servito; } }

        public Scontrino(Ordine ordine)
        {
            Ordine = ordine;

            DoubleBuffered = true;
            Margin = new Padding(8, 4, 8, 8);
            Width = Larghezza;

            int y = Margine;
            int larghezzaInterna = Larghezza - 2 * Margine;

            // Intestazione: tavolo e ora
            Label lblTavolo = CreaLabel("TAVOLO " + ordine.Tavolo, new Font("Consolas", 16F, FontStyle.Bold),
                Margine, y, larghezzaInterna, ContentAlignment.MiddleCenter);
            lblTavolo.Height = 30;
            Controls.Add(lblTavolo);
            y += lblTavolo.Height;

            Label lblOra = CreaLabel("Ore " + ordine.Ora.ToString("HH:mm:ss"), new Font("Consolas", 9F),
                Margine, y, larghezzaInterna, ContentAlignment.MiddleCenter);
            lblOra.Height = 20;
            Controls.Add(lblOra);
            y += lblOra.Height + 4;

            y = AggiungiSeparatore(y, larghezzaInterna);

            // Righe dell'ordine: quantita' a sinistra, nome del piatto a destra (va a capo se e' lungo)
            Font fontRiga = new Font("Consolas", 10F);
            Font fontQta = new Font("Consolas", 10F, FontStyle.Bold);
            const int larghezzaQta = 38;
            foreach (RigaOrdine r in ordine.Righe)
            {
                string nome = r.NomePiatto ?? "";
                int larghezzaNome = larghezzaInterna - larghezzaQta;
                int altezza = TextRenderer.MeasureText(nome, fontRiga, new Size(larghezzaNome, 0),
                    TextFormatFlags.WordBreak | TextFormatFlags.NoPadding).Height + 6;

                Label lblQta = CreaLabel(r.Quantita + "x", fontQta, Margine, y, larghezzaQta, ContentAlignment.TopLeft);
                lblQta.Height = altezza;
                Controls.Add(lblQta);

                Label lblNome = CreaLabel(nome, fontRiga, Margine + larghezzaQta, y, larghezzaNome, ContentAlignment.TopLeft);
                lblNome.Height = altezza;
                Controls.Add(lblNome);

                y += altezza;
            }

            y += 2;
            y = AggiungiSeparatore(y, larghezzaInterna);

            // Stato corrente
            _lblStato.AutoSize = false;
            _lblStato.Font = new Font("Consolas", 10F, FontStyle.Bold);
            _lblStato.TextAlign = ContentAlignment.MiddleCenter;
            _lblStato.SetBounds(Margine, y, larghezzaInterna, 26);
            Controls.Add(_lblStato);
            y += _lblStato.Height + 6;

            // Pulsanti (giallo / grigio / rosso)
            y = AggiungiPulsante(_btnInPreparazione, "IN PREPARAZIONE", y, larghezzaInterna, ColoreInPreparazione,
                (s, e) => RichiediStato(StatoOrdine.InPreparazione));
            y = AggiungiPulsante(_btnServito, "SERVITO", y, larghezzaInterna, ColoreServito,
                (s, e) => RichiediStato(StatoOrdine.Servito));
            y = AggiungiPulsante(_btnCancella, "CANCELLA ORDINE", y, larghezzaInterna, ColoreCancella,
                (s, e) => { if (CancellaRichiesto != null) CancellaRichiesto(this); });

            Height = y + Margine - 4;

            Aggiorna();
        }

        // Da chiamare dopo ogni cambio di stato: aggiorna colore, testo e pulsanti attivi.
        public void Aggiorna()
        {
            StatoOrdine stato = Ordine.Stato;

            switch (stato)
            {
                case StatoOrdine.InPreparazione:
                    BackColor = Color.FromArgb(255, 247, 214);
                    _lblStato.Text = "IN PREPARAZIONE";
                    _lblStato.ForeColor = Color.FromArgb(150, 105, 0);
                    break;
                case StatoOrdine.Servito:
                    BackColor = Color.FromArgb(232, 232, 232);
                    _lblStato.Text = "SERVITO";
                    _lblStato.ForeColor = Color.FromArgb(90, 90, 90);
                    break;
                case StatoOrdine.Annullato:
                    BackColor = Color.FromArgb(250, 225, 225);
                    _lblStato.Text = "ANNULLATO";
                    _lblStato.ForeColor = ColoreCancella;
                    break;
                default:
                    BackColor = Color.White;
                    _lblStato.Text = "DA PREPARARE";
                    _lblStato.ForeColor = Color.FromArgb(60, 60, 60);
                    break;
            }

            bool attivo = stato != StatoOrdine.Servito && stato != StatoOrdine.Annullato;
            ImpostaPulsante(_btnInPreparazione, attivo && stato != StatoOrdine.InPreparazione, ColoreInPreparazione);
            ImpostaPulsante(_btnServito, attivo, ColoreServito);
            ImpostaPulsante(_btnCancella, attivo, ColoreCancella);

            Invalidate();
        }

        private void RichiediStato(StatoOrdine stato)
        {
            if (CambioStatoRichiesto != null)
                CambioStatoRichiesto(this, stato);
        }

        // ---------- Costruzione del controllo ----------

        private static Label CreaLabel(string testo, Font font, int x, int y, int larghezza, ContentAlignment allineamento)
        {
            Label l = new Label();
            l.AutoSize = false;
            l.Text = testo;
            l.Font = font;
            l.TextAlign = allineamento;
            l.UseMnemonic = false; // un '&' nel nome del piatto non deve diventare una scorciatoia
            l.SetBounds(x, y, larghezza, 20);
            return l;
        }

        // Linea tratteggiata come negli scontrini veri.
        private int AggiungiSeparatore(int y, int larghezza)
        {
            Separatore s = new Separatore();
            s.SetBounds(Margine, y, larghezza, 10);
            Controls.Add(s);
            return y + s.Height;
        }

        private int AggiungiPulsante(Button b, string testo, int y, int larghezza, Color colore, EventHandler click)
        {
            b.Text = testo;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            b.ForeColor = Color.White;
            b.BackColor = colore;
            b.UseVisualStyleBackColor = false;
            b.Cursor = Cursors.Hand;
            b.SetBounds(Margine, y, larghezza, 36);
            b.Click += click;
            Controls.Add(b);
            return y + b.Height + 6;
        }

        private static void ImpostaPulsante(Button b, bool abilitato, Color colore)
        {
            b.Enabled = abilitato;
            b.BackColor = abilitato ? colore : ColoreDisabilitato;
            b.ForeColor = abilitato ? Color.White : Color.FromArgb(150, 150, 150);
            b.Cursor = abilitato ? Cursors.Hand : Cursors.Default;
        }

        // ---------- Disegno: angoli arrotondati e bordo ----------

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (Width <= 0 || Height <= 0)
                return;

            using (GraphicsPath path = PathArrotondato(new Rectangle(0, 0, Width, Height), RaggioAngoli))
            {
                Region vecchia = Region;
                Region = new Region(path);
                if (vecchia != null)
                    vecchia.Dispose();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = PathArrotondato(new Rectangle(1, 1, Width - 3, Height - 3), RaggioAngoli))
            using (Pen penna = new Pen(Color.FromArgb(60, 60, 60), 2F))
            {
                e.Graphics.DrawPath(penna, path);
            }
        }

        private static GraphicsPath PathArrotondato(Rectangle r, int raggio)
        {
            int d = raggio * 2;
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        // Linea tratteggiata orizzontale.
        private class Separatore : Control
        {
            public Separatore()
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                BackColor = Color.Transparent;
                TabStop = false;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                using (Pen penna = new Pen(Color.FromArgb(120, 120, 120), 1F))
                {
                    penna.DashStyle = DashStyle.Dash;
                    int y = Height / 2;
                    e.Graphics.DrawLine(penna, 0, y, Width, y);
                }
            }
        }
    }
}
