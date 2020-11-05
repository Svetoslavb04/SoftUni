using System;

namespace _01._Cinema
{
    public class Program
    {
        public static void Main()
        {
            string typeOfProjection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            switch (typeOfProjection)
            {
                case "Premiere":
                    Console.WriteLine($"{rows * columns * 12:F2} leva");
                break;

                case "Normal":
                    Console.WriteLine($"{rows * columns * 7.5:F2} leva");
                break;

                case "Discount":
                    Console.WriteLine($"{rows * columns * 5:F2} leva");
                break;

                default:
                    break;
            }
        }
    }
}
