using System;
using System.Text;

namespace Ex01_02
{
    public class NumbersTree
    {
        public static void PrintTree()
        {
            const int k_WidthRow = 10;
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

            StringBuilder treeResult = new StringBuilder();
            int currentNumberIndex = 0;
            int currentRowIndex = 0;
            int numbersInCurrentRow = 1;

            for (int currentSpaces = k_WidthRow; currentSpaces > 0; currentSpaces -= 2)
            {
                treeResult.Append(letters[currentRowIndex++]);
                treeResult.Append(new string(' ', currentSpaces));

                for (int i = 0; i < numbersInCurrentRow; i++)
                {
                    treeResult.Append(numbers[currentNumberIndex++]);

                    if (currentNumberIndex >= numbers.Length)
                    {
                        currentNumberIndex = 0;
                    }

                    if (i < numbersInCurrentRow - 1)
                    {
                        treeResult.Append(' ');
                    }
                }

                treeResult.AppendLine();
                treeResult.AppendLine();
                numbersInCurrentRow += 2;
            }

            for (int i = 0; i < 2; i++)
            {
                treeResult.Append(letters[currentRowIndex++]);
                treeResult.Append(new string(' ', k_WidthRow - 1));
                treeResult.Append($"|{numbers[currentNumberIndex]}|");

                if (currentNumberIndex >= numbers.Length)
                {
                    currentNumberIndex = 0;
                }

                treeResult.AppendLine();
                treeResult.AppendLine();
            }

            Console.WriteLine(treeResult.ToString());
        }
    }
}
        