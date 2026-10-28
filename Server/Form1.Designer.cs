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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblPorta = new System.Windows.Forms.Label();
            this.numPorta = new System.Windows.Forms.NumericUpDown();
            this.btnAvvia = new System.Windows.Forms.Button();
            this.btnFerma = new System.Windows.Forms.Button();
            this.lblStato = new System.Windows.Forms.Label();
            this.dgvOrdini = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTavolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPiatti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelAzioni = new System.Windows.Forms.Panel();
            this.btnInPreparazione = new System.Windows.Forms.Button();
            this.btnPronto = new System.Windows.Forms.Button();
            this.btnServito = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdini)).BeginInit();
            this.panelAzioni.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.Controls.Add(this.lblPorta);
            this.panelTop.Controls.Add(this.numPorta);
            this.panelTop.Controls.Add(this.btnAvvia);
            this.panelTop.Controls.Add(this.btnFerma);
            this.panelTop.Controls.Add(this.lblStato);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 56);
            this.panelTop.TabIndex = 3;
            //
            // lblPorta
            //
            this.lblPorta.AutoSize = true;
            this.lblPorta.Location = new System.Drawing.Point(12, 20);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(37, 16);
            this.lblPorta.Text = "Porta";
            //
            // numPorta
            //
            this.numPorta.Location = new System.Drawing.Point(60, 17);
            this.numPorta.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.numPorta.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            this.numPorta.Name = "numPorta";
            this.numPorta.Size = new System.Drawing.Size(80, 22);
            this.numPorta.TabIndex = 0;
            this.numPorta.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            //
            // btnAvvia
            //
            this.btnAvvia.Location = new System.Drawing.Point(160, 11);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(110, 34);
            this.btnAvvia.TabIndex = 1;
            this.btnAvvia.Text = "Avvia server";
            this.btnAvvia.UseVisualStyleBackColor = true;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            //
            // btnFerma
            //
            this.btnFerma.Location = new System.Drawing.Point(280, 11);
            this.btnFerma.Name = "btnFerma";
            this.btnFerma.Size = new System.Drawing.Size(110, 34);
            this.btnFerma.TabIndex = 2;
            this.btnFerma.Text = "Ferma server";
            this.btnFerma.UseVisualStyleBackColor = true;
            this.btnFerma.Click += new System.EventHandler(this.btnFerma_Click);
            //
            // lblStato
            //
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(410, 20);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(100, 16);
            this.lblStato.Text = "Server fermato";
            //
            // dgvOrdini
            //
            this.dgvOrdini.AllowUserToAddRows = false;
            this.dgvOrdini.AllowUserToDeleteRows = false;
            this.dgvOrdini.AllowUserToResizeRows = false;
            this.dgvOrdini.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOrdini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdini.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTavolo,
            this.colOra,
            this.colPiatti,
            this.colStato});
            this.dgvOrdini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdini.Location = new System.Drawing.Point(0, 56);
            this.dgvOrdini.MultiSelect = false;
            this.dgvOrdini.Name = "dgvOrdini";
            this.dgvOrdini.ReadOnly = true;
            this.dgvOrdini.RowHeadersVisible = false;
            this.dgvOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdini.Size = new System.Drawing.Size(1000, 394);
            this.dgvOrdini.TabIndex = 0;
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
            this.colTavolo.HeaderText = "Tavolo";
            this.colTavolo.Name = "colTavolo";
            this.colTavolo.ReadOnly = true;
            this.colTavolo.Width = 80;
            //
            // colOra
            //
            this.colOra.HeaderText = "Ora";
            this.colOra.Name = "colOra";
            this.colOra.ReadOnly = true;
            this.colOra.Width = 90;
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
            this.colStato.Width = 130;
            //
            // panelAzioni
            //
            this.panelAzioni.Controls.Add(this.btnInPreparazione);
            this.panelAzioni.Controls.Add(this.btnPronto);
            this.panelAzioni.Controls.Add(this.btnServito);
            this.panelAzioni.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAzioni.Location = new System.Drawing.Point(0, 450);
            this.panelAzioni.Name = "panelAzioni";
            this.panelAzioni.Size = new System.Drawing.Size(1000, 60);
            this.panelAzioni.TabIndex = 1;
            //
            // btnInPreparazione
            //
            this.btnInPreparazione.Location = new System.Drawing.Point(12, 10);
            this.btnInPreparazione.Name = "btnInPreparazione";
            this.btnInPreparazione.Size = new System.Drawing.Size(170, 40);
            this.btnInPreparazione.TabIndex = 0;
            this.btnInPreparazione.Text = "In preparazione";
            this.btnInPreparazione.UseVisualStyleBackColor = true;
            this.btnInPreparazione.Click += new System.EventHandler(this.btnInPreparazione_Click);
            //
            // btnPronto
            //
            this.btnPronto.Location = new System.Drawing.Point(192, 10);
            this.btnPronto.Name = "btnPronto";
            this.btnPronto.Size = new System.Drawing.Size(170, 40);
            this.btnPronto.TabIndex = 1;
            this.btnPronto.Text = "Pronto";
            this.btnPronto.UseVisualStyleBackColor = true;
            this.btnPronto.Click += new System.EventHandler(this.btnPronto_Click);
            //
            // btnServito
            //
            this.btnServito.Location = new System.Drawing.Point(372, 10);
            this.btnServito.Name = "btnServito";
            this.btnServito.Size = new System.Drawing.Size(170, 40);
            this.btnServito.TabIndex = 2;
            this.btnServito.Text = "Servito";
            this.btnServito.UseVisualStyleBackColor = true;
            this.btnServito.Click += new System.EventHandler(this.btnServito_Click);
            //
            // txtLog
            //
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Location = new System.Drawing.Point(0, 510);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1000, 140);
            this.txtLog.TabIndex = 2;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.dgvOrdini);
            this.Controls.Add(this.panelAzioni);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cucina - All You Can Eat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdini)).EndInit();
            this.panelAzioni.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.NumericUpDown numPorta;
        private System.Windows.Forms.Button btnAvvia;
        private System.Windows.Forms.Button btnFerma;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.DataGridView dgvOrdini;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTavolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPiatti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStato;
        private System.Windows.Forms.Panel panelAzioni;
        private System.Windows.Forms.Button btnInPreparazione;
        private System.Windows.Forms.Button btnPronto;
        private System.Windows.Forms.Button btnServito;
        private System.Windows.Forms.TextBox txtLog;
    }
}
