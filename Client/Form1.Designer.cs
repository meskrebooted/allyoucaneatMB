namespace Client
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelCentro = new System.Windows.Forms.Panel();
            this.flowPiatti = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBanner = new System.Windows.Forms.Label();
            this.flowCategorie = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDestra = new System.Windows.Forms.Panel();
            this.lvCarrello = new System.Windows.Forms.ListView();
            this.colCarrelloPiatto = new System.Windows.Forms.ColumnHeader();
            this.colCarrelloQta = new System.Windows.Forms.ColumnHeader();
            this.panelAzioni = new System.Windows.Forms.Panel();
            this.btnPiu = new System.Windows.Forms.Button();
            this.btnMeno = new System.Windows.Forms.Button();
            this.btnRimuovi = new System.Windows.Forms.Button();
            this.lblTotale = new System.Windows.Forms.Label();
            this.btnInvia = new System.Windows.Forms.Button();
            this.panelOrdiniInviati = new System.Windows.Forms.Panel();
            this.lvOrdini = new System.Windows.Forms.ListView();
            this.colOrdOra = new System.Windows.Forms.ColumnHeader();
            this.colOrdPiatti = new System.Windows.Forms.ColumnHeader();
            this.colOrdStato = new System.Windows.Forms.ColumnHeader();
            this.lblInviati = new System.Windows.Forms.Label();
            this.lblCarrello = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.btnConnetti = new System.Windows.Forms.Button();
            this.btnDisconnetti = new System.Windows.Forms.Button();
            this.timerBanner = new System.Windows.Forms.Timer(this.components);
            this.panelCentro.SuspendLayout();
            this.panelDestra.SuspendLayout();
            this.panelAzioni.SuspendLayout();
            this.panelOrdiniInviati.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            //
            // panelCentro
            //
            this.panelCentro.BackColor = System.Drawing.Color.FromArgb(250, 246, 240);
            this.panelCentro.Controls.Add(this.flowPiatti);
            this.panelCentro.Controls.Add(this.lblBanner);
            this.panelCentro.Controls.Add(this.flowCategorie);
            this.panelCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentro.Location = new System.Drawing.Point(0, 80);
            this.panelCentro.Name = "panelCentro";
            this.panelCentro.Size = new System.Drawing.Size(920, 720);
            this.panelCentro.TabIndex = 0;
            //
            // flowPiatti
            //
            this.flowPiatti.AutoScroll = true;
            this.flowPiatti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPiatti.Location = new System.Drawing.Point(0, 62);
            this.flowPiatti.Name = "flowPiatti";
            this.flowPiatti.Padding = new System.Windows.Forms.Padding(8);
            this.flowPiatti.Size = new System.Drawing.Size(920, 610);
            this.flowPiatti.TabIndex = 0;
            //
            // lblBanner
            //
            this.lblBanner.BackColor = System.Drawing.Color.FromArgb(200, 240, 210);
            this.lblBanner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBanner.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanner.ForeColor = System.Drawing.Color.FromArgb(20, 90, 50);
            this.lblBanner.Location = new System.Drawing.Point(0, 672);
            this.lblBanner.Name = "lblBanner";
            this.lblBanner.Size = new System.Drawing.Size(920, 48);
            this.lblBanner.TabIndex = 1;
            this.lblBanner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBanner.Visible = false;
            //
            // flowCategorie
            //
            this.flowCategorie.AutoScroll = true;
            this.flowCategorie.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowCategorie.Location = new System.Drawing.Point(0, 0);
            this.flowCategorie.Name = "flowCategorie";
            this.flowCategorie.Padding = new System.Windows.Forms.Padding(12, 10, 12, 0);
            this.flowCategorie.Size = new System.Drawing.Size(920, 62);
            this.flowCategorie.TabIndex = 2;
            this.flowCategorie.WrapContents = false;
            //
            // panelDestra
            //
            this.panelDestra.BackColor = System.Drawing.Color.White;
            this.panelDestra.Controls.Add(this.lvCarrello);
            this.panelDestra.Controls.Add(this.panelAzioni);
            this.panelDestra.Controls.Add(this.panelOrdiniInviati);
            this.panelDestra.Controls.Add(this.lblCarrello);
            this.panelDestra.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDestra.Location = new System.Drawing.Point(920, 80);
            this.panelDestra.Name = "panelDestra";
            this.panelDestra.Size = new System.Drawing.Size(360, 720);
            this.panelDestra.TabIndex = 1;
            //
            // lvCarrello
            //
            this.lvCarrello.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvCarrello.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCarrelloPiatto,
            this.colCarrelloQta});
            this.lvCarrello.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCarrello.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCarrello.FullRowSelect = true;
            this.lvCarrello.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCarrello.HideSelection = false;
            this.lvCarrello.Location = new System.Drawing.Point(0, 44);
            this.lvCarrello.MultiSelect = false;
            this.lvCarrello.Name = "lvCarrello";
            this.lvCarrello.Size = new System.Drawing.Size(360, 294);
            this.lvCarrello.TabIndex = 0;
            this.lvCarrello.UseCompatibleStateImageBehavior = false;
            this.lvCarrello.View = System.Windows.Forms.View.Details;
            this.lvCarrello.SelectedIndexChanged += new System.EventHandler(this.lvCarrello_SelectedIndexChanged);
            //
            // colCarrelloPiatto
            //
            this.colCarrelloPiatto.Text = "Piatto";
            this.colCarrelloPiatto.Width = 240;
            //
            // colCarrelloQta
            //
            this.colCarrelloQta.Text = "Qtà";
            this.colCarrelloQta.Width = 80;
            //
            // panelAzioni
            //
            this.panelAzioni.Controls.Add(this.btnPiu);
            this.panelAzioni.Controls.Add(this.btnMeno);
            this.panelAzioni.Controls.Add(this.btnRimuovi);
            this.panelAzioni.Controls.Add(this.lblTotale);
            this.panelAzioni.Controls.Add(this.btnInvia);
            this.panelAzioni.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAzioni.Location = new System.Drawing.Point(0, 338);
            this.panelAzioni.Name = "panelAzioni";
            this.panelAzioni.Size = new System.Drawing.Size(360, 132);
            this.panelAzioni.TabIndex = 1;
            //
            // btnPiu
            //
            this.btnPiu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPiu.Location = new System.Drawing.Point(10, 8);
            this.btnPiu.Name = "btnPiu";
            this.btnPiu.Size = new System.Drawing.Size(105, 38);
            this.btnPiu.TabIndex = 0;
            this.btnPiu.Text = "+";
            this.btnPiu.UseVisualStyleBackColor = true;
            this.btnPiu.Click += new System.EventHandler(this.btnPiu_Click);
            //
            // btnMeno
            //
            this.btnMeno.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeno.Location = new System.Drawing.Point(125, 8);
            this.btnMeno.Name = "btnMeno";
            this.btnMeno.Size = new System.Drawing.Size(105, 38);
            this.btnMeno.TabIndex = 1;
            this.btnMeno.Text = "-";
            this.btnMeno.UseVisualStyleBackColor = true;
            this.btnMeno.Click += new System.EventHandler(this.btnMeno_Click);
            //
            // btnRimuovi
            //
            this.btnRimuovi.Location = new System.Drawing.Point(240, 8);
            this.btnRimuovi.Name = "btnRimuovi";
            this.btnRimuovi.Size = new System.Drawing.Size(110, 38);
            this.btnRimuovi.TabIndex = 2;
            this.btnRimuovi.Text = "Rimuovi";
            this.btnRimuovi.UseVisualStyleBackColor = true;
            this.btnRimuovi.Click += new System.EventHandler(this.btnRimuovi_Click);
            //
            // lblTotale
            //
            this.lblTotale.AutoSize = true;
            this.lblTotale.Location = new System.Drawing.Point(12, 54);
            this.lblTotale.Name = "lblTotale";
            this.lblTotale.Size = new System.Drawing.Size(150, 19);
            this.lblTotale.TabIndex = 3;
            this.lblTotale.Text = "Piatti nel carrello: 0";
            //
            // btnInvia
            //
            this.btnInvia.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
            this.btnInvia.Enabled = false;
            this.btnInvia.FlatAppearance.BorderSize = 0;
            this.btnInvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvia.ForeColor = System.Drawing.Color.White;
            this.btnInvia.Location = new System.Drawing.Point(10, 82);
            this.btnInvia.Name = "btnInvia";
            this.btnInvia.Size = new System.Drawing.Size(340, 44);
            this.btnInvia.TabIndex = 4;
            this.btnInvia.Text = "INVIA ORDINE";
            this.btnInvia.UseVisualStyleBackColor = false;
            this.btnInvia.Click += new System.EventHandler(this.btnInvia_Click);
            //
            // panelOrdiniInviati
            //
            this.panelOrdiniInviati.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelOrdiniInviati.Controls.Add(this.lvOrdini);
            this.panelOrdiniInviati.Controls.Add(this.lblInviati);
            this.panelOrdiniInviati.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOrdiniInviati.Location = new System.Drawing.Point(0, 470);
            this.panelOrdiniInviati.Name = "panelOrdiniInviati";
            this.panelOrdiniInviati.Size = new System.Drawing.Size(360, 250);
            this.panelOrdiniInviati.TabIndex = 2;
            //
            // lvOrdini
            //
            this.lvOrdini.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOrdini.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrdOra,
            this.colOrdPiatti,
            this.colOrdStato});
            this.lvOrdini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOrdini.FullRowSelect = true;
            this.lvOrdini.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvOrdini.Location = new System.Drawing.Point(0, 34);
            this.lvOrdini.MultiSelect = false;
            this.lvOrdini.Name = "lvOrdini";
            this.lvOrdini.Size = new System.Drawing.Size(360, 216);
            this.lvOrdini.TabIndex = 0;
            this.lvOrdini.UseCompatibleStateImageBehavior = false;
            this.lvOrdini.View = System.Windows.Forms.View.Details;
            //
            // colOrdOra
            //
            this.colOrdOra.Text = "Ora";
            this.colOrdOra.Width = 60;
            //
            // colOrdPiatti
            //
            this.colOrdPiatti.Text = "Piatti";
            this.colOrdPiatti.Width = 170;
            //
            // colOrdStato
            //
            this.colOrdStato.Text = "Stato";
            this.colOrdStato.Width = 110;
            //
            // lblInviati
            //
            this.lblInviati.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInviati.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInviati.Location = new System.Drawing.Point(0, 0);
            this.lblInviati.Name = "lblInviati";
            this.lblInviati.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblInviati.Size = new System.Drawing.Size(360, 34);
            this.lblInviati.TabIndex = 1;
            this.lblInviati.Text = "ORDINI INVIATI";
            this.lblInviati.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblCarrello
            //
            this.lblCarrello.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCarrello.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrello.Location = new System.Drawing.Point(0, 0);
            this.lblCarrello.Name = "lblCarrello";
            this.lblCarrello.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblCarrello.Size = new System.Drawing.Size(360, 44);
            this.lblCarrello.TabIndex = 3;
            this.lblCarrello.Text = "IL TUO ORDINE";
            this.lblCarrello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.panelTop.Controls.Add(this.lblTitolo);
            this.panelTop.Controls.Add(this.lblStato);
            this.panelTop.Controls.Add(this.lblIp);
            this.panelTop.Controls.Add(this.txtIp);
            this.panelTop.Controls.Add(this.btnConnetti);
            this.panelTop.Controls.Add(this.btnDisconnetti);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1280, 80);
            this.panelTop.TabIndex = 2;
            //
            // lblTitolo
            //
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.Color.White;
            this.lblTitolo.Location = new System.Drawing.Point(18, 8);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(330, 32);
            this.lblTitolo.Text = "SUSHI ALL YOU CAN EAT";
            //
            // lblStato
            //
            this.lblStato.AutoSize = true;
            this.lblStato.ForeColor = System.Drawing.Color.Silver;
            this.lblStato.Location = new System.Drawing.Point(22, 48);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(90, 19);
            this.lblStato.Text = "Non connesso";
            //
            // lblIp
            //
            this.lblIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIp.AutoSize = true;
            this.lblIp.ForeColor = System.Drawing.Color.White;
            this.lblIp.Location = new System.Drawing.Point(830, 31);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(65, 19);
            this.lblIp.Text = "IP server";
            //
            // txtIp
            //
            this.txtIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIp.Location = new System.Drawing.Point(905, 28);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(135, 25);
            this.txtIp.TabIndex = 0;
            this.txtIp.Text = "127.0.0.1";
            //
            // btnConnetti
            //
            this.btnConnetti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnetti.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnConnetti.FlatAppearance.BorderSize = 0;
            this.btnConnetti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnetti.ForeColor = System.Drawing.Color.White;
            this.btnConnetti.Location = new System.Drawing.Point(1050, 22);
            this.btnConnetti.Name = "btnConnetti";
            this.btnConnetti.Size = new System.Drawing.Size(100, 36);
            this.btnConnetti.TabIndex = 1;
            this.btnConnetti.Text = "Connetti";
            this.btnConnetti.UseVisualStyleBackColor = false;
            this.btnConnetti.Click += new System.EventHandler(this.btnConnetti_Click);
            //
            // btnDisconnetti
            //
            this.btnDisconnetti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconnetti.BackColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.btnDisconnetti.FlatAppearance.BorderSize = 0;
            this.btnDisconnetti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnetti.ForeColor = System.Drawing.Color.White;
            this.btnDisconnetti.Location = new System.Drawing.Point(1160, 22);
            this.btnDisconnetti.Name = "btnDisconnetti";
            this.btnDisconnetti.Size = new System.Drawing.Size(100, 36);
            this.btnDisconnetti.TabIndex = 2;
            this.btnDisconnetti.Text = "Disconnetti";
            this.btnDisconnetti.UseVisualStyleBackColor = false;
            this.btnDisconnetti.Click += new System.EventHandler(this.btnDisconnetti_Click);
            //
            // timerBanner
            //
            this.timerBanner.Interval = 8000;
            this.timerBanner.Tick += new System.EventHandler(this.timerBanner_Tick);
            //
            // Form1
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(250, 246, 240);
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelCentro);
            this.Controls.Add(this.panelDestra);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tablet - All You Can Eat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelCentro.ResumeLayout(false);
            this.panelDestra.ResumeLayout(false);
            this.panelAzioni.ResumeLayout(false);
            this.panelAzioni.PerformLayout();
            this.panelOrdiniInviati.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCentro;
        private System.Windows.Forms.FlowLayoutPanel flowPiatti;
        private System.Windows.Forms.Label lblBanner;
        private System.Windows.Forms.FlowLayoutPanel flowCategorie;
        private System.Windows.Forms.Panel panelDestra;
        private System.Windows.Forms.ListView lvCarrello;
        private System.Windows.Forms.ColumnHeader colCarrelloPiatto;
        private System.Windows.Forms.ColumnHeader colCarrelloQta;
        private System.Windows.Forms.Panel panelAzioni;
        private System.Windows.Forms.Button btnPiu;
        private System.Windows.Forms.Button btnMeno;
        private System.Windows.Forms.Button btnRimuovi;
        private System.Windows.Forms.Label lblTotale;
        private System.Windows.Forms.Button btnInvia;
        private System.Windows.Forms.Panel panelOrdiniInviati;
        private System.Windows.Forms.ListView lvOrdini;
        private System.Windows.Forms.ColumnHeader colOrdOra;
        private System.Windows.Forms.ColumnHeader colOrdPiatti;
        private System.Windows.Forms.ColumnHeader colOrdStato;
        private System.Windows.Forms.Label lblInviati;
        private System.Windows.Forms.Label lblCarrello;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Button btnConnetti;
        private System.Windows.Forms.Button btnDisconnetti;
        private System.Windows.Forms.Timer timerBanner;
    }
}