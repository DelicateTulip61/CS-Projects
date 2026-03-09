using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Tests
{
    public class MenuAction : IMenuAction
    {
        private readonly Action m_Action;

        public MenuAction(Action i_Action)
        {
            m_Action = i_Action;
        }

        public void Execute()
        {
            if (m_Action != null)
            {
                m_Action.Invoke();
            }
        }
    }
}
