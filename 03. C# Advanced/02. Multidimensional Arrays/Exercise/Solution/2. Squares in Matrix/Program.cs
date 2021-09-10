using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main()
        {
            var rowCol = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[rowCol[0], rowCol[1]];

            for (int i = 0; i < rowCol[0]; i++)
            {
                var line = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < rowCol[1]; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int totalSquares = 0;

            for (int i = 0; i < rowCol[0] - 1; i++)
            {
                for (int j = 0; j < rowCol[1] - 1; j++)
                {
                    string topLeft = matrix[i, j];
                    string topRight = matrix[i, j+1];
                    string bottomLeft = matrix[i+1, j];
                    string bottomRight = matrix[i+1, j+1];

                    if (topLeft == topRight && topRight == bottomLeft && bottomLeft == bottomRight && bottomRight == topLeft)
                    {
                        totalSquares++;
                    }
                }
            }

            Console.WriteLine(totalSquares);
        }
    }
}
