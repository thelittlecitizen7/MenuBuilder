using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.IO.Input
{
    public class SystemInput : ISystemInput
    {
        public SystemInput()
        {
        }

        public string StringInput()
        {
            return Console.ReadLine();
        }
    }
}
