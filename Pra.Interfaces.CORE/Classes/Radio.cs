using System;
using System.Collections.Generic;
using System.Text;
using Pra.Interfaces.CORE.Interfaces;

namespace Pra.Interfaces.CORE.Classes
{
    public class Radio : VolumeChangeableAppliance, IConnectionCheckable
    {
        static readonly Random rnd = new Random();

        public Radio(string room) : base(room)
        {
        }

        public string CheckBroadcastConnection()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"=========== Testing {GetType().Name} {Room} ===========");
            stringBuilder.AppendLine("Is antenna extended? Checking antenna...");
            stringBuilder.AppendLine($"Antenna extended test returns {IsAntennaExtended()}");

            stringBuilder.AppendLine("Is FM working? Checking FM...");
            stringBuilder.AppendLine($"FM working test returns {IsFmWorking()}");
            stringBuilder.AppendLine($"---------- End of test {GetType().Name} {Room} ---------- {Environment.NewLine}");

            return stringBuilder.ToString();
        }

        private bool IsFmWorking()
        {
            int trueOrFalse = rnd.Next(2);
            return Convert.ToBoolean(trueOrFalse);
        }

        private bool IsAntennaExtended()
        {
            int trueOrFalse = rnd.Next(2);
            return Convert.ToBoolean(trueOrFalse);
        }

        public override string ToString()
        {
            return $"Radio {Room}";
        }
    }
}
