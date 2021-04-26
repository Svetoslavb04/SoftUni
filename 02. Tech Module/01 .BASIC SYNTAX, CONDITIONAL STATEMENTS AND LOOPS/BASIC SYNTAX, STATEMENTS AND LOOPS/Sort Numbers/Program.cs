using System;

namespace Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = double.Parse(Console.ReadLine());
            var second = double.Parse(Console.ReadLine());
            var third = double.Parse(Console.ReadLine());

            if (second > third)
            {
                if (first > second)
                {
                    Console.WriteLine($"{first}");                   
                    Console.WriteLine($"{second}");
                    Console.WriteLine($"{third}");

                }
            }
            else if (third > second)
            {
                if (third > first && second > first)
                {
                    Console.WriteLine($"{third}");
                    Console.WriteLine($"{second}");
                    Console.WriteLine($"{first}");
                }
                else
                {
                    Console.WriteLine($"{third}");
                    Console.WriteLine($"{first}");
                    Console.WriteLine($"{second}");


                }
            }
        }
    }
}
