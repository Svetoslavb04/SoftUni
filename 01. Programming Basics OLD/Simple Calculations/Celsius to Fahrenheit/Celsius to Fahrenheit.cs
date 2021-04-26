using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = double.Parse(Console.ReadLine());
            var f = c * 1.8 + 32;
            Math.Round(f, 2);
            Console.WriteLine(f);
        }
    }
}
