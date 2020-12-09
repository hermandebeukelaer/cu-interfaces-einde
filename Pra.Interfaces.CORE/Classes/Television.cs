using System;
using System.Collections.Generic;
using System.Text;
using Pra.Interfaces.CORE.Interfaces;

namespace Pra.Interfaces.CORE.Classes
{
    public class Television : VolumeChangeableAppliance, IConnectionCheckable
    {
        static readonly Random rnd = new Random();

        public Television(string room) : base(room)
        {
        }

        public string CheckBroadcastConnection()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"=========== Testing {GetType().Name} {Room} ===========");
            stringBuilder.AppendLine("Is COAX connected? Checking connection...");
            stringBuilder.AppendLine($"COAX connected test returns {IsCoaxCableConnected()} {Environment.NewLine}");

            stringBuilder.AppendLine("Is signal available? Checking signal...");
            stringBuilder.AppendLine($"Signal available test returns {IsSignalAvailable()}");
            stringBuilder.AppendLine($"Signal strength test returns {IsSignalStrengthOk()}");
            stringBuilder.AppendLine($"---------- End of test {GetType().Name} {Room} ---------- {Environment.NewLine}");

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
        public override string ToString()
        {
            return $"Televisie {Room}";
        }
    }
}