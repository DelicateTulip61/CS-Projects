using Ex04.Menus.Tests;
using System;

namespace Test.Menus04.Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceMenu.Run();

            DelegateMenu.Run();

            Console.WriteLine("All menus completed. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
