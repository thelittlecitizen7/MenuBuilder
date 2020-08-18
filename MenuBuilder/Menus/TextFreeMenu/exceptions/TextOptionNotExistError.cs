using MenuBuilder.Menus.TextFreeMenu.exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus.TextFreeMenu.options
{
    public class TextOptionNotExistError : TextMenuError
    {
        public TextOptionNotExistError(string message) : base(message)
        {

        }
    }
}
