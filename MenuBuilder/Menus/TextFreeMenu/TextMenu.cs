using MenuBuilder.IO.Input;
using MenuBuilder.Menus.TextFreeMenu.exceptions;
using MenuBuilder.Menus.TextFreeMenu.options;
using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus.TextFreeMenu
{
    public class TextMenu : ITextMenu
    {
        public Dictionary<string, IOptions> MenuMap { get; set; }
        public List<IValidation> Validations { get; set; }

        public IOutputSystem OutputSystem { get; set; }


        public ISystemInput InputSystem { get; set; }
        public string Title { get; set; }

        public TextMenu(IMenuBuilder textMenuBuilder)
        {
            Title = textMenuBuilder.Title;
            MenuMap = textMenuBuilder.MenuMap;
            Validations = textMenuBuilder.Validations;

            OutputSystem = textMenuBuilder.OutputSystemOption;
            InputSystem = textMenuBuilder.InputSystem;

        }

        public string GetMenuString()
        {
            string msg = $"{Title} {Environment.NewLine}";
            foreach (var option in MenuMap)
            {
                msg += $" - {option.Key} {Environment.NewLine}";
            }
            return msg;
        }

        public IOptions GetOption(string option)
        {
            if (!MenuMap.ContainsKey(option))
            {
                return null;
            }
            return MenuMap[option];
        }

        public void Run()
        {
            string menuString = GetMenuString();

            OutputSystem.Print(menuString);
            OutputSystem.Print("Please enter the option you want");
            string opt = InputSystem.StringInput();

            try
            {
                ValidateInput(opt);
                IOptions optionRunner = GetOption(opt);
                optionRunner.Operation();
            }
            catch (TextMenuError menuError)
            {
                OutputSystem.Print($"text menu error validation with {menuError.Message}");

            }
            catch (Exception e)
            {
                OutputSystem.Print($"error : {e.Message}");

            }
            Run();

        }

        private string ValidateInput(string input)
        {
            bool runFlag = true;

            while (runFlag)
            {
                foreach (var validationOption in Validations)
                {
                    validationOption.validate(input);
                }

                IOptions option = GetOption(input);
                if (option == null)
                {
                    throw new TextOptionNotExistError("paramter not found in options");
                }
                runFlag = false;

            }
            return input;
        }
    }
}
