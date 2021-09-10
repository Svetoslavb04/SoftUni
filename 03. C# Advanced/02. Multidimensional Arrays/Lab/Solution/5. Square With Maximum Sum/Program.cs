using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    public class Program
    {
        public static void Main()
        {
            var rowsCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int[,] bestMatrix = new int[2, 2];
            int bestSum = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int currentSum = 0;

                    currentSum += matrix[i, j];
                    currentSum += matrix[i, j+1];
                    currentSum += matrix[i+1, j];
                    currentSum += matrix[i+1, j+1];

                    if (bestSum < currentSum)
                    {
                        bestSum = currentSum;

                        bestMatrix[0,0] = matrix[i, j];
                        bestMatrix[0,1] = matrix[i, j+1];
                        bestMatrix[1,0] = matrix[i+1, j];
                        bestMatrix[1,1] = matrix[i+1, j+1];
                    }
                }
            }

            for (int i = 0; i < bestMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < bestMatrix.GetLength(1); j++)
                {
                    Console.Write($"{bestMatrix[i,j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(bestSum);
        }
    }
}
