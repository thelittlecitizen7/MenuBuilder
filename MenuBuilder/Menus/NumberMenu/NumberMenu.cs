using MenuBuilder.IO.Input;
using MenuBuilder.Menus.NumberMenu.exceptions;
using MenuBuilder.Menus.NumberMenu.validations;
using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace MenuBuilder.Menus.NumberMenu
{
    public class NumberMenu : INumberMenu
    {
        public Dictionary<string, IOptions> MenuMap { get; set; }
        public List<IValidation> Validations { get; set; }

        public IOutputSystem OutputSystem { get; set; }


        public ISystemInput InputSystem { get; set; }
        public string Title { get ; set ; }

        public NumberMenu(IMenuBuilder numberMenuBuilder)
        {
            Title = numberMenuBuilder.Title;
            MenuMap = numberMenuBuilder.MenuMap;
            Validations = numberMenuBuilder.Validations;
            OutputSystem = numberMenuBuilder.OutputSystemOption;
            InputSystem = numberMenuBuilder.InputSystem;
        }


        public IOptions GetOption(int optionNumber)
        {
            int count = 0;
            foreach (var option in MenuMap)
            {
                if (count == optionNumber) 
                {
                    return option.Value;
                }
                count++;
            }
            return null;
        }

        public string GetMenuString()
        {
            string msg = $"{Title} {Environment.NewLine}";
            int count = 0;
            foreach (var option in MenuMap)
            {
                msg += $" {count}.  {option.Key}  {Environment.NewLine}";
                count++;
            }
            return msg;
        }


        public void Run() 
        {
            string menuString = GetMenuString();
            OutputSystem.Print(menuString);
            OutputSystem.Print("Please enter the number option you want");
            string opt = InputSystem.StringInput();

            try
            {
                int option = (int)ValidateInput(opt);
                IOptions optionRunner = GetOption(option);
                optionRunner.Operation();

            }
            catch (NumberMenuValidationError validationError)
            {
                OutputSystem.Print(validationError.Message);
            }
            catch (Exception e)
            {
                OutputSystem.Print($"Error occurd in this Menu {e.Message}");
            }
            Run();
        }
     

        private int ValidateInput(string input)
        {
            bool runFlag = true;

            while (runFlag)
            {
                    foreach (var validationOption in Validations)
                    {
                        validationOption.Validate(input);
                    }
                    IOptions option = GetOption(int.Parse(input));
                    if (option == null)
                    {
                        throw new NumberMenuValidationError("paramter not found in options");
                    }
                    runFlag = false;
            }
            return int.Parse(input);
        }
    }
}

