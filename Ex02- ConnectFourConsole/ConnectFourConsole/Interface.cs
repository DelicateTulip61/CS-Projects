using System;

namespace Ex02
{
    internal class Interface
    {
        public void DisplayBoard(Board board)
        {
            Console.Clear();

            for (int column = 0; column < board.Columns; column++)
            {
                Console.Write(" ");
                Console.Write((char)('A' + column));
            }
            Console.WriteLine();

            
            for (int row = 0; row < board.Rows; row++)
            {
                for (int column = 0; column < board.Columns; column++)
                {
                    Console.Write("|" + board.GetCell(row, column));
                }
                Console.WriteLine("|");
                Console.WriteLine(new string('=', board.Columns * 2 + 1));
            }
        }

        public int GetPlayerMove(Player player, Board board)
        {
            Console.WriteLine($"{player.Nickname} ({player.Piece}), choose a column (A-{(char)('A' + board.Columns - 1)}) or Q to quit:");

            while (true)
            {
                string input = Console.ReadLine().ToUpper();

                if (input == "Q")
                {
                    return -1; // Player quit.
                }

                if (input.Length == 1)
                {
                    char columnChar = input[0];
                    int columnIndex = columnChar - 'A';

                    if (columnIndex >= 0 && columnIndex < board.Columns)
                    {
                        return columnIndex;
                    }
                }

                Console.WriteLine("Invalid input. Please try again:");
            }
        }

        public void ShowWin(Player player)
        {
            Console.WriteLine($"\nCongratulations {player.Nickname}! You won the round !");
        }

        public void ShowDraw()
        {
            Console.WriteLine("\nNo more moves possible, It's a draw! ");
        }

        public void ShowQuit(Player quittingPlayer)
        {
            Console.WriteLine($"\n{quittingPlayer.Nickname} quit the game. The other player gets a point.");
        }

        public void DisplayScore(Player player1, Player player2)
        {
            Console.WriteLine($"\nScore:\n{player1.Nickname} ({player1.Piece}) = {player1.Points}\n{player2.Nickname} ({player2.Piece}) = {player2.Points}\n");
        }

        public bool AskForAnotherRound()
        {
            Console.WriteLine("Do you want to play another round? (Y/N)");
            string input = Console.ReadLine().ToUpper();

            return input == "Y";
        }

        public bool AskIfPlayAgainstComputer()
        {
            Console.WriteLine("Do you want to play against the computer? (Y/N), \nif not a 2 player game will start");
            bool result = false; 
            bool validInput = false;

            while (validInput == false)
            {
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    result = true;
                    validInput = true;
                }
                else if (input == "N")
                {
                    result = false;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N:");
                }
            }
            return result; 
        }
    }
}
