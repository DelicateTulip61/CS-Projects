using System;
using System.Collections.Generic;


namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly string m_Title;
        private readonly List<MenuItem> m_MenuItems;

        public MainMenu(string i_Title)
        {
            m_Title = i_Title;
            m_MenuItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
        }

        public void Show()
        {
            showMenu(m_Title, m_MenuItems, true);
        }

        private void showMenu(string i_Title, List<MenuItem> i_Items, bool i_IsRoot)
        {
            bool exitRequested = false;


            while (!exitRequested)
            {
                Console.Clear();
                printTitle(i_Title);
                printItems(i_Items, i_IsRoot);


                int choice = readChoice(i_Items.Count);


                if (choice == 0)
                {
                    exitRequested = true;
                }
                else
                {
                    MenuItem selectedItem = i_Items[choice - 1];


                    if (selectedItem.HasSubItems)
                    {
                        showMenu(selectedItem.Title, new List<MenuItem>(selectedItem.SubItems), false);
                    }
                    else
                    {
                        Console.Clear();
                        selectedItem.Activate();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        }

        private void printTitle(string i_Title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"** {i_Title} **");
            Console.ResetColor();
            Console.WriteLine(new string('-', i_Title.Length + 6));
        }

        private void printItems(List<MenuItem> i_Items, bool i_IsRoot)
        {
            for (int i = 0; i < i_Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {i_Items[i].Title}");
            }

            if (i_IsRoot)
            {
                Console.WriteLine("0. Exit");
            }
            else
            {
                Console.WriteLine("0. Back");
            }
        }

        private int readChoice(int i_MaxChoice)
        {
            Console.Write($"Please enter your choice (1-{i_MaxChoice} or 0): ");
            string input = Console.ReadLine();
            int choice;

            while (!int.TryParse(input, out choice) || choice < 0 || choice > i_MaxChoice)
            {
                Console.WriteLine("Invalid choice, try again.");
                Console.Write($"Please enter your choice (1-{i_MaxChoice} or 0): ");
                input = Console.ReadLine();
            }

            return choice;
        }
    }
}