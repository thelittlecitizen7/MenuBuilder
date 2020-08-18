using MenuBuilder.Menus.NumberMenu.validations;
using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus.NumberMenu
{
    public interface INumberMenu : IMenu
    {
        IOptions GetOption(int optionNumber);   
    }
}
