using System;

namespace EX01_01
{
    class BinaryActions
    {
        const int k_NumberOfValues = 3;
        private string[] m_BinaryString = new string[k_NumberOfValues];
        private double[] m_DecimalValue = new double[k_NumberOfValues];

        public void SetBinaryValue(int i_Index, string i_Value)
        {
            m_BinaryString[i_Index] = i_Value;
        }

        public static bool CheckIfNumberIsBinary(string i_String)
        {
            int requiredLengthNumber = 8;

            if (i_String.Length != requiredLengthNumber)
            {                   
                return false;
            }
            for (int i = 0; i < requiredLengthNumber; i++)
            {
                if (i_String[i] != '0' && i_String[i] != '1')
                {
                    return false;
                }
            }               
            return true;
        }

        public void BinaryToDecimal()
        {
            for (int j = 0; j < k_NumberOfValues; j++)
            {
                double resultNumber = 0;
                for (int i = 0, pow = 7; i <= 7; i++, pow--)
                {
                    if (m_BinaryString[j][i] == '1')
                    {
                        resultNumber += Math.Pow(2, pow);
                    }
                    else
                    {
                        continue;
                    }
                }
                m_DecimalValue[j] = resultNumber;
            }
        }

        public void PrintInAscendingOrder() // assuming array size is 3
        {
            if (m_DecimalValue[0] > m_DecimalValue[1])
            {
                swap(0, 1);
            }
            if (m_DecimalValue[1] > m_DecimalValue[2])
            {
                swap(1, 2);
            }
            if (m_DecimalValue[0] > m_DecimalValue[1])
            {
                swap(0, 1);
            }
            Console.Write("Decimal numbers in ascending order: ");
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"{m_DecimalValue[i]} ({m_BinaryString[i]}), ");
            }
            Console.WriteLine(m_DecimalValue[2] + " (" + m_BinaryString[2] + ") ");
        }

        public void PrintAverage()
        {
            double sum = 0;

            for (int i = 0; i < k_NumberOfValues; i++)
            {
                sum += m_DecimalValue[i];
            }

            Console.WriteLine("Average: " + (sum / k_NumberOfValues).ToString("F2"));
        }
        private void swap(int a, int b)
        {
            // swap decimals
            double tmpValue = m_DecimalValue[a];
            m_DecimalValue[a] = m_DecimalValue[b];
            m_DecimalValue[b] = tmpValue;

            // swap binary
            string tmpStr = m_BinaryString[a];
            m_BinaryString[a] = m_BinaryString[b];
            m_BinaryString[b] = tmpStr;
        }

        public void PrintShortestBitSequence()
        {
            int[] shortestRuns = new int[k_NumberOfValues];
            char[] shortestBits = new char[k_NumberOfValues];

            for (int j = 0; j < k_NumberOfValues; j++)
            {
                string bits = m_BinaryString[j];
                int minRun = int.MaxValue;
                char minBit = '?';
                int currentRun = 1;
                char currentBit = bits[0];

                for (int i = 1; i < bits.Length; i++)
                {
                    if (bits[i] == currentBit)
                    {
                        currentRun++;
                    }
                    else
                    {
                        if (currentRun < minRun)
                        {
                            minRun = currentRun;
                            minBit = currentBit;
                        }
                        currentRun = 1;
                        currentBit = bits[i];
                    }
                }

                if (currentRun < minRun)
                {
                    minRun = currentRun;
                    minBit = currentBit;
                }

                shortestRuns[j] = minRun;
                shortestBits[j] = minBit;
            }

            int veryMinimum = shortestRuns[0];
            char shortestBit = shortestBits[0];

            for (int j = 1; j < k_NumberOfValues; j++)
            {
                if (shortestRuns[j] < veryMinimum)
                {
                    veryMinimum = shortestRuns[j];
                    shortestBit = shortestBits[j];
                }
            }

            Console.Write($"Shortest bit sequence: {veryMinimum} (");

            bool firstPrinted = false;

            for (int j = 0; j < k_NumberOfValues; j++)
            {
                if (shortestRuns[j] == veryMinimum)
                {
                    if (firstPrinted == true)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(m_BinaryString[j]);
                    firstPrinted = true;
                }
            }

            Console.WriteLine(")");
        }

        private bool isPalindrome(string i_CurrentString)
        {
            int startingIndex = 0;
            int endIndex = i_CurrentString.Length - 1;

            while (startingIndex < endIndex)
            {
                if (i_CurrentString[startingIndex] != i_CurrentString[endIndex])
                {
                    return false;
                }
                startingIndex++;
                endIndex--;
            }
            return true;
        }

        public void PrintNumberOfPalindromes()
        {
            int count = 0;
            int[] indexKeeper = new int[k_NumberOfValues];

            for (int i = 0; i < k_NumberOfValues; i++)
            {
                if (isPalindrome(m_BinaryString[i]) == true)
                {
                    indexKeeper[count] = i;
                    count++;
                }
            }

            Console.Write($"Number of Palindromes: {count} (");

            bool firstPrinted = false;

            for (int i = 0; i < count; i++)
            {
                if (firstPrinted == true)
                {
                    Console.Write(", ");
                }
                Console.Write($"{m_BinaryString[indexKeeper[i]]}");
                firstPrinted = true;
            }
            Console.WriteLine(")");
        }

        public void PrintMaximumDifference()
        {
            int maxDiff = int.MinValue;
            string maxDiffString = "?";
            double maxDiffDecimal = double.MinValue;

            for (int i = 0; i < k_NumberOfValues; i++)
            {
                int oneCounter = 0;
                int zeroCounter = 0;

                for (int j = 0; j < m_BinaryString[i].Length; j++)
                {
                    if (m_BinaryString[i][j] == '1')
                    {
                        oneCounter++;
                    }
                    else
                    {
                        zeroCounter++;
                    }
                }

                int currentDiff = Math.Abs(oneCounter - zeroCounter);

                if (currentDiff > maxDiff)
                {
                    maxDiff = currentDiff;
                    maxDiffString = m_BinaryString[i];
                    maxDiffDecimal = m_DecimalValue[i];
                }
            }

            Console.WriteLine($"Number with maximum difference between 1s and 0s: " +
                    $"{maxDiffDecimal} ({maxDiffString}) - difference of {maxDiff}");
        }
        public bool SameStartEnd(string currentString)
        {
            if (currentString[0] == currentString[currentString.Length - 1])
            {
                return true;
            }
            else return false;
        }

        public void PrintSameStartEnd()
        {
            int counter = 0;
            int[] indexKeeper = new int[k_NumberOfValues];

            for (int i = 0; i < k_NumberOfValues; i++)
            {
                if (SameStartEnd(m_BinaryString[i]) == true)
                {
                    indexKeeper[counter] = i;
                    counter++;
                }
            }

            Console.Write($"Numbers that start and end with same digit: {counter} (");

            bool firstPrinted = false;

            for (int i = 0; i < counter; i++)
            {
                if (firstPrinted == true)
                {
                    Console.Write(", ");
                }
                Console.Write($"{m_BinaryString[indexKeeper[i]]}");
                firstPrinted = true;
            }
            Console.WriteLine(")");
        }
    }
}
