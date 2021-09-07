using System;

namespace ConsoleMenus
{
    public class MenuItem
    {
        public string Text { get; set; }

        public MenuItem(string text)
        {
            Text = text;
        }

        public MenuItem()
        {
        }
    }
}