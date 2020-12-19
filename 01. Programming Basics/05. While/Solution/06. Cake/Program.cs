using System;

namespace _06._Cake
{
    public class Program
    {
        public static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int totalPieces = width * length;

            while (0 < totalPieces)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    Console.WriteLine($"{totalPieces} pieces are left.");
                    return;
                }

                int pieces = int.Parse(input);

                totalPieces -= pieces;
            }

            Console.WriteLine($"No more cake left! You need {Math.Abs(totalPieces)} pieces more.");
        }
    }
}
