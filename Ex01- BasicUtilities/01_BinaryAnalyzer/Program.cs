using System;
namespace EX01_01
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter 3 binary numbers, each with 8 digits");
            BinaryActions binaryNumbers = new BinaryActions();

            int i = 0;

            while (i != 3)
            {
                string i_String = Console.ReadLine();

                if (BinaryActions.CheckIfNumberIsBinary(i_String) == true)
                {
                    binaryNumbers.SetBinaryValue(i, i_String);
                    i++;
                }
                else
                {
                    Console.WriteLine("invalid input, try again....");
                }
            }

            Console.WriteLine("\n");
            binaryNumbers.BinaryToDecimal();
            binaryNumbers.PrintInAscendingOrder();
            binaryNumbers.PrintAverage();
            binaryNumbers.PrintShortestBitSequence();
            binaryNumbers.PrintNumberOfPalindromes();
            binaryNumbers.PrintMaximumDifference();
            binaryNumbers.PrintSameStartEnd();
            Console.ReadLine();
        }
    }
}