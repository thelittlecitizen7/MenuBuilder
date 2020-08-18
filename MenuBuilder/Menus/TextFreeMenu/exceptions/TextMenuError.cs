using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus.TextFreeMenu.exceptions
{
    public class TextMenuError : Exception
    {
        public TextMenuError(string message) : base(message)
        {

        }
    }
}
