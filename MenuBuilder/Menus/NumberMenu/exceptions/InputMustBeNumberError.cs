using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus.NumberMenu.exceptions
{
    public class InputMustBeNumberError : NumberMenuValidationError
    {
        public InputMustBeNumberError(string message) : base(message)
        {

        }
    }
}
