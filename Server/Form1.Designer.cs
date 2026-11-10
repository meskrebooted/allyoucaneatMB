namespace allyoucaneat
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
            System.Windows.Forms.DataGridViewCellStyle stileIntestazione = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stileCelle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stileTavolo = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stileOra = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelCentro = new System.Windows.Forms.Panel();
            this.dgvOrdini = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTavolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPiatti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblOrdini = new System.Windows.Forms.Label();
            this.panelAzioni = new System.Windows.Forms.Panel();
            this.btnInPreparazione = new System.Windows.Forms.Button();
            this.btnPronto = new System.Windows.Forms.Button();
            this.btnServito = new System.Windows.Forms.Button();
            this.panelLog = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.btnAvvia = new System.Windows.Forms.Button();
            this.btnFerma = new System.Windows.Forms.Button();
            this.panelCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdini)).BeginInit();
            this.panelAzioni.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            //
            // panelCentro
            //
            this.panelCentro.BackColor = System.Drawing.Color.FromArgb(250, 246, 240);
            this.panelCentro.Controls.Add(this.dgvOrdini);
            this.panelCentro.Controls.Add(this.lblOrdini);
            this.panelCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentro.Location = new System.Drawing.Point(0, 80);
            this.panelCentro.Name = "panelCentro";
            this.panelCentro.Padding = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.panelCentro.Size = new System.Drawing.Size(1100, 386);
            this.panelCentro.TabIndex = 0;
            //
            // dgvOrdini
            //
            this.dgvOrdini.AllowUserToAddRows = false;
            this.dgvOrdini.AllowUserToDeleteRows = false;
            this.dgvOrdini.AllowUserToResizeRows = false;
            this.dgvOrdini.BackgroundColor = System.Drawing.Color.FromArgb(250, 246, 240);
            this.dgvOrdini.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdini.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrdini.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            stileIntestazione.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            stileIntestazione.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            stileIntestazione.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stileIntestazione.ForeColor = System.Drawing.Color.White;
            stileIntestazione.SelectionBackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            stileIntestazione.SelectionForeColor = System.Drawing.Color.White;
            stileIntestazione.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdini.ColumnHeadersDefaultCellStyle = stileIntestazione;
            this.dgvOrdini.ColumnHeadersHeight = 36;
            this.dgvOrdini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrdini.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTavolo,
            this.colOra,
            this.colPiatti,
            this.colStato});
            stileCelle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            stileCelle.BackColor = System.Drawing.Color.White;
            stileCelle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stileCelle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            stileCelle.SelectionBackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            stileCelle.SelectionForeColor = System.Drawing.Color.White;
            stileCelle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdini.DefaultCellStyle = stileCelle;
            this.dgvOrdini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdini.EnableHeadersVisualStyles = false;
            this.dgvOrdini.GridColor = System.Drawing.Color.FromArgb(220, 210, 200);
            this.dgvOrdini.Location = new System.Drawing.Point(12, 44);
            this.dgvOrdini.MultiSelect = false;
            this.dgvOrdini.Name = "dgvOrdini";
            this.dgvOrdini.ReadOnly = true;
            this.dgvOrdini.RowHeadersVisible = false;
            this.dgvOrdini.RowTemplate.Height = 34;
            this.dgvOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdini.Size = new System.Drawing.Size(1076, 330);
            this.dgvOrdini.TabIndex = 0;
            this.dgvOrdini.SelectionChanged += new System.EventHandler(this.dgvOrdini_SelectionChanged);
            //
            // colId
            //
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            //
            // colTavolo
            //
            stileTavolo.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            stileTavolo.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.colTavolo.DefaultCellStyle = stileTavolo;
            this.colTavolo.HeaderText = "Tavolo";
            this.colTavolo.Name = "colTavolo";
            this.colTavolo.ReadOnly = true;
            this.colTavolo.Width = 90;
            //
            // colOra
            //
            stileOra.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            stileOra.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.colOra.DefaultCellStyle = stileOra;
            this.colOra.HeaderText = "Ora";
            this.colOra.Name = "colOra";
            this.colOra.ReadOnly = true;
            this.colOra.Width = 110;
            //
            // colPiatti
            //
            this.colPiatti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPiatti.HeaderText = "Piatti";
            this.colPiatti.Name = "colPiatti";
            this.colPiatti.ReadOnly = true;
            //
            // colStato
            //
            this.colStato.HeaderText = "Stato";
            this.colStato.Name = "colStato";
            this.colStato.ReadOnly = true;
            this.colStato.Width = 150;
            //
            // lblOrdini
            //
            this.lblOrdini.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOrdini.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdini.Location = new System.Drawing.Point(12, 0);
            this.lblOrdini.Name = "lblOrdini";
            this.lblOrdini.Size = new System.Drawing.Size(1076, 44);
            this.lblOrdini.TabIndex = 1;
            this.lblOrdini.Text = "ORDINI IN ARRIVO";
            this.lblOrdini.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panelAzioni
            //
            this.panelAzioni.BackColor = System.Drawing.Color.White;
            this.panelAzioni.Controls.Add(this.btnInPreparazione);
            this.panelAzioni.Controls.Add(this.btnPronto);
            this.panelAzioni.Controls.Add(this.btnServito);
            this.panelAzioni.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAzioni.Location = new System.Drawing.Point(0, 466);
            this.panelAzioni.Name = "panelAzioni";
            this.panelAzioni.Size = new System.Drawing.Size(1100, 64);
            this.panelAzioni.TabIndex = 1;
            //
            // btnInPreparazione
            //
            this.btnInPreparazione.BackColor = System.Drawing.Color.FromArgb(212, 160, 23);
            this.btnInPreparazione.Enabled = false;
            this.btnInPreparazione.FlatAppearance.BorderSize = 0;
            this.btnInPreparazione.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInPreparazione.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInPreparazione.ForeColor = System.Drawing.Color.White;
            this.btnInPreparazione.Location = new System.Drawing.Point(12, 10);
            this.btnInPreparazione.Name = "btnInPreparazione";
            this.btnInPreparazione.Size = new System.Drawing.Size(190, 44);
            this.btnInPreparazione.TabIndex = 0;
            this.btnInPreparazione.Text = "IN PREPARAZIONE";
            this.btnInPreparazione.UseVisualStyleBackColor = false;
            this.btnInPreparazione.Click += new System.EventHandler(this.btnInPreparazione_Click);
            //
            // btnPronto
            //
            this.btnPronto.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
            this.btnPronto.Enabled = false;
            this.btnPronto.FlatAppearance.BorderSize = 0;
            this.btnPronto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPronto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPronto.ForeColor = System.Drawing.Color.White;
            this.btnPronto.Location = new System.Drawing.Point(212, 10);
            this.btnPronto.Name = "btnPronto";
            this.btnPronto.Size = new System.Drawing.Size(190, 44);
            this.btnPronto.TabIndex = 1;
            this.btnPronto.Text = "PRONTO";
            this.btnPronto.UseVisualStyleBackColor = false;
            this.btnPronto.Click += new System.EventHandler(this.btnPronto_Click);
            //
            // btnServito
            //
            this.btnServito.BackColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.btnServito.Enabled = false;
            this.btnServito.FlatAppearance.BorderSize = 0;
            this.btnServito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServito.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServito.ForeColor = System.Drawing.Color.White;
            this.btnServito.Location = new System.Drawing.Point(412, 10);
            this.btnServito.Name = "btnServito";
            this.btnServito.Size = new System.Drawing.Size(190, 44);
            this.btnServito.TabIndex = 2;
            this.btnServito.Text = "SERVITO";
            this.btnServito.UseVisualStyleBackColor = false;
            this.btnServito.Click += new System.EventHandler(this.btnServito_Click);
            //
            // panelLog
            //
            this.panelLog.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelLog.Controls.Add(this.txtLog);
            this.panelLog.Controls.Add(this.lblLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Location = new System.Drawing.Point(0, 530);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(1100, 170);
            this.panelLog.TabIndex = 2;
            //
            // txtLog
            //
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.txtLog.Location = new System.Drawing.Point(0, 34);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1100, 136);
            this.txtLog.TabIndex = 0;
            //
            // lblLog
            //
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLog.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(0, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblLog.Size = new System.Drawing.Size(1100, 34);
            this.lblLog.TabIndex = 1;
            this.lblLog.Text = "LOG";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.panelTop.Controls.Add(this.lblTitolo);
            this.panelTop.Controls.Add(this.lblStato);
            this.panelTop.Controls.Add(this.btnAvvia);
            this.panelTop.Controls.Add(this.btnFerma);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 80);
            this.panelTop.TabIndex = 3;
            //
            // lblTitolo
            //
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.Color.White;
            this.lblTitolo.Location = new System.Drawing.Point(18, 8);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(460, 32);
            this.lblTitolo.Text = "CUCINA - SUSHI ALL YOU CAN EAT";
            //
            // lblStato
            //
            this.lblStato.AutoSize = true;
            this.lblStato.ForeColor = System.Drawing.Color.Silver;
            this.lblStato.Location = new System.Drawing.Point(22, 48);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(90, 19);
            this.lblStato.Text = "Server fermato";
            //
            // btnAvvia
            //
            this.btnAvvia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvvia.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnAvvia.FlatAppearance.BorderSize = 0;
            this.btnAvvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvvia.ForeColor = System.Drawing.Color.White;
            this.btnAvvia.Location = new System.Drawing.Point(860, 22);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(110, 36);
            this.btnAvvia.TabIndex = 0;
            this.btnAvvia.Text = "Avvia server";
            this.btnAvvia.UseVisualStyleBackColor = false;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            //
            // btnFerma
            //
            this.btnFerma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFerma.BackColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.btnFerma.FlatAppearance.BorderSize = 0;
            this.btnFerma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFerma.ForeColor = System.Drawing.Color.White;
            this.btnFerma.Location = new System.Drawing.Point(980, 22);
            this.btnFerma.Name = "btnFerma";
            this.btnFerma.Size = new System.Drawing.Size(110, 36);
            this.btnFerma.TabIndex = 1;
            this.btnFerma.Text = "Ferma server";
            this.btnFerma.UseVisualStyleBackColor = false;
            this.btnFerma.Click += new System.EventHandler(this.btnFerma_Click);
            //
            // Form1
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(250, 246, 240);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelCentro);
            this.Controls.Add(this.panelAzioni);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cucina - All You Can Eat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelCentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdini)).EndInit();
            this.panelAzioni.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCentro;
        private System.Windows.Forms.DataGridView dgvOrdini;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTavolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPiatti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStato;
        private System.Windows.Forms.Label lblOrdini;
        private System.Windows.Forms.Panel panelAzioni;
        private System.Windows.Forms.Button btnInPreparazione;
        private System.Windows.Forms.Button btnPronto;
        private System.Windows.Forms.Button btnServito;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.Button btnAvvia;
        private System.Windows.Forms.Button btnFerma;
    }
}
