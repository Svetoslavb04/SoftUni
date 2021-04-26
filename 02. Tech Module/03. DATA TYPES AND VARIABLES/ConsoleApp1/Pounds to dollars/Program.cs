using System;

namespace Pounds_to_dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            var pounds = double.Parse(Console.ReadLine());

            Console.WriteLine($"{pounds*1.31:F3}");

        }
    }
}
