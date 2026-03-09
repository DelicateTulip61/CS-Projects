using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class GameForm : Form
    {
        private readonly GameManager m_Game;
        private readonly Button[] m_ColumnButtons;
        private readonly Button[,] m_GridButtons;

        private readonly Label m_ScoreLabel;

        private const int k_CellSize = 40;
        private const int k_Gap = 5;

        public GameForm(GameManager i_GameManager)
        {
            m_Game = i_GameManager;

            Text = "4 in a Row !!";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            int width = i_GameManager.Board.Columns * (k_CellSize + k_Gap) + k_Gap;
            int height = (i_GameManager.Board.Rows + 2) * (k_CellSize + k_Gap);

            ClientSize = new Size(width, height);

            m_ColumnButtons = new Button[i_GameManager.Board.Columns];
            m_GridButtons = new Button[i_GameManager.Board.Rows, i_GameManager.Board.Columns];

            buildColumnButtons();
            buildGrid();
            m_ScoreLabel = buildScoreLabel();

            updateScore();
        }

        private void buildColumnButtons()
        {
            for (int columnIndex = 0; columnIndex < m_ColumnButtons.Length; columnIndex++)
            {
                Button columnButton = new Button
                {
                    Size = new Size(k_CellSize, k_CellSize),
                    Location = new Point(k_Gap + columnIndex * (k_CellSize + k_Gap), k_Gap),
                    Text = (columnIndex + 1).ToString(),
                    Tag = columnIndex
                };

                columnButton.Click += columnClicked;
                Controls.Add(columnButton);
                m_ColumnButtons[columnIndex] = columnButton;
            }
        }

        private void buildGrid()
        {
            for (int rowIndex = 0; rowIndex < m_GridButtons.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m_GridButtons.GetLength(1); columnIndex++)
                {
                    Button cell = new Button
                    {
                        Size = new Size(k_CellSize, k_CellSize),
                        Location = new Point(k_Gap + columnIndex * (k_CellSize + k_Gap),
                                             k_Gap + (rowIndex + 1) * (k_CellSize + k_Gap)),
                        Enabled = false
                    };

                    Controls.Add(cell);
                    m_GridButtons[rowIndex, columnIndex] = cell;
                }
            }
        }

        private Label buildScoreLabel()
        {
            Label scoreLabel = new Label
            {
                AutoSize = true,
                Location = new Point(k_Gap, ClientSize.Height - k_CellSize),
            };

            Controls.Add(scoreLabel);
            return scoreLabel;
        }

        private void columnClicked(object sender, EventArgs e)
        {
            int columnIndex = (int)((Button)sender).Tag;
            playMove(columnIndex);

            if (m_Game.ShouldComputerPlay())
            {
                playMove(m_Game.GetComputerMove());
            }
        }

        private void playMove(int i_ColumnIndex)
        {
            eCell placedPiece = m_Game.CurrentTurn;

            if (!m_Game.TryPlayMove(i_ColumnIndex, out int rowInserted, out eRoundState roundState))
            {
                return;
            }

            m_GridButtons[rowInserted, i_ColumnIndex].Text = placedPiece == eCell.X ? "X" : "O";

            if (m_Game.Board.IsColumnFull(i_ColumnIndex))
            {
                m_ColumnButtons[i_ColumnIndex].Enabled = false;
            }

            if (roundState != eRoundState.Ongoing)
            {
                handleRoundEnd(roundState);
            }
        }

        private void handleRoundEnd(eRoundState i_RoundState)
        {
            updateScore();

            string message = i_RoundState == eRoundState.Draw
                ? "It's a tie!" + Environment.NewLine + "Play another round?"
                : m_Game.GetWinnerName() + " won!" + Environment.NewLine + "Play another round?";

            DialogResult response = MessageBox.Show(message, "Game Over", MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
            {
                resetBoard();
                m_Game.ResetRound();
            }
            else
            {
                Application.Exit();
            }
        }

        private void resetBoard()
        {
            for (int rowIndex = 0; rowIndex < m_GridButtons.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m_GridButtons.GetLength(1); columnIndex++)
                {
                    m_GridButtons[rowIndex, columnIndex].Text = "";
                }
            }

            foreach (Button columnButton in m_ColumnButtons)
            {
                columnButton.Enabled = true;
            }
        }

        private void updateScore()
        {
            m_ScoreLabel.Text =
                m_Game.Player1Name + ": " + m_Game.ScoreP1 +
                "    " +
                m_Game.Player2Name + ": " + m_Game.ScoreP2;

            m_ScoreLabel.Left = (ClientSize.Width - m_ScoreLabel.Width) / 2;
        }
    }
}
