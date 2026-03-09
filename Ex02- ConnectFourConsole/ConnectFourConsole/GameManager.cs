using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class GameManager
    {
        private Player m_Player1;
        private Player m_Player2;
        private Board m_GameBoard;
        private Random m_Random;
        private Interface m_Interface;



        public GameManager(int rows, int columns, bool isAgainstComputer)
        {
            m_Player1 = new Player("Player 1", 'X', true);
            m_Player2 = new Player(isAgainstComputer ? "Computer" : "Player 2", 'O', !isAgainstComputer);
            m_GameBoard = new Board(rows, columns);
            m_Random = new Random();
            m_Interface = new Interface();
        }

        public void PlayGame()
        {
            bool playAgain = true;

            while (playAgain)
            {
                m_GameBoard = new Board(m_GameBoard.Rows, m_GameBoard.Columns);
                PlayRound();
                playAgain = m_Interface.AskForAnotherRound();
            }

            Console.WriteLine("\nFinal Score:");
            m_Interface.DisplayScore(m_Player1, m_Player2);

            if (m_Player1.Points > m_Player2.Points)
            {
                Console.WriteLine($"Overall winner: {m_Player1.Nickname}!");
            }
            else if (m_Player2.Points > m_Player1.Points)
            {
                Console.WriteLine($"Overall winner: {m_Player2.Nickname}!");
            }
            else
            {
                Console.WriteLine("The game ended in a tie!");
            }
            Console.WriteLine("Thanks for playing!");
        }

        public void PlayRound()
        {
            Player currentPlayer = m_Player1;
            bool roundOver = false;

            while (roundOver == false)
            {
                m_Interface.DisplayBoard(m_GameBoard);

                int column;

                if (currentPlayer.IsHuman)
                {
                    bool validMove = false;
                    column = -1;

                    while (!validMove)
                    {
                        column = m_Interface.GetPlayerMove(currentPlayer, m_GameBoard); // player move

                        if (column == -1) // player chose to quit
                        {
                            break;
                        }

                        if (!m_GameBoard.IsColumnFull(column))
                        {
                            validMove = true; // valid column
                        }
                        else
                        {
                            Console.WriteLine("\nColumn full, please choose another one.\n"); // show message and ask again
                        }
                    }
                }
                else // random computer move
                {
                    List<int> availableColumns = new List<int>();

                    for (int i = 0; i < m_GameBoard.Columns; i++)
                    {
                        if (!m_GameBoard.IsColumnFull(i))
                        {
                            availableColumns.Add(i);
                        }
                    }

                    column = availableColumns[m_Random.Next(availableColumns.Count)]; 
                }

                if (column == -1) // check if player quit.
                {
                    Player otherPlayer;

                    if (currentPlayer == m_Player1)
                    {
                        otherPlayer = m_Player2;
                    }
                    else
                    {
                        otherPlayer = m_Player1;
                    }

                    otherPlayer.Points++;
                    m_Interface.ShowQuit(currentPlayer);
                    roundOver = true;
                    break;
                }

                if (m_GameBoard.TryInsertPiece(column, currentPlayer.Piece, out int rowInserted) == true) // try inserting piece.
                {
                    m_Interface.DisplayBoard(m_GameBoard);

                    if (m_GameBoard.CheckWin(currentPlayer.Piece) == true) // check for win.
                    {
                        currentPlayer.Points++;
                        m_Interface.ShowWin(currentPlayer);
                        m_Interface.DisplayScore(m_Player1, m_Player2);
                        roundOver = true;
                    }
                    else if (m_GameBoard.IsBoardFull() == true) // check for draw.
                    {
                        m_Interface.ShowDraw();
                        m_Interface.DisplayScore(m_Player1, m_Player2);
                        roundOver = true;
                    }
                    else 
                    {
                        if (currentPlayer == m_Player1)
                        {
                            currentPlayer = m_Player2;
                        }
                        else
                        {
                            currentPlayer = m_Player1;
                        }
                    }
                }
            }
        }

    }


}
