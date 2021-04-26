using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var kilometers = int.Parse(Console.ReadLine());
            var time = Console.ReadLine();
            var taxi = 0.70;
            var bus = 0.09;
            var train = 0.06;

            if (kilometers <20)
            {
                if (time == "day")
                {
                    Console.WriteLine(taxi + (kilometers * 0.79));
                }
                else if (time == "night")
                {
                    Console.WriteLine(taxi + (kilometers * 0.90));
                }
            }
            else if (kilometers >= 20 && kilometers <100)
            {
                Console.WriteLine($"{kilometers * bus}");
            }
            else if (kilometers >= 100)
            {
                Console.WriteLine($"{kilometers * train}");
            }
        }
    }
}
