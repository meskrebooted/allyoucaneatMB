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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblIp = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lblTavolo = new System.Windows.Forms.Label();
            this.numTavolo = new System.Windows.Forms.NumericUpDown();
            this.btnConnetti = new System.Windows.Forms.Button();
            this.btnDisconnetti = new System.Windows.Forms.Button();
            this.lblStato = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTavolo)).BeginInit();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.Controls.Add(this.lblIp);
            this.panelTop.Controls.Add(this.txtIp);
            this.panelTop.Controls.Add(this.lblTavolo);
            this.panelTop.Controls.Add(this.numTavolo);
            this.panelTop.Controls.Add(this.btnConnetti);
            this.panelTop.Controls.Add(this.btnDisconnetti);
            this.panelTop.Controls.Add(this.lblStato);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 90);
            this.panelTop.TabIndex = 1;
            //
            // lblIp
            //
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(12, 15);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(80, 16);
            this.lblIp.Text = "IP server";
            //
            // txtIp
            //
            this.txtIp.Location = new System.Drawing.Point(90, 12);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(140, 22);
            this.txtIp.TabIndex = 0;
            this.txtIp.Text = "127.0.0.1";
            //
            // lblTavolo
            //
            this.lblTavolo.AutoSize = true;
            this.lblTavolo.Location = new System.Drawing.Point(250, 15);
            this.lblTavolo.Name = "lblTavolo";
            this.lblTavolo.Size = new System.Drawing.Size(50, 16);
            this.lblTavolo.Text = "Tavolo";
            //
            // numTavolo
            //
            this.numTavolo.Location = new System.Drawing.Point(305, 12);
            this.numTavolo.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.numTavolo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numTavolo.Name = "numTavolo";
            this.numTavolo.Size = new System.Drawing.Size(60, 22);
            this.numTavolo.TabIndex = 1;
            this.numTavolo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnConnetti
            //
            this.btnConnetti.Location = new System.Drawing.Point(390, 8);
            this.btnConnetti.Name = "btnConnetti";
            this.btnConnetti.Size = new System.Drawing.Size(110, 32);
            this.btnConnetti.TabIndex = 2;
            this.btnConnetti.Text = "Connetti";
            this.btnConnetti.UseVisualStyleBackColor = true;
            this.btnConnetti.Click += new System.EventHandler(this.btnConnetti_Click);
            //
            // btnDisconnetti
            //
            this.btnDisconnetti.Location = new System.Drawing.Point(510, 8);
            this.btnDisconnetti.Name = "btnDisconnetti";
            this.btnDisconnetti.Size = new System.Drawing.Size(110, 32);
            this.btnDisconnetti.TabIndex = 3;
            this.btnDisconnetti.Text = "Disconnetti";
            this.btnDisconnetti.UseVisualStyleBackColor = true;
            this.btnDisconnetti.Click += new System.EventHandler(this.btnDisconnetti_Click);
            //
            // lblStato
            //
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(12, 58);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(100, 16);
            this.lblStato.Text = "Non connesso";
            //
            // txtLog
            //
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 90);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(900, 510);
            this.txtLog.TabIndex = 0;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panelTop);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tablet - All You Can Eat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTavolo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblTavolo;
        private System.Windows.Forms.NumericUpDown numTavolo;
        private System.Windows.Forms.Button btnConnetti;
        private System.Windows.Forms.Button btnDisconnetti;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.TextBox txtLog;
    }
}