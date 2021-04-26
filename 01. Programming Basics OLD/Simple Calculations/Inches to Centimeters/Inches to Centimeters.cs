using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            var inch = double.Parse(Console.ReadLine());
            double cm = inch * 2.54;

            Console.WriteLine(cm);
        }
    }
}
