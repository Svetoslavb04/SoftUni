using System;
using System.Linq;

namespace _03.Telephony
{
    public class Smartphone : ISmartphone
    {
        public void Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }

            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string number)
        {
            if (!number.All(Char.IsDigit))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
            if (number.Length == 10)
            {
                Console.WriteLine($"Calling... {number}");
            }
        }
    }
}
