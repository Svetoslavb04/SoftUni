using System;
using System.Linq;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var phone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            var phoneNumbers = Console.ReadLine().Split().ToArray();
            var urls = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (phoneNumbers[i].Length == 7 || phoneNumbers[i].Length == 10)
                {
                    if (phoneNumbers[i].Length == 7)
                    {
                        stationaryPhone.Dial(phoneNumbers[i]);
                    }
                    else
                    {
                        phone.Call(phoneNumbers[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            for (int i = 0; i < urls.Length; i++)
            {
                phone.Browse(urls[i]);
            }
        }
    }
}
