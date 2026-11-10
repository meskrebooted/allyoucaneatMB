using System;
using System.Windows.Forms;
using allyoucaneat;

namespace Client
{
    // Display del tablet. Per ora: connessione al server e log dei messaggi ricevuti.
    public partial class Form1 : Form
    {
        private const int Porta = 5000;
        private readonly Client _client = new Client();

        public Form1()
        {
            InitializeComponent();

            _client.MessaggioRicevuto += m => EseguiSuUI(() => ScriviLog("<- " + m.CommandName + " " + string.Join(", ", m.ParametersList)));
            _client.Disconnesso += () => EseguiSuUI(() => { ScriviLog("Disconnesso dal server"); AggiornaStato(); });

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

        private void btnConnetti_Click(object sender, EventArgs e)
        {
            try
            {
                _client.Connetti(txtIp.Text.Trim(), Porta, (int)numTavolo.Value);
                ScriviLog("Connesso, inviato hello per il tavolo " + numTavolo.Value);
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

        private void AggiornaStato()
        {
            bool connesso = _client.Connesso;

            btnConnetti.Enabled = !connesso;
            btnDisconnetti.Enabled = connesso;
            txtIp.Enabled = !connesso;
            numTavolo.Enabled = !connesso;

            lblStato.Text = connesso ? "Connesso al tavolo " + numTavolo.Value : "Non connesso";
        }

        private void ScriviLog(string testo)
        {
            txtLog.AppendText(DateTime.Now.ToString("HH:mm:ss") + "  " + testo + Environment.NewLine);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client.Connesso)
                _client.Disconnetti();
        }
    }
}