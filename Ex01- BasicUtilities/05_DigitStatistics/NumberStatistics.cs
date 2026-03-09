using System;


namespace Ex01_05
{
    public class NumberStatistics
    {

        public static bool AllDigits (string input)
        {
            for (int i = 0; i < input.Length; i++) 
            {
                if (char.IsDigit(input[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static char LeftmostNumber (string input)
        {
            return input[0];
        }
        public static int CountDigitsBiggerThanLeftmost (string input)
        {
            int counter = 0;
            char leftmost = LeftmostNumber(input);

            for (int i=0;i<input.Length;i++)
            {
                char digit = input[i];
                if (digit > leftmost) 
                {
                    counter++;
                }
            }
            return counter;
        }

        public static int DivisibleByThreeCount (string input)
        {
            int counter = 0;
            for (int i = 0;i < input.Length;i++)
            {
                int digit = int.Parse(input[i].ToString());
                if (digit % 3 == 0) 
                {
                    counter++;
                }
            }
            return counter;
        }

        public static int MinMaxDiff(string input)
        {
            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 0; i < input.Length; i++)
            {
                int digit = int.Parse(input[i].ToString());
                if (digit > max)
                {
                    max = digit;
                }
                if (digit < min)
                {
                    min = digit;
                }
            }

            return max - min;
        }

        public static int CountDigit(string input, char digitCheck)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == digitCheck)
                {
                    count++;
                }
            }
            return count;
        }


        public static void MostCommonDigit(string input)
        {
            char mostCommon = '?';
            int highestCount = -1;

            for (char digitChar = '0'; digitChar <= '9'; digitChar++)
            {
                int count = CountDigit(input, digitChar); 

                if (count > highestCount)
                {
                    highestCount = count;
                    mostCommon = digitChar;
                }
            }

            Console.WriteLine($"The most common digit is : {mostCommon} (it appears {highestCount} times).");
        }


    }
}
