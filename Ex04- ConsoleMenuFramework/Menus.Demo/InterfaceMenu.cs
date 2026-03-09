using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;



namespace Ex04.Menus.Tests
{
    public class InterfaceMenu
    {
        public static void Run()
        {
            MainMenu mainMenu = new MainMenu("Interfaces Main Menu");


            MenuItem item1 = new MenuItem("Version and Lowercase");
            item1.AddSubItem(new MenuItem("Show Version", new MenuAction(Actions.ShowVersion)));
            item1.AddSubItem(new MenuItem("Count Lowercase", new MenuAction(Actions.CountLowercase)));

         
            MenuItem item2 = new MenuItem("Show Current Date/Time");
            item2.AddSubItem(new MenuItem("Show Current Time", new MenuAction(Actions.ShowCurrentTime)));
            item2.AddSubItem(new MenuItem("Show Current Date", new MenuAction(Actions.ShowCurrentDate)));

            mainMenu.AddMenuItem(item1);
            mainMenu.AddMenuItem(item2);

            mainMenu.Show();
        }
    }
}
