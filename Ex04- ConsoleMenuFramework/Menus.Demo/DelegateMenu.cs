using System;
using Ex04.Menus.Events;

namespace Ex04.Menus.Tests
{
    public class DelegateMenu
    {
        public static void Run()
        {
            MainMenu mainMenu = new MainMenu("Delegates Main Menu");

            MenuItem versionMenu = new MenuItem("Version and Lowercase");

            MenuItem showVersion = new MenuItem("Show Version");
            showVersion.Selected+= new Action<MenuItem>(ShowVersionAction);

            MenuItem countLowercase = new MenuItem("Count Lowercase");
            countLowercase.Selected += new Action<MenuItem>(CountLowercaseAction);

            versionMenu.AddSubItem(showVersion);
            versionMenu.AddSubItem(countLowercase);

            MenuItem timeMenu = new MenuItem("Show Current Date/Time");

            MenuItem showTime = new MenuItem("Show Current Time");
            showTime.Selected += new Action<MenuItem>(ShowTimeAction);

            MenuItem showDate = new MenuItem("Show Current Date");
            showDate.Selected += new Action<MenuItem>(ShowDateAction);

            timeMenu.AddSubItem(showTime);
            timeMenu.AddSubItem(showDate);

            mainMenu.AddMenuItem(versionMenu);
            mainMenu.AddMenuItem(timeMenu);

            mainMenu.Show();
        }

        private static void ShowVersionAction(MenuItem menu)
        {
            Actions.ShowVersion();
        }

        private static void CountLowercaseAction(MenuItem menu)
        {
            Actions.CountLowercase();
        }

        private static void ShowTimeAction(MenuItem menu)
        {
            Actions.ShowCurrentTime();
        }

        private static void ShowDateAction(MenuItem menu)
        {
            Actions.ShowCurrentDate();
        }
    }
}
