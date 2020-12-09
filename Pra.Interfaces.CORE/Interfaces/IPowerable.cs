using System;
using System.Collections.Generic;
using System.Text;

namespace Pra.Interfaces.CORE.Interfaces
{
    public interface IPowerable
    {
        bool IsOn { get; }

        string PowerOn();
        string PowerOff();
    }
}
