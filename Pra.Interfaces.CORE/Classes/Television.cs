using System;
using System.Collections.Generic;
using System.Text;
using Pra.Interfaces.CORE.Interfaces;

namespace Pra.Interfaces.CORE.Classes
{
    public class Television : ElectricalAppliance, IPowerable, IVolumeChangeable, IConnectionCheckable
    {
        static readonly Random rnd = new Random();

        public bool IsOn { get; private set; }
        public int CurrentVolume { get; private set; } = 50;

        public Television(string room) : base(room)
        {
        }

        public string PowerOff()
        {
            IsOn = false;
            return $"TV {Room} is uit";
        }

        public string PowerOn()
        {
            IsOn = true;
            return $"TV {Room} is aan";
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

        public string CheckBroadcastConnection()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"=========== Testing {this.GetType().Name} {Room} ===========");
            stringBuilder.AppendLine("Is COAX connected? Checking connection...");
            stringBuilder.AppendLine($"COAX connected test returns {IsCoaxCableConnected()} {Environment.NewLine}");

            stringBuilder.AppendLine("Is signal available? Checking signal...");
            stringBuilder.AppendLine($"Signal available test returns {IsSignalAvailable()}");
            stringBuilder.AppendLine($"Signal strength test returns {IsSignalStrengthOk()}");
            stringBuilder.AppendLine($"---------- End of test {this.GetType().Name} {Room} ---------- {Environment.NewLine}");

            return stringBuilder.ToString();
        }

        private bool IsCoaxCableConnected()
        {
            int trueOrFalse = rnd.Next(2);

            return Convert.ToBoolean(trueOrFalse);
        }

        private bool IsSignalStrengthOk()
        {
            int trueOrFalse = rnd.Next(2);

            return Convert.ToBoolean(trueOrFalse);
        }
        private bool IsSignalAvailable()
        {
            int trueOrFalse = rnd.Next(2);

            return Convert.ToBoolean(trueOrFalse);
        }
    }
}