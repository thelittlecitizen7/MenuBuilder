using MenuBuilder.Menus.NumberMenu;
using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus.TextFreeMenu
{
    public interface ITextMenu : IMenu
    {



        IOptions GetOption(string option);

        

    }
}
