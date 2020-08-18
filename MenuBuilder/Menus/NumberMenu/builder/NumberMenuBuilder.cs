using MenuBuilder.IO.Input;

using MenuBuilder.Menus.NumberMenu.validations;
using MenuBuilder.Options;
using MenuBuilder.output;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace MenuBuilder.Menus.NumberMenu
{
    public class NumberMenuBuilder : IMenuBuilder
    {
        public Dictionary<string, IOptions> MenuMap { get ; set; }
        public List<IValidation> Validations { get; set ; }

        public IOutputSystem OutputSystemOption { get ; set ; }
        public ISystemInput InputSystem { get ; set ; }
        public string Title { get ; set ; }

        public NumberMenuBuilder(string title)
        {
            Title = title;
            MenuMap = new Dictionary<string, IOptions>();
            Validations = new List<IValidation>() { new InputNumberValidation()};
            OutputSystemOption = new ConsoleOutput();
            InputSystem = new SystemInput();
        }


        public NumberMenuBuilder(string title , IOutputSystem outputSystem , SystemInput systemInput)
        {
            Title = title;
            MenuMap = new Dictionary<string, IOptions>();
            Validations = new List<IValidation>();
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
            validations.ForEach(v => Validations.Add(v));
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
            return new NumberMenu(this);
        }
    }
}
