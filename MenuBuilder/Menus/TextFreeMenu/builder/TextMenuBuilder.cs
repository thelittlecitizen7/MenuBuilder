using MenuBuilder.IO.Input;
using MenuBuilder.Menus.TextFreeMenu.options;

using MenuBuilder.Options;
using MenuBuilder.output;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MenuBuilder.Menus.TextFreeMenu
{
    public class TextMenuBuilder : IMenuBuilder
    {
        public Dictionary<string, IOptions> MenuMap { get ; set ; }
        public List<IValidation> Validations { get ; set ; }

        public IOutputSystem OutputSystemOption { get; set; }

        public ISystemInput InputSystem { get; set; }
        

        public string Title { get; set; }


        public TextMenuBuilder(string title)
        {
            Validations = new List<IValidation>();
            MenuMap = new Dictionary<string, IOptions>();
            Title = title;
        }

        public Menus.IMenuBuilder AddOptions(string description, IOptions menuOptions)
        {
            MenuMap.Add(description, menuOptions);
            return this;
        }

        

        public Menus.IMenuBuilder SetValidations(List<IValidation> validations)
        {
            Validations = validations;
            return this;
        }

        public Menus.IMenuBuilder SetSystemOutput(IOutputSystem outputSystemOption) 
        {
            OutputSystemOption = outputSystemOption;
            return this;
        }


        public Menus.IMenuBuilder SetSystemInput(ISystemInput systemInputOption)
        {
            InputSystem = systemInputOption;
            return this;
        }


        public IMenu Build()
        {
            ValidationParams();
            return new TextMenu(this);
        }

        private void ValidationParams()
        {
            if (OutputSystemOption == null)
            {
                OutputSystemOption = new ConsoleOutput();
            }
            if (InputSystem == null)
            {
                InputSystem = new SystemInput();
            }
        }
    }
}
