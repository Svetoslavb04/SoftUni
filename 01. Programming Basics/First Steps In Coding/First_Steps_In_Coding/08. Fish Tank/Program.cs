using System;

namespace _08._Fish_Tank
{
    class Program
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine()) / 100;

            double volume = length * width * height;
            double liters = volume * 0.001;
            liters = liters - (liters * percent);

            Console.WriteLine(liters);
        }
    }
}
