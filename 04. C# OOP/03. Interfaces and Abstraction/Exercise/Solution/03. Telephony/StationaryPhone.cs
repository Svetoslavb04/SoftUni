using System;
using System.Linq;

namespace _03.Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public void Dial(string number)
        {
            if (!number.All(Char.IsDigit))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
            if (number.Length == 7)
            {
                Console.WriteLine($"Dialing... {number}");
            }
        }
    }
}
