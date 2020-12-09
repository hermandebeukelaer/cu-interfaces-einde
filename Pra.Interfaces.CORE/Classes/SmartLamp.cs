using System;
using System.Collections.Generic;
using System.Text;
using Pra.Interfaces.CORE.Interfaces;

namespace Pra.Interfaces.CORE.Classes
{
    public class SmartLamp : ElectricalAppliance, IPowerable
    {

        public bool IsOn { get; private set; }

        public SmartLamp(string room) : base(room)
        {
        }
        public string PowerOff()
        {
            IsOn = false;
            return $"Smartlamp {Room} is uit";
        }

        public string PowerOn()
        {
            IsOn = true;
            return $"Smartlamp {Room} is aan";
        }
    }
}
