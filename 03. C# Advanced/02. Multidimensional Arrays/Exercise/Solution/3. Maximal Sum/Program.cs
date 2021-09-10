using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main()
        {
            var rowCol = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[rowCol[0], rowCol[1]];

            for (int i = 0; i < rowCol[0]; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < rowCol[1]; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int bestSum = 0;
            int[,] bestMatrix = new int[3, 3];

            for (int i = 0; i < rowCol[0] - 2; i++)
            {
                for (int j = 0; j < rowCol[1] - 2; j++)
                {
                    int currentSum = 0;

                    currentSum += matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (bestSum < currentSum)
                    {
                        bestSum = currentSum;
                        bestMatrix[0, 0] = matrix[i, j];
                        bestMatrix[0, 1] = matrix[i, j + 1];
                        bestMatrix[0, 2] = matrix[i, j + 2];
                        bestMatrix[1, 0] = matrix[i + 1, j];
                        bestMatrix[1, 1] = matrix[i + 1, j + 1];
                        bestMatrix[1, 2] = matrix[i + 1, j + 2];
                        bestMatrix[2, 0] = matrix[i + 2, j];
                        bestMatrix[2, 1] = matrix[i + 2, j + 1];
                        bestMatrix[2, 2] = matrix[i + 2, j + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{bestMatrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
