using System;

namespace Ex04.Menus.Tests
{
    public static class Actions
    {
        public static void ShowVersion()
        {
            Console.WriteLine("App Version: 26.1.4.5940");
        }

        public static void CountLowercase()
        {
            Console.Write("Enter text: ");
            string input = Console.ReadLine();
            int count = 0;

            foreach (char letter in input)
            {
                if (char.IsLower(letter)) count++;
            }

            Console.WriteLine($"There are {count} lowercase letters in your text");
        }

        public static void ShowCurrentTime()
        {
            Console.WriteLine($"Current Time is {DateTime.Now:HH:mm:ss}");
        }

        public static void ShowCurrentDate()
        {
            Console.WriteLine($"Current Date is {DateTime.Now:dd/MM/yyyy}");
        }
    }
}
