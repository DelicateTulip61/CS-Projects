using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly string r_Title;
        private readonly List<MenuItem> r_SubItems;
        private readonly IMenuAction r_Action;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
            r_SubItems = new List<MenuItem>();
        }

        public MenuItem(string i_Title, IMenuAction i_Action)
        : this(i_Title)
        {
            r_Action = i_Action;
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

        public void AddSubItem(MenuItem i_SubItem)
        {
            r_SubItems.Add(i_SubItem);
        }

        public void Activate()
        {
            if (r_Action != null)
            {
                r_Action.Execute();
            }
        }
    }
}
