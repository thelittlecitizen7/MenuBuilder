using MenuBuilder;
using MenuBuilder.IO.Input;
using MenuBuilder.Menus;
using MenuBuilder.Menus.NumberMenu;
using MenuBuilder.Menus.NumberMenu.exceptions;
using MenuBuilder.Menus.NumberMenu.validations;
using MenuBuilder.Menus.TextFreeMenu;
using MenuBuilder.Menus.TextFreeMenu.options;
using MenuBuilder.output;
using System;
using System.Collections.Generic;

namespace MenuBuilderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenuBuilder textMenuBuilder = new TextMenuBuilder("Menu Text").
               AddOptions("Exist", new ExistProgramOptionMenu());

            List<IValidation> validations = new List<IValidation>();
            validations.Add(new InputNumberValidation());

            IMenuBuilder numberMenuBuilder = new NumberMenuBuilder("Menu Number")
                 .AddOptions("Exist", new ExistProgramOptionMenu())
                 .AddOptions("Move to Other", new MoveMenuOption(textMenuBuilder.Build()))
                 .SetValidations(validations);

            textMenuBuilder.AddOptions("Move", new MoveMenuOption(numberMenuBuilder.Build()));

            textMenuBuilder.Build().Run();
        }
    }
}
