using System;

namespace _02._Radians_to_Degrees
{
    class Program
    {
        static void Main()
        {
            double rad = double.Parse(Console.ReadLine());
            double deg = rad * (180 / MathF.PI);

            Console.WriteLine(Math.Round(deg));
        }
    }
}
