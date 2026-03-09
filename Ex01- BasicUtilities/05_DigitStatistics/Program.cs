using System;


namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            bool validresponse = false;
            string i_response = "?";

            while (validresponse != true)
            {
                Console.WriteLine("Please enter a 7 characters long number");
                i_response = Console.ReadLine();
                if (i_response.Length != 7 || NumberStatistics.AllDigits(i_response) == false)
                {
                    Console.WriteLine("Invalid input! try again...");
                }
                else
                {
                    validresponse = true;
                }
            }

            Console.WriteLine("\n");

            Console.WriteLine($"Leftmost number: {NumberStatistics.LeftmostNumber(i_response)}. " +
                $"digits bigger than it (excluding the first): {NumberStatistics.CountDigitsBiggerThanLeftmost(i_response)}");

            Console.WriteLine($"How many digits are divisible by 3?: {NumberStatistics.DivisibleByThreeCount(i_response)}");

            Console.WriteLine($"Difference between biggest and lowest digit is: {NumberStatistics.MinMaxDiff(i_response)}");

            NumberStatistics.MostCommonDigit(i_response);
            Console.ReadLine();
        }
    }
}
