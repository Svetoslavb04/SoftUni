using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class Program
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] galaxy = CreateGalaxy(rows, cols);

            string command = Console.ReadLine();
            long sumOfCollectedStars = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (evilRow >= 0 && evilRow < galaxy.GetLength(0) && evilCol >= 0 && evilCol < galaxy.GetLength(1))
                    {
                        galaxy[evilRow, evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                int ivoRow = ivoCoordinates[0];
                int ivoCol = ivoCoordinates[1];

                while (ivoRow >= 0 && ivoCol < galaxy.GetLength(1))
                {
                    if (ivoRow >= 0 && ivoRow < galaxy.GetLength(0) && ivoCol >= 0 && ivoCol < galaxy.GetLength(1))
                    {
                        sumOfCollectedStars += galaxy[ivoRow, ivoCol];
                    }

                    ivoCol++;
                    ivoRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sumOfCollectedStars);

        }

        public static int[,] CreateGalaxy(int rows, int cols)
        {
            int[,] galaxy = new int[rows, cols];

            int starValue = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    galaxy[i, j] = starValue++;
                }
            }

            return galaxy;
        }
    }
}
