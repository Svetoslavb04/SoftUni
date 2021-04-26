using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var sideA = x1 - x2;
            var sideB = y1 - y2;

            if (x1 < x2)
                {
                sideA = x2 - x1;
                }

            if (y1 < y2)
                {
                sideB = y2 - y1; 
                }
            var s = sideA * sideB;
            var p = 2 * (sideA + sideB);
            Console.WriteLine(s);
            Console.WriteLine(p);



        }
    }
}
