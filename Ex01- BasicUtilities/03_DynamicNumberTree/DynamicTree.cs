using System;
using System.Text;

namespace Ex01_03
{
    public class DynamicTree
    {
        public static void PrintTree(int i_TreeHeight)
        { 
            int widthRow = (2 * i_TreeHeight) - 4;
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, };
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q' };

            StringBuilder result = new StringBuilder();
            int currentNumberIndex = 0;
            int currentRowIndex = 0;
            int numbersInCurrentRow = 1;

            for (int currentSpaces = widthRow; currentSpaces > 0; currentSpaces -= 2)
            {
                result.Append(letters[currentRowIndex++]);
                result.Append(new string(' ', currentSpaces));

                for (int i = 0; i < numbersInCurrentRow; i++)
                {
                    result.Append(numbers[currentNumberIndex++]);

                    if (currentNumberIndex >= numbers.Length)
                    {
                        currentNumberIndex = 0;
                    }

                    if (i < numbersInCurrentRow - 1)
                    {
                        result.Append(' ');
                    }
                }

                result.AppendLine();
                result.AppendLine();
                numbersInCurrentRow += 2;
            }

            for (int i = 0; i < 2; i++)
            {
                result.Append(letters[currentRowIndex++]);
                result.Append(new string(' ', widthRow - 1));
                result.Append($"|{numbers[currentNumberIndex]}|");

                if (currentNumberIndex >= numbers.Length)
                {
                    currentNumberIndex = 0;
                }

                result.AppendLine();
                result.AppendLine();
            }

            Console.WriteLine(result.ToString());
        }

    }
}