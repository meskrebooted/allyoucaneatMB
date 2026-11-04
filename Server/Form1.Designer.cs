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
            this.btnRicaricaMenu = new System.Windows.Forms.Button();
            this.lblTavoliConnessi = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.dgvOrdini = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTavolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrascorsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPiatti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelAzioni = new System.Windows.Forms.Panel();
            this.lblContatori = new System.Windows.Forms.Label();
            this.btnEsportaCSV = new System.Windows.Forms.Button();
            this.btnEliminaServiti = new System.Windows.Forms.Button();
            this.btnServito = new System.Windows.Forms.Button();
            this.btnPronto = new System.Windows.Forms.Button();
            this.btnInPreparazione = new System.Windows.Forms.Button();
            this.txtFiltroTavolo = new System.Windows.Forms.TextBox();
            this.lblFiltroTavolo = new System.Windows.Forms.Label();
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
            this.panelTop.Controls.Add(this.btnRicaricaMenu);
            this.panelTop.Controls.Add(this.lblTavoliConnessi);
            this.panelTop.Controls.Add(this.lblStato);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 72);
            this.panelTop.TabIndex = 0;
            //
            // lblPorta
            //
            this.lblPorta.AutoSize = true;
            this.lblPorta.Location = new System.Drawing.Point(12, 22);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(37, 16);
            this.lblPorta.TabIndex = 0;
            this.lblPorta.Text = "Porta";
            //
            // numPorta
            //
            this.numPorta.Location = new System.Drawing.Point(60, 19);
            this.numPorta.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.numPorta.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            this.numPorta.Name = "numPorta";
            this.numPorta.Size = new System.Drawing.Size(80, 22);
            this.numPorta.TabIndex = 1;
            this.numPorta.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            //
            // btnAvvia
            //
            this.btnAvvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvvia.Location = new System.Drawing.Point(160, 11);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(110, 34);
            this.btnAvvia.TabIndex = 2;
            this.btnAvvia.Text = "Avvia server";
            this.btnAvvia.UseVisualStyleBackColor = false;
            this.btnAvvia.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAvvia.ForeColor = System.Drawing.Color.White;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            //
            // btnFerma
            //
            this.btnFerma.Enabled = false;
            this.btnFerma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFerma.Location = new System.Drawing.Point(280, 11);
            this.btnFerma.Name = "btnFerma";
            this.btnFerma.Size = new System.Drawing.Size(110, 34);
            this.btnFerma.TabIndex = 3;
            this.btnFerma.Text = "Ferma server";
            this.btnFerma.UseVisualStyleBackColor = false;
            this.btnFerma.BackColor = System.Drawing.Color.Firebrick;
            this.btnFerma.ForeColor = System.Drawing.Color.White;
            this.btnFerma.Click += new System.EventHandler(this.btnFerma_Click);
            //
            // btnRicaricaMenu
            //
            this.btnRicaricaMenu.Location = new System.Drawing.Point(400, 11);
            this.btnRicaricaMenu.Name = "btnRicaricaMenu";
            this.btnRicaricaMenu.Size = new System.Drawing.Size(110, 34);
            this.btnRicaricaMenu.TabIndex = 4;
            this.btnRicaricaMenu.Text = "Ricarica menu";
            this.btnRicaricaMenu.UseVisualStyleBackColor = true;
            this.btnRicaricaMenu.Click += new System.EventHandler(this.btnRicaricaMenu_Click);
            //
            // btnSvuotaLog
            //
            this.btnSvuotaLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSvuotaLog.Location = new System.Drawing.Point(520, 11);
            this.btnSvuotaLog.Name = "btnSvuotaLog";
            this.btnSvuotaLog.Size = new System.Drawing.Size(110, 34);
            this.btnSvuotaLog.TabIndex = 5;
            this.btnSvuotaLog.Text = "Svuota log";
            this.btnSvuotaLog.UseVisualStyleBackColor = false;
            this.btnSvuotaLog.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSvuotaLog.ForeColor = System.Drawing.Color.White;
            this.btnSvuotaLog.Click += new System.EventHandler(this.btnSvuotaLog_Click);
            //
            // lblTavoliConnessi
            //
            this.lblTavoliConnessi.AutoSize = true;
            this.lblTavoliConnessi.Location = new System.Drawing.Point(640, 22);
            this.lblTavoliConnessi.Name = "lblTavoliConnessi";
            this.lblTavoliConnessi.Size = new System.Drawing.Size(79, 16);
            this.lblTavoliConnessi.TabIndex = 5;
            this.lblTavoliConnessi.Text = "Tavoli: 0";
            //
            // lblStato
            //
            this.lblStato.AutoSize = true;
            this.lblStato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStato.Location = new System.Drawing.Point(770, 22);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(94, 16);
            this.lblStato.TabIndex = 6;
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
            this.colTrascorsi,
            this.colPiatti,
            this.colStato});
            this.dgvOrdini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdini.Location = new System.Drawing.Point(0, 72);
            this.dgvOrdini.MultiSelect = false;
            this.dgvOrdini.Name = "dgvOrdini";
            this.dgvOrdini.ReadOnly = true;
            this.dgvOrdini.RowHeadersVisible = false;
            this.dgvOrdini.EnableHeadersVisualStyles = false;
            this.dgvOrdini.RowTemplate.Height = 26;
            this.dgvOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdini.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.dgvOrdini.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOrdini.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdini.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOrdini.Size = new System.Drawing.Size(1000, 348);
            this.dgvOrdini.TabIndex = 1;
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
            this.colTavolo.HeaderText = "Tavolo";
            this.colTavolo.Name = "colTavolo";
            this.colTavolo.ReadOnly = true;
            this.colTavolo.Width = 70;
            this.colTavolo.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTavolo.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //
            // colOra
            //
            this.colOra.HeaderText = "Ora";
            this.colOra.Name = "colOra";
            this.colOra.ReadOnly = true;
            this.colOra.Width = 80;
            this.colOra.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colOra.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //
            // colTrascorsi
            //
            this.colTrascorsi.HeaderText = "Trascorsi";
            this.colTrascorsi.Name = "colTrascorsi";
            this.colTrascorsi.ReadOnly = true;
            this.colTrascorsi.Width = 90;
            this.colTrascorsi.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTrascorsi.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            this.colStato.Width = 120;
            //
            // panelAzioni
            //
            this.panelAzioni.Controls.Add(this.lblContatori);
            this.panelAzioni.Controls.Add(this.btnEsportaCSV);
            this.panelAzioni.Controls.Add(this.btnEliminaServiti);
            this.panelAzioni.Controls.Add(this.btnServito);
            this.panelAzioni.Controls.Add(this.btnPronto);
            this.panelAzioni.Controls.Add(this.btnInPreparazione);
            this.panelAzioni.Controls.Add(this.txtFiltroTavolo);
            this.panelAzioni.Controls.Add(this.lblFiltroTavolo);
            this.panelAzioni.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAzioni.Location = new System.Drawing.Point(0, 420);
            this.panelAzioni.Name = "panelAzioni";
            this.panelAzioni.Size = new System.Drawing.Size(1000, 90);
            this.panelAzioni.TabIndex = 2;
            //
            // lblContatori
            //
            this.lblContatori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContatori.Location = new System.Drawing.Point(780, 32);
            this.lblContatori.Name = "lblContatori";
            this.lblContatori.Size = new System.Drawing.Size(208, 32);
            this.lblContatori.TabIndex = 7;
            this.lblContatori.Text = "Totale: 0";
            this.lblContatori.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnEsportaCSV
            //
            this.btnEsportaCSV.Location = new System.Drawing.Point(590, 50);
            this.btnEsportaCSV.Name = "btnEsportaCSV";
            this.btnEsportaCSV.Size = new System.Drawing.Size(170, 32);
            this.btnEsportaCSV.TabIndex = 6;
            this.btnEsportaCSV.Text = "Esporta CSV";
            this.btnEsportaCSV.UseVisualStyleBackColor = true;
            this.btnEsportaCSV.Click += new System.EventHandler(this.btnEsportaCSV_Click);
            //
            // btnEliminaServiti
            //
            this.btnEliminaServiti.Location = new System.Drawing.Point(410, 50);
            this.btnEliminaServiti.Name = "btnEliminaServiti";
            this.btnEliminaServiti.Size = new System.Drawing.Size(170, 32);
            this.btnEliminaServiti.TabIndex = 5;
            this.btnEliminaServiti.Text = "Elimina ordini serviti";
            this.btnEliminaServiti.UseVisualStyleBackColor = true;
            this.btnEliminaServiti.Click += new System.EventHandler(this.btnEliminaServiti_Click);
            //
            // btnServito
            //
            this.btnServito.Enabled = false;
            this.btnServito.Location = new System.Drawing.Point(590, 10);
            this.btnServito.Name = "btnServito";
            this.btnServito.Size = new System.Drawing.Size(170, 36);
            this.btnServito.TabIndex = 4;
            this.btnServito.Text = "Servito";
            this.btnServito.UseVisualStyleBackColor = true;
            this.btnServito.Click += new System.EventHandler(this.btnServito_Click);
            //
            // btnPronto
            //
            this.btnPronto.Enabled = false;
            this.btnPronto.Location = new System.Drawing.Point(410, 10);
            this.btnPronto.Name = "btnPronto";
            this.btnPronto.Size = new System.Drawing.Size(170, 36);
            this.btnPronto.TabIndex = 3;
            this.btnPronto.Text = "Pronto";
            this.btnPronto.UseVisualStyleBackColor = true;
            this.btnPronto.Click += new System.EventHandler(this.btnPronto_Click);
            //
            // btnInPreparazione
            //
            this.btnInPreparazione.Enabled = false;
            this.btnInPreparazione.Location = new System.Drawing.Point(230, 10);
            this.btnInPreparazione.Name = "btnInPreparazione";
            this.btnInPreparazione.Size = new System.Drawing.Size(170, 36);
            this.btnInPreparazione.TabIndex = 2;
            this.btnInPreparazione.Text = "In preparazione";
            this.btnInPreparazione.UseVisualStyleBackColor = true;
            this.btnInPreparazione.Click += new System.EventHandler(this.btnInPreparazione_Click);
            //
            // txtFiltroTavolo
            //
            this.txtFiltroTavolo.Location = new System.Drawing.Point(110, 16);
            this.txtFiltroTavolo.Name = "txtFiltroTavolo";
            this.txtFiltroTavolo.Size = new System.Drawing.Size(100, 22);
            this.txtFiltroTavolo.TabIndex = 1;
            this.txtFiltroTavolo.TextChanged += new System.EventHandler(this.txtFiltroTavolo_TextChanged);
            this.txtFiltroTavolo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroTavolo_KeyPress);
            //
            // lblFiltroTavolo
            //
            this.lblFiltroTavolo.AutoSize = true;
            this.lblFiltroTavolo.Location = new System.Drawing.Point(12, 19);
            this.lblFiltroTavolo.Name = "lblFiltroTavolo";
            this.lblFiltroTavolo.Size = new System.Drawing.Size(92, 16);
            this.lblFiltroTavolo.TabIndex = 0;
            this.lblFiltroTavolo.Text = "Filtro tavolo:";
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
            this.txtLog.TabIndex = 3;
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
            this.MinimumSize = new System.Drawing.Size(820, 520);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cucina - All You Can Eat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdini)).EndInit();
            this.panelAzioni.ResumeLayout(false);
            this.panelAzioni.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.NumericUpDown numPorta;
        private System.Windows.Forms.Button btnAvvia;
        private System.Windows.Forms.Button btnFerma;
        private System.Windows.Forms.Button btnRicaricaMenu;
        private System.Windows.Forms.Button btnSvuotaLog;
        private System.Windows.Forms.Label lblTavoliConnessi;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.DataGridView dgvOrdini;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTavolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrascorsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPiatti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStato;
        private System.Windows.Forms.Panel panelAzioni;
        private System.Windows.Forms.TextBox txtFiltroTavolo;
        private System.Windows.Forms.Label lblFiltroTavolo;
        private System.Windows.Forms.Button btnInPreparazione;
        private System.Windows.Forms.Button btnPronto;
        private System.Windows.Forms.Button btnServito;
        private System.Windows.Forms.Button btnEliminaServiti;
        private System.Windows.Forms.Button btnEsportaCSV;
        private System.Windows.Forms.Label lblContatori;
        private System.Windows.Forms.TextBox txtLog;
    }
}
