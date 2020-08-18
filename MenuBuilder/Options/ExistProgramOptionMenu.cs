using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.Menus
{
    public class ExistProgramOptionMenu : IOptions
    {
        public ExistProgramOptionMenu()
        {
        }
        public void Operation()
        {
            System.Environment.Exit(1);
        }
    }
}
