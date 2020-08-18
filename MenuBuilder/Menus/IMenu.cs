using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus
{
    public interface IMenu
    {
        List<IValidation> Validations { get; set; }

        string GetMenuString();
        string Title { get; set; }
        Dictionary<string, IOptions> MenuMap { get; set; }
        void Run();
    }
}
