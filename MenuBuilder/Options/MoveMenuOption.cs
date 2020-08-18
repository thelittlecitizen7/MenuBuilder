using MenuBuilder.Menus;
using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus
{
    public class MoveMenuOption : IOptions
    {
        public IMenu Menu{ get; set; }
        public MoveMenuOption(IMenu menu)
        {
            Menu = menu;
        }
        public void Operation()
        {
            Menu.Run();
        }
    }
}
