using System;
using System.Linq;

namespace Ex01_04
{
    public class StringAnalyzer
    {
        public static bool IsInteger(string input)
        {
            return int.TryParse(input, out int result);
        }

        public static string DivisibleByThree(string input)
        {
            if (int.TryParse(input, out int result))
            {
                if (result % 3 == 0)
                {
                    return "Yes";
                }
                else return "No";
            }
            else return "No";

        }

        public static bool IsAllEnglishLetters(string input)
        {
            return input.All(Char.IsLetter);
        }

        public static int LowerCaseCount(string input)
        {
            int counter = 0 ;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLower(input[i])) 
                {
                    counter++;
                }
            }
            return counter;
        }

        public static string IsAscendingOrder (string input)
        {

            input = input.ToUpper();

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] < input[i - 1])
                {
                    return "No";
                }
            }

            return "Yes";
        }


        public static string IsPalindromeRecursive(string input, int left, int right)
        {

            if (left >= right)
            {
                return "Yes";
            }

            if (input[left] != input[right])
            {
                return "No";
            }
            
            return IsPalindromeRecursive(input, left + 1, right - 1);
        }


    }
}