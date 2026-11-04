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
            this.btnRiduisci = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
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
            // panelTop - TitleBar personalizzata
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panelTop.Controls.Add(this.lblPorta);
            this.panelTop.Controls.Add(this.numPorta);
            this.panelTop.Controls.Add(this.btnAvvia);
            this.panelTop.Controls.Add(this.btnFerma);
            this.panelTop.Controls.Add(this.btnRicaricaMenu);
            this.panelTop.Controls.Add(this.lblTavoliConnessi);
            this.panelTop.Controls.Add(this.lblStato);
            this.panelTop.Controls.Add(this.btnRiduisci);
            this.panelTop.Controls.Add(this.btnChiudi);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 56);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            //
            // lblPorta
            //
            this.lblPorta.AutoSize = true;
            this.lblPorta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.lblPorta.Location = new System.Drawing.Point(12, 18);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(42, 19);
            this.lblPorta.TabIndex = 0;
            this.lblPorta.Text = "Porta";
            //
            // numPorta
            //
            this.numPorta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.numPorta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPorta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPorta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.numPorta.Location = new System.Drawing.Point(60, 16);
            this.numPorta.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.numPorta.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            this.numPorta.Name = "numPorta";
            this.numPorta.Size = new System.Drawing.Size(80, 25);
            this.numPorta.TabIndex = 1;
            this.numPorta.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            //
            // btnAvvia
            //
            this.btnAvvia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btnAvvia.FlatAppearance.BorderSize = 0;
            this.btnAvvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvvia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvvia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnAvvia.Location = new System.Drawing.Point(160, 11);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(110, 34);
            this.btnAvvia.TabIndex = 2;
            this.btnAvvia.Text = "Avvia server";
            this.btnAvvia.UseVisualStyleBackColor = false;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            //
            // btnFerma
            //
            this.btnFerma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btnFerma.Enabled = false;
            this.btnFerma.FlatAppearance.BorderSize = 0;
            this.btnFerma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFerma.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFerma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnFerma.Location = new System.Drawing.Point(280, 11);
            this.btnFerma.Name = "btnFerma";
            this.btnFerma.Size = new System.Drawing.Size(110, 34);
            this.btnFerma.TabIndex = 3;
            this.btnFerma.Text = "Ferma server";
            this.btnFerma.UseVisualStyleBackColor = false;
            this.btnFerma.Click += new System.EventHandler(this.btnFerma_Click);
            //
            // btnRicaricaMenu
            //
            this.btnRicaricaMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btnRicaricaMenu.FlatAppearance.BorderSize = 0;
            this.btnRicaricaMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRicaricaMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRicaricaMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnRicaricaMenu.Location = new System.Drawing.Point(400, 11);
            this.btnRicaricaMenu.Name = "btnRicaricaMenu";
            this.btnRicaricaMenu.Size = new System.Drawing.Size(110, 34);
            this.btnRicaricaMenu.TabIndex = 4;
            this.btnRicaricaMenu.Text = "Ricarica menu";
            this.btnRicaricaMenu.UseVisualStyleBackColor = false;
            this.btnRicaricaMenu.Click += new System.EventHandler(this.btnRicaricaMenu_Click);
            //
            // lblTavoliConnessi
            //
            this.lblTavoliConnessi.AutoSize = true;
            this.lblTavoliConnessi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTavoliConnessi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.lblTavoliConnessi.Location = new System.Drawing.Point(530, 19);
            this.lblTavoliConnessi.Name = "lblTavoliConnessi";
            this.lblTavoliConnessi.Size = new System.Drawing.Size(92, 19);
            this.lblTavoliConnessi.TabIndex = 5;
            this.lblTavoliConnessi.Text = "Tavoli: 0";
            //
            // lblStato
            //
            this.lblStato.AutoSize = true;
            this.lblStato.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.lblStato.Location = new System.Drawing.Point(640, 19);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(104, 19);
            this.lblStato.TabIndex = 6;
            this.lblStato.Text = "Server fermato";
            //
            // btnRiduisci
            //
            this.btnRiduisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRiduisci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnRiduisci.FlatAppearance.BorderSize = 0;
            this.btnRiduisci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRiduisci.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRiduisci.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnRiduisci.Location = new System.Drawing.Point(910, 12);
            this.btnRiduisci.Name = "btnRiduisci";
            this.btnRiduisci.Size = new System.Drawing.Size(36, 30);
            this.btnRiduisci.TabIndex = 7;
            this.btnRiduisci.Text = "—";
            this.btnRiduisci.UseVisualStyleBackColor = false;
            this.btnRiduisci.Click += new System.EventHandler(this.btnRiduisci_Click);
            //
            // btnChiudi
            //
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btnChiudi.FlatAppearance.BorderSize = 0;
            this.btnChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiudi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiudi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnChiudi.Location = new System.Drawing.Point(952, 12);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(36, 30);
            this.btnChiudi.TabIndex = 8;
            this.btnChiudi.Text = "×";
            this.btnChiudi.UseVisualStyleBackColor = false;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            //
            // dgvOrdini
            //
            this.dgvOrdini.AllowUserToAddRows = false;
            this.dgvOrdini.AllowUserToDeleteRows = false;
            this.dgvOrdini.AllowUserToResizeRows = false;
            this.dgvOrdini.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.dgvOrdini.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdini.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTavolo,
            this.colOra,
            this.colTrascorsi,
            this.colPiatti,
            this.colStato});
            this.dgvOrdini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdini.EnableHeadersVisualStyles = false;
            this.dgvOrdini.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvOrdini.Location = new System.Drawing.Point(0, 56);
            this.dgvOrdini.MultiSelect = false;
            this.dgvOrdini.Name = "dgvOrdini";
            this.dgvOrdini.ReadOnly = true;
            this.dgvOrdini.RowHeadersVisible = false;
            this.dgvOrdini.RowTemplate.Height = 30;
            this.dgvOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdini.Size = new System.Drawing.Size(1000, 364);
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
            this.panelAzioni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
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
            this.lblContatori.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContatori.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.lblContatori.Location = new System.Drawing.Point(780, 30);
            this.lblContatori.Name = "lblContatori";
            this.lblContatori.Size = new System.Drawing.Size(208, 32);
            this.lblContatori.TabIndex = 7;
            this.lblContatori.Text = "Totale: 0";
            this.lblContatori.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnEsportaCSV
            //
            this.btnEsportaCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnEsportaCSV.FlatAppearance.BorderSize = 0;
            this.btnEsportaCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEsportaCSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEsportaCSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnEsportaCSV.Location = new System.Drawing.Point(590, 50);
            this.btnEsportaCSV.Name = "btnEsportaCSV";
            this.btnEsportaCSV.Size = new System.Drawing.Size(170, 32);
            this.btnEsportaCSV.TabIndex = 6;
            this.btnEsportaCSV.Text = "Esporta CSV";
            this.btnEsportaCSV.UseVisualStyleBackColor = false;
            this.btnEsportaCSV.Click += new System.EventHandler(this.btnEsportaCSV_Click);
            //
            // btnEliminaServiti
            //
            this.btnEliminaServiti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnEliminaServiti.FlatAppearance.BorderSize = 0;
            this.btnEliminaServiti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminaServiti.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminaServiti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnEliminaServiti.Location = new System.Drawing.Point(410, 50);
            this.btnEliminaServiti.Name = "btnEliminaServiti";
            this.btnEliminaServiti.Size = new System.Drawing.Size(170, 32);
            this.btnEliminaServiti.TabIndex = 5;
            this.btnEliminaServiti.Text = "Elimina ordini serviti";
            this.btnEliminaServiti.UseVisualStyleBackColor = false;
            this.btnEliminaServiti.Click += new System.EventHandler(this.btnEliminaServiti_Click);
            //
            // btnServito
            //
            this.btnServito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(143)))));
            this.btnServito.Enabled = false;
            this.btnServito.FlatAppearance.BorderSize = 0;
            this.btnServito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServito.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnServito.Location = new System.Drawing.Point(590, 10);
            this.btnServito.Name = "btnServito";
            this.btnServito.Size = new System.Drawing.Size(170, 36);
            this.btnServito.TabIndex = 4;
            this.btnServito.Text = "Servito";
            this.btnServito.UseVisualStyleBackColor = false;
            this.btnServito.Click += new System.EventHandler(this.btnServito_Click);
            //
            // btnPronto
            //
            this.btnPronto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(143)))));
            this.btnPronto.Enabled = false;
            this.btnPronto.FlatAppearance.BorderSize = 0;
            this.btnPronto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPronto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPronto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnPronto.Location = new System.Drawing.Point(410, 10);
            this.btnPronto.Name = "btnPronto";
            this.btnPronto.Size = new System.Drawing.Size(170, 36);
            this.btnPronto.TabIndex = 3;
            this.btnPronto.Text = "Pronto";
            this.btnPronto.UseVisualStyleBackColor = false;
            this.btnPronto.Click += new System.EventHandler(this.btnPronto_Click);
            //
            // btnInPreparazione
            //
            this.btnInPreparazione.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnInPreparazione.Enabled = false;
            this.btnInPreparazione.FlatAppearance.BorderSize = 0;
            this.btnInPreparazione.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInPreparazione.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInPreparazione.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnInPreparazione.Location = new System.Drawing.Point(230, 10);
            this.btnInPreparazione.Name = "btnInPreparazione";
            this.btnInPreparazione.Size = new System.Drawing.Size(170, 36);
            this.btnInPreparazione.TabIndex = 2;
            this.btnInPreparazione.Text = "In preparazione";
            this.btnInPreparazione.UseVisualStyleBackColor = false;
            this.btnInPreparazione.Click += new System.EventHandler(this.btnInPreparazione_Click);
            //
            // txtFiltroTavolo
            //
            this.txtFiltroTavolo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.txtFiltroTavolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroTavolo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroTavolo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.txtFiltroTavolo.Location = new System.Drawing.Point(110, 16);
            this.txtFiltroTavolo.Name = "txtFiltroTavolo";
            this.txtFiltroTavolo.Size = new System.Drawing.Size(100, 25);
            this.txtFiltroTavolo.TabIndex = 1;
            this.txtFiltroTavolo.TextChanged += new System.EventHandler(this.txtFiltroTavolo_TextChanged);
            this.txtFiltroTavolo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroTavolo_KeyPress);
            //
            // lblFiltroTavolo
            //
            this.lblFiltroTavolo.AutoSize = true;
            this.lblFiltroTavolo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroTavolo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.lblFiltroTavolo.Location = new System.Drawing.Point(12, 19);
            this.lblFiltroTavolo.Name = "lblFiltroTavolo";
            this.lblFiltroTavolo.Size = new System.Drawing.Size(92, 19);
            this.lblFiltroTavolo.TabIndex = 0;
            this.lblFiltroTavolo.Text = "Filtro tavolo:";
            //
            // txtLog
            //
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(143)))));
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.dgvOrdini);
            this.Controls.Add(this.panelAzioni);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(820, 520);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cucina - All You Can Eat Sushi";
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
        private System.Windows.Forms.Label lblTavoliConnessi;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.Button btnRiduisci;
        private System.Windows.Forms.Button btnChiudi;
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
