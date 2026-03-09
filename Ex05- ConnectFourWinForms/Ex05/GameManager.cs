using System;
using System.Collections.Generic;

namespace Ex05
{
    public class GameManager
    {
        public Board Board { get; private set; }

        public string Player1Name { get; }
        public string Player2Name { get; }
        public bool TwoPlayers { get; }

        public eCell CurrentTurn { get; private set; } = eCell.X;

        public int ScoreP1 { get; private set; }
        public int ScoreP2 { get; private set; }

        private readonly int r_Rows;
        private readonly int r_Cols;
        private readonly Random r_Random = new Random();

        public GameManager(string i_Player1Name, string i_Player2Name, int i_Rows, int i_Cols, bool i_TwoPlayers)
        {
            Player1Name = i_Player1Name;
            Player2Name = i_Player2Name;
            TwoPlayers = i_TwoPlayers;

            r_Rows = i_Rows;
            r_Cols = i_Cols;

            Board = new Board(i_Rows, i_Cols);
        }

        public bool TryPlayMove(int i_ColumnIndex, out int o_RowInserted, out eRoundState o_RoundState)
        {
            o_RoundState = eRoundState.Ongoing;

            if (!Board.TryInsertPiece(i_ColumnIndex, CurrentTurn, out o_RowInserted))
            {
                return false;
            }

            if (Board.CheckWin(CurrentTurn))
            {
                addPoint(CurrentTurn);
                o_RoundState = eRoundState.Win;
                return true;
            }

            if (Board.IsBoardFull())
            {
                o_RoundState = eRoundState.Draw;
                return true;
            }

            switchTurn();
            return true;
        }

        public bool ShouldComputerPlay()
        {
            return !TwoPlayers && CurrentTurn == eCell.O;
        }

        public int GetComputerMove()
        {
            List<int> availableColumn = new List<int>();

            for (int columnIndex = 0; columnIndex < r_Cols; columnIndex++)
            {
                if (!Board.IsColumnFull(columnIndex))
                {
                    availableColumn.Add(columnIndex);
                }
            }

            return availableColumn.Count == 0 ? -1 : availableColumn[r_Random.Next(availableColumn.Count)];
        }

        public string GetWinnerName()
        {
            return CurrentTurn == eCell.X ? Player1Name : Player2Name;
        }

        public void ResetRound()
        {
            Board = new Board(r_Rows, r_Cols);
            CurrentTurn = eCell.X;
        }

        private void switchTurn()
        {
            CurrentTurn = CurrentTurn == eCell.X ? eCell.O : eCell.X;
        }

        private void addPoint(eCell i_Winner)
        {
            if (i_Winner == eCell.X)
            {
                ScoreP1++;
            }
            else
            {
                ScoreP2++;
            }
        }
    }
}
