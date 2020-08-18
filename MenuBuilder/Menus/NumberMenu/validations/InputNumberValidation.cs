using MenuBuilder.Menus.NumberMenu.exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace MenuBuilder.Menus.NumberMenu.validations
{
    public class InputNumberValidation : IValidation
    {
        public void Validate(string input)
        {
            int numberTry;
            bool isNumber = int.TryParse(input,out numberTry);
            if (!isNumber) 
            {
                throw new InputMustBeNumberError($"Input : {input} msut be type of number");
            }
        }
    }
}
