using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex01_03
{
    public class Program
    {
        public static void Main ()
        {
            bool validHeight = false;
            int i_height = 0;
            Console.WriteLine("Please enter the height of the tree (a number between 4 and 15)");
            string userInput = Console.ReadLine();

            while (validHeight == false)
            {
                if (int.TryParse(userInput, out i_height))
                {
                    if (i_height >= 4 && i_height <= 15)
                    {
                        validHeight = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again...");
                        userInput = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, try again...");
                    userInput = Console.ReadLine();
                }
            }
            Console.WriteLine("\n");
            DynamicTree.PrintTree(i_height);
            Console.ReadLine();
        }
    }
}
