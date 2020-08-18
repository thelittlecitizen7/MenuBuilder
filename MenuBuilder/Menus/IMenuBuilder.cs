using MenuBuilder.IO.Input;
using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus
{
    public interface IMenuBuilder
    {
        string Title { get; set; }
        Dictionary<string, IOptions> MenuMap { get; set; }

        IOutputSystem OutputSystemOption { get; set; }

        ISystemInput InputSystem { get; set; }

        IMenuBuilder SetSystemOutput(IOutputSystem outputSystemOption);

        IMenuBuilder SetSystemInput(ISystemInput systemInputOption);

        IMenuBuilder AddOptions(string description, IOptions menuOptions);

        List<IValidation> Validations { get; set; }

        IMenuBuilder SetValidations(List<IValidation> validations);

        IMenu Build();

    }
}
