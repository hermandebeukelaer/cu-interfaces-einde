using System;
using System.Collections.Generic;
using System.Text;
using Pra.Interfaces.CORE.Interfaces;

namespace Pra.Interfaces.CORE.Classes
{
    public class SmartLamp : ElectricalAppliance
    {

        public SmartLamp(string room) : base(room)
        {
        }
        public override string ToString()
        {
            return $"Smartlamp {Room}";
        }
    }
}
