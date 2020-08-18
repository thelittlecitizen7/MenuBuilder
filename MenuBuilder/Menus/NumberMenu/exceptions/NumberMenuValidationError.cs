using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MenuBuilder.Menus.NumberMenu.exceptions
{
    public class NumberMenuValidationError : Exception
    {
        public NumberMenuValidationError(string message) : base(message)
        {

        }
    }
}
