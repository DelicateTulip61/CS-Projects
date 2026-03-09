using System;

namespace Ex02
{
    internal class Program
    {
        public static void Main()
        {
            Interface ui = new Interface();

            Console.WriteLine("Welcome to Connect Four!");
            bool isAgainstComputer = ui.AskIfPlayAgainstComputer();

            
            int rows = 0;
            int columns = 0;
            bool flag = false;

            while (flag == false)
            {
                Console.Write("Enter number of rows (4-8): ");
                int.TryParse(Console.ReadLine(), out rows);
                if (rows < 4 || rows > 8)
                {
                    Console.WriteLine("\nInvalid input, please make sure to insert a number between 4-8");
                }
                else
                {
                    flag = true;
                }
            }

            flag = false;

            while (flag == false)
            {
                Console.Write("Enter number of columns (4-8): ");
                int.TryParse(Console.ReadLine(), out columns);
                if (columns < 4 || columns > 8)
                {
                    Console.WriteLine("\nInvalid input, make sure to insert a number between 4-8");
                }
                else
                {
                    flag = true;
                }
            }

            GameManager gameManager = new GameManager(rows, columns, isAgainstComputer);
            gameManager.PlayGame();
            Console.ReadLine();
        }
    }
}
