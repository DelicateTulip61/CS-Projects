namespace Ex05
{
    public class Board
    {
        private readonly eCell[,] r_Matrix;
        private readonly int r_Rows;
        private readonly int r_Columns;

        public int Rows => r_Rows;
        public int Columns => r_Columns;

        public Board(int i_Rows, int i_Columns)
        {
            r_Rows = i_Rows;
            r_Columns = i_Columns;
            r_Matrix = new eCell[i_Rows, i_Columns];
            resetBoard();
        }

        private void resetBoard()
        {
            for (int rowIndex = 0; rowIndex < r_Rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < r_Columns; columnIndex++)
                {
                    r_Matrix[rowIndex, columnIndex] = eCell.Empty;
                }
            }
        }

        public bool IsColumnFull(int i_Column)
        {
            return r_Matrix[0, i_Column] != eCell.Empty;
        }

        public bool IsBoardFull()
        {
            for (int columnIndex = 0; columnIndex < r_Columns; columnIndex++)
            {
                if (!IsColumnFull(columnIndex))
                {
                    return false;
                }
            }
            return true;
        }

        public bool TryInsertPiece(int i_ColumnIndex, eCell i_Piece, out int o_RowInserted)
        {
            o_RowInserted = -1;

            if (i_ColumnIndex < 0 || i_ColumnIndex >= r_Columns || IsColumnFull(i_ColumnIndex))
            {
                return false;
            }

            for (int rowIndex = r_Rows - 1; rowIndex >= 0; rowIndex--)
            {
                if (r_Matrix[rowIndex, i_ColumnIndex] == eCell.Empty)
                {
                    r_Matrix[rowIndex, i_ColumnIndex] = i_Piece;
                    o_RowInserted = rowIndex;
                    return true;
                }
            }

            return false;
        }

        public eCell GetCell(int i_RowIndex, int i_ColIndex)
        {
            return r_Matrix[i_RowIndex, i_ColIndex];
        }

        public bool CheckWin(eCell i_Piece)
        {
            for (int rowIndex = 0; rowIndex < r_Rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < r_Columns; columnIndex++)
                {
                    if (checkDirection(rowIndex, columnIndex, 0, 1, i_Piece) ||   
                        checkDirection(rowIndex, columnIndex, 1, 0, i_Piece) ||   
                        checkDirection(rowIndex, columnIndex, 1, 1, i_Piece) ||   
                        checkDirection(rowIndex, columnIndex, 1, -1, i_Piece))    
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool checkDirection(int i_StartRowIndex, int i_StartColumnIndex, int i_RowDirection, 
            int i_ColumnDirection,eCell i_Piece)
        {
            int count = 0;
            int currentRowIndex = i_StartRowIndex;
            int currentColumnIndex = i_StartColumnIndex;

            while (currentRowIndex >= 0 && currentRowIndex < r_Rows &&
                   currentColumnIndex >= 0 && currentColumnIndex < r_Columns)
            {
                if (r_Matrix[currentRowIndex, currentColumnIndex] == i_Piece)
                {
                    count++;
                    if (count == 4)
                    {
                        return true;
                    }
                }

                else
                {
                    count = 0;
                }

                currentRowIndex += i_RowDirection;
                currentColumnIndex += i_ColumnDirection;
            }

            return false;
        }

    }
}
