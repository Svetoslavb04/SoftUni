using System;

namespace from_m_to_km
{
    class Program
    {
        static void Main(string[] args)
        {
            var meters = double.Parse(Console.ReadLine());

            Console.WriteLine($"{meters/1000:F2}");

        }
    }
}
