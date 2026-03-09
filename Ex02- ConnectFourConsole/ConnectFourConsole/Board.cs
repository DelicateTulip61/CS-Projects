using System;

namespace Ex02
{
    internal class Board
    {
        private char[,] m_Matrix;
        private int m_Rows;
        private int m_Columns;


        public Board(int i_Rows, int i_Columns)
        {
            m_Rows = i_Rows;
            m_Columns = i_Columns;
            m_Matrix = new char[m_Rows, m_Columns];
            startBoard();
        }

        public int Rows
        {
            get 
            {
                return m_Rows;
            }
            private set
            {
                m_Rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return m_Columns;
            }
            private set
            {
                m_Columns = value;
            }
        }

        private void startBoard()
        {
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Columns; j++)
                {
                    m_Matrix[i, j] = ' ';
                }
            }
        }

        public bool IsColumnFull(int i_Column) // returns true if Columns is full
        {
            return m_Matrix[0, i_Column] != ' ';
        }

        public bool IsBoardFull() // returns true if Board is full
        {
            bool flag = true;

            for (int i = 0;i < Columns;i++)
            {
                if (!IsColumnFull(i))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        } 

        public bool TryInsertPiece(int i_Column, char i_Piece, out int o_RowInserted)
        {
            bool inserted = false;
            o_RowInserted = -1;

            if (i_Column >= 0 && i_Column < Columns)
            {
                if (IsColumnFull(i_Column) == false)
                {
                    for (int row = Rows - 1; row >= 0 && inserted == false ; row--)
                    {
                        if (m_Matrix[row, i_Column] == ' ')
                        {
                            m_Matrix[row, i_Column] = i_Piece;
                            o_RowInserted = row;
                            inserted = true;
                        }
                    }
                }

            }

            return inserted;
        }

        private bool checkDirection(int i_StartRow, int i_StartCol, int i_RowDir, int i_ColDir, char i_Piece)
        {
            int count = 0;
            int row = i_StartRow;
            int col = i_StartCol;
            bool isWin = false;

            while (row >= 0 && row < Rows && col >= 0 && col < Columns)
            {
                if (m_Matrix[row, col] == i_Piece)
                {
                    count++;
                    if (count == 4)
                    {
                        isWin = true;
                        break;
                    }
                }
                else
                {
                    count = 0;
                }

                row += i_RowDir;
                col += i_ColDir;
            }

            return isWin;
        }

        public bool CheckWin(char i_Piece)
        {
            bool isWin = false;

            for (int row = 0; row < Rows && !isWin; row++)
            {
                for (int col = 0; col < Columns && !isWin; col++)
                {
                    if (checkDirection(row, col, 0, 1, i_Piece) ||
                        checkDirection(row, col, 1, 0, i_Piece) ||
                        checkDirection(row, col, 1, 1, i_Piece) ||
                        checkDirection(row, col, 1, -1, i_Piece))
                    {
                        isWin = true;
                    }
                }
            }

            return isWin;
        }

        public char GetCell(int row, int col)
        {
            return m_Matrix[row, col];
        }
    }
}
