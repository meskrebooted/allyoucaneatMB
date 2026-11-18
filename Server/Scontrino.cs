using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace allyoucaneat
{
    // Scontrino di un ordine: tavolo, ora, piatti, stato e tre pulsanti (in preparazione / servito / cancella).
    // Il controllo non parla con il server: avvisa la form con gli eventi e la form decide cosa fare.
    // E' un FlowLayoutPanel: i controlli si dispongono da soli uno sotto l'altro, senza calcolare le posizioni.
    public class Scontrino : FlowLayoutPanel
    {
        private const int Larghezza = 220;   // larghezza dei controlli interni

        private static readonly Color ColoreInPreparazione = Color.FromArgb(212, 160, 23);
        private static readonly Color ColoreServito = Color.FromArgb(120, 120, 120);
        private static readonly Color ColoreCancella = Color.FromArgb(200, 40, 40);

        private readonly Label _lblStato;
        private readonly Button _btnInPreparazione;
        private readonly Button _btnServito;
        private readonly Button _btnCancella;

        public Ordine Ordine { get; private set; }
        public bool Servito { get { return Ordine.Stato == StatoOrdine.Servito; } }

        // La form si iscrive a questi eventi per cambiare lo stato / cancellare l'ordine.
        public event Action<Scontrino, StatoOrdine> CambioStatoRichiesto;
        public event Action<Scontrino> CancellaRichiesto;

        public Scontrino(Ordine ordine)
        {
            Ordine = ordine;

            FlowDirection = FlowDirection.TopDown;
            WrapContents = false;
            AutoSize = true;                       // l'altezza si adatta al contenuto
            Padding = new Padding(10);
            Margin = new Padding(8);
            BorderStyle = BorderStyle.FixedSingle;

            // Intestazione
            Controls.Add(CreaLabel("TAVOLO " + ordine.Tavolo, new Font("Consolas", 16F, FontStyle.Bold)));
            Controls.Add(CreaLabel("Ore " + ordine.Ora.ToString("HH:mm:ss"), new Font("Consolas", 9F)));
            Controls.Add(CreaSeparatore());

            // Una riga per piatto, a capo automatico se il nome e' lungo
            Label lblPiatti = new Label();
            lblPiatti.Text = string.Join(Environment.NewLine, ordine.Righe.Select(r => r.Quantita + "x " + r.NomePiatto));
            lblPiatti.Font = new Font("Consolas", 10F);
            lblPiatti.AutoSize = true;
            lblPiatti.MaximumSize = new Size(Larghezza, 0);
            lblPiatti.UseMnemonic = false;         // un '&' nel nome del piatto non deve diventare una scorciatoia
            Controls.Add(lblPiatti);
            Controls.Add(CreaSeparatore());

            // Stato e pulsanti
            _lblStato = CreaLabel("", new Font("Consolas", 10F, FontStyle.Bold));
            Controls.Add(_lblStato);

            _btnInPreparazione = CreaPulsante("IN PREPARAZIONE", () => RichiediStato(StatoOrdine.InPreparazione));
            _btnServito = CreaPulsante("SERVITO", () => RichiediStato(StatoOrdine.Servito));
            _btnCancella = CreaPulsante("CANCELLA ORDINE", () => { if (CancellaRichiesto != null) CancellaRichiesto(this); });

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
                    break;
                case StatoOrdine.Servito:
                    BackColor = Color.FromArgb(232, 232, 232);
                    _lblStato.Text = "SERVITO";
                    break;
                case StatoOrdine.Annullato:
                    BackColor = Color.FromArgb(250, 225, 225);
                    _lblStato.Text = "ANNULLATO";
                    break;
                default:
                    BackColor = Color.White;
                    _lblStato.Text = "DA PREPARARE";
                    break;
            }

            // Lo scontrino e' "attivo" finche' non e' servito o annullato.
            bool attivo = stato != StatoOrdine.Servito && stato != StatoOrdine.Annullato;
            ImpostaPulsante(_btnInPreparazione, attivo && stato != StatoOrdine.InPreparazione, ColoreInPreparazione);
            ImpostaPulsante(_btnServito, attivo, ColoreServito);
            ImpostaPulsante(_btnCancella, attivo, ColoreCancella);
        }

        private void RichiediStato(StatoOrdine stato)
        {
            if (CambioStatoRichiesto != null)
                CambioStatoRichiesto(this, stato);
        }

        // ---------- Piccoli metodi per creare i controlli ----------

        private static Label CreaLabel(string testo, Font font)
        {
            Label l = new Label();
            l.Text = testo;
            l.Font = font;
            l.AutoSize = false;
            l.Size = new Size(Larghezza, font.Height + 6);
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.UseMnemonic = false;
            return l;
        }

        // Linea sottile che divide le sezioni dello scontrino.
        private static Label CreaSeparatore()
        {
            Label l = new Label();
            l.AutoSize = false;
            l.Size = new Size(Larghezza, 2);
            l.BorderStyle = BorderStyle.Fixed3D;
            return l;
        }

        private Button CreaPulsante(string testo, Action alClick)
        {
            Button b = new Button();
            b.Text = testo;
            b.Size = new Size(Larghezza, 36);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            b.UseVisualStyleBackColor = false;
            b.Click += (s, e) => alClick();
            Controls.Add(b);
            return b;
        }

        private static void ImpostaPulsante(Button b, bool abilitato, Color colore)
        {
            b.Enabled = abilitato;
            b.BackColor = abilitato ? colore : Color.FromArgb(215, 215, 215);
            b.ForeColor = abilitato ? Color.White : Color.FromArgb(150, 150, 150);
        }
    }
}
