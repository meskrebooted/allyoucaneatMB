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
            this.panelCentro = new System.Windows.Forms.Panel();
            this.flowScontrini = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOrdini = new System.Windows.Forms.Label();
            this.panelLog = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.btnAvvia = new System.Windows.Forms.Button();
            this.btnFerma = new System.Windows.Forms.Button();
            this.panelCentro.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            //
            // panelCentro
            //
            this.panelCentro.BackColor = System.Drawing.Color.FromArgb(250, 246, 240);
            this.panelCentro.Controls.Add(this.flowScontrini);
            this.panelCentro.Controls.Add(this.lblOrdini);
            this.panelCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentro.Location = new System.Drawing.Point(0, 80);
            this.panelCentro.Name = "panelCentro";
            this.panelCentro.Padding = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.panelCentro.Size = new System.Drawing.Size(1200, 520);
            this.panelCentro.TabIndex = 0;
            //
            // flowScontrini
            //
            this.flowScontrini.AutoScroll = true;
            this.flowScontrini.BackColor = System.Drawing.Color.FromArgb(250, 246, 240);
            this.flowScontrini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowScontrini.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowScontrini.Location = new System.Drawing.Point(12, 44);
            this.flowScontrini.Name = "flowScontrini";
            this.flowScontrini.Size = new System.Drawing.Size(1176, 464);
            this.flowScontrini.TabIndex = 0;
            this.flowScontrini.WrapContents = false;
            //
            // lblOrdini
            //
            this.lblOrdini.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOrdini.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdini.Location = new System.Drawing.Point(12, 0);
            this.lblOrdini.Name = "lblOrdini";
            this.lblOrdini.Size = new System.Drawing.Size(1176, 44);
            this.lblOrdini.TabIndex = 1;
            this.lblOrdini.Text = "ORDINI IN ARRIVO";
            this.lblOrdini.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panelLog
            //
            this.panelLog.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelLog.Controls.Add(this.txtLog);
            this.panelLog.Controls.Add(this.lblLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Location = new System.Drawing.Point(0, 600);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(1200, 120);
            this.panelLog.TabIndex = 1;
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
            this.txtLog.Size = new System.Drawing.Size(1200, 86);
            this.txtLog.TabIndex = 0;
            //
            // lblLog
            //
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLog.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(0, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblLog.Size = new System.Drawing.Size(1200, 34);
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
            this.panelTop.Size = new System.Drawing.Size(1200, 80);
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
            this.btnAvvia.Location = new System.Drawing.Point(960, 22);
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
            this.btnFerma.Location = new System.Drawing.Point(1080, 22);
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
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panelCentro);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cucina - All You Can Eat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelCentro.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCentro;
        private System.Windows.Forms.FlowLayoutPanel flowScontrini;
        private System.Windows.Forms.Label lblOrdini;
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
