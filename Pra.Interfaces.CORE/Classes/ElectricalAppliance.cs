using System;
using System.Collections.Generic;
using System.Text;
using Pra.Interfaces.CORE.Interfaces;

namespace Pra.Interfaces.CORE.Classes
{
    public abstract class ElectricalAppliance : IPowerable
    {
        public string Room { get;}
        public bool IsOn { get; private set; }


        public ElectricalAppliance(string room)
        {
            Room = room;
        }

        public string PowerOff()
        {
            IsOn = false;
            return $"{ToString()} is uit";
        }

        public string PowerOn()
        {
            IsOn = true;
            return $"{ToString()} is aan";
        }
    }
}
