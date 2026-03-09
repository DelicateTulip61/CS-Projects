using System;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            bool validresponse = false;
            string i_response = "?";

            while (validresponse != true)
            {
                Console.WriteLine("Please enter a 10 characters long string");
                i_response = Console.ReadLine();
                if (i_response.Length != 10)
                {
                    Console.WriteLine("Invalid input! try again...");
                }
                else
                {
                    validresponse = true;
                }
            }

            Console.WriteLine("\n");

            Console.WriteLine(string.Format("Is Palindrome?: {0}",
                StringAnalyzer.IsPalindromeRecursive(i_response, 0, i_response.Length - 1)));


            if (StringAnalyzer.IsAllEnglishLetters(i_response) == true)
            {
                Console.WriteLine($"Number of lowercase letters: {StringAnalyzer.LowerCaseCount(i_response)}");

                Console.WriteLine($"Is in alphabetically ascending order?: {StringAnalyzer.IsAscendingOrder(i_response)}");
            }

            else
            {
                if (StringAnalyzer.IsInteger(i_response) == true)
                {


                    Console.WriteLine($"Is divisible by 3 without a remainder?: {StringAnalyzer.DivisibleByThree(i_response)}");
                }
            }
            Console.ReadLine();
        }
    }
}
