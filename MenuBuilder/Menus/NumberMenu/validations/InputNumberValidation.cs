using MenuBuilder.Menus.NumberMenu.exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace MenuBuilder.Menus.NumberMenu.validations
{
    public class InputNumberValidation : IValidation
    {
        public void Validate(string number)
        {
            int numberTry;
            bool isNumber = int.TryParse(number,out numberTry);
            if (!isNumber) 
            {
                throw new InputMustBeNumberError("Input msut be type of number");
            }
        }
    }
}
