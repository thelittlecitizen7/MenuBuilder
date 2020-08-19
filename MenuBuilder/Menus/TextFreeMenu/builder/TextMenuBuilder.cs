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
        public Dictionary<string, IOptions> MenuMap { get; set; }
        public List<IValidation> Validations { get; set; }

        public IOutputSystem OutputSystemOption { get; set; }

        public ISystemInput InputSystem { get; set; }

        public string Title { get; set; }


        public TextMenuBuilder(string title)
        {
            Validations = new List<IValidation>();
            MenuMap = new Dictionary<string, IOptions>();
            Title = title;
            OutputSystemOption = new ConsoleOutput();
            InputSystem = new SystemInput();
        }

        public TextMenuBuilder(string title, IOutputSystem outputSystem, ISystemInput systemInput)
        {
            Validations = new List<IValidation>();
            MenuMap = new Dictionary<string, IOptions>();
            Title = title;
            OutputSystemOption = outputSystem;
            InputSystem = systemInput;
        }

        public IMenuBuilder AddOptions(string description, IOptions menuOptions)
        {
            MenuMap.Add(description, menuOptions);
            return this;
        }

        public IMenuBuilder SetValidations(List<IValidation> validations)
        {
            Validations = validations;
            return this;
        }

        public IMenuBuilder SetSystemOutput(IOutputSystem outputSystemOption)
        {
            OutputSystemOption = outputSystemOption;
            return this;
        }

        public IMenuBuilder SetSystemInput(ISystemInput systemInputOption)
        {
            InputSystem = systemInputOption;
            return this;
        }

        public IMenu Build()
        {
            return new TextMenu(this);
        }

    }
}
