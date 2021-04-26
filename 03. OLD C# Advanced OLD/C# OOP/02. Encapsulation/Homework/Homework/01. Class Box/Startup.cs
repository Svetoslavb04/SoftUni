namespace _01._Class_Box
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            var box = new Box(length, width, height);

            Console.WriteLine(box.SurfaceArea());
            Console.WriteLine(box.LateralSurfaceArea());
            Console.WriteLine(box.Volume());
        }
    }
}
