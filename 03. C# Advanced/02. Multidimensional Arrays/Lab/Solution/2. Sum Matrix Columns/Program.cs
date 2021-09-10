using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main()
        {
            var rowsCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];

            int[] sum = new int[cols];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                    sum[j] += line[j];
                }
                
            }

            foreach (var item in sum)
            {
                Console.WriteLine(item);
            }
        }
    }
}
