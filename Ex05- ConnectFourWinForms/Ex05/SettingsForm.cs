using System;
using System.Windows.Forms;

namespace Ex05
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            
            cbPlayer2.CheckedChanged += cbPlayer2_CheckedChanged;

            btnStart.Click += btnStart_Click;
        }

        
        private void cbPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            txtPlayer2.Enabled = cbPlayer2.Checked;

            if (!cbPlayer2.Checked)
            {
                txtPlayer2.Text = "[Computer]";
            }
            else
            {
                txtPlayer2.Text = "";
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            string player1Name = string.IsNullOrWhiteSpace(txtPlayer1.Text) ? "Player 1" : txtPlayer1.Text;

            bool twoPlayers = cbPlayer2.Checked;

            string player2Name = twoPlayers
                ? (string.IsNullOrWhiteSpace(txtPlayer2.Text) ? "Player 2" : txtPlayer2.Text)
                : "Computer";

            int numberOfRows = (int)numRows.Value;
            int numberOfColumns = (int)numCols.Value;

            GameManager gameManager = new GameManager(player1Name, player2Name, numberOfRows, numberOfColumns, twoPlayers);
            GameForm gameForm = new GameForm(gameManager);

            this.Hide();
            gameForm.ShowDialog();
            this.Close();
        }
    }
}
