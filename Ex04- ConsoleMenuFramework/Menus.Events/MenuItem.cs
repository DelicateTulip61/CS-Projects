using System;
using System.Collections.Generic;


namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private readonly string r_Title;
        private readonly List<MenuItem> r_SubItems;
        public event Action<MenuItem> Selected;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
            r_SubItems = new List<MenuItem>();
        }

        public string Title
        {
            get { return r_Title; }
        }

        public IReadOnlyList<MenuItem> SubItems
        {
            get { return r_SubItems; }
        }

        public bool HasSubItems
        {
            get { return r_SubItems.Count > 0; }
        }

        public void AddSubItem(MenuItem i_Item)
        {
            r_SubItems.Add(i_Item);
        }

        public void Activate()
        {
            if (Selected != null)
            {
                Selected.Invoke(this);
            }
        }
    }
}
