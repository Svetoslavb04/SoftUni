using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapeziod_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            var ab = double.Parse(Console.ReadLine());
            var cd = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            var area = (ab + cd) * h / 2;
            Console.WriteLine(area);


        }
    }
}
