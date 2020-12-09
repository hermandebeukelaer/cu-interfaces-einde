using System;
using System.Collections.Generic;
using System.Text;
using Pra.Interfaces.CORE.Interfaces;

namespace Pra.Interfaces.CORE.Classes
{
    public class VolumeChangeableAppliance : ElectricalAppliance, IVolumeChangeable
    {
        public int CurrentVolume { get; private set; } = 50;

        public VolumeChangeableAppliance(string room) : base(room)
        {
        }

        public void VolumeUp()
        {
            CurrentVolume += 10;
            if (CurrentVolume > 100)
            {
                CurrentVolume = 100;
            }
        }

        public void VolumeDown()
        {
            CurrentVolume -= 10;
            if (CurrentVolume < 0)
            {
                CurrentVolume = 0;
            }
        }
    }
}
