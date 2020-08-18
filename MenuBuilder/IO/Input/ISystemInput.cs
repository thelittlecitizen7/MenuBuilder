using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuilder.IO.Input
{
    public interface ISystemInput
    {
        string StringInput();

        int IntInput();
    }
}
