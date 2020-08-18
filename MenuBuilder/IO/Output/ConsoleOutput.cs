using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.output
{
    public class ConsoleOutput : IOutputSystem
    {
        public ConsoleOutput()
        {

        }
        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
