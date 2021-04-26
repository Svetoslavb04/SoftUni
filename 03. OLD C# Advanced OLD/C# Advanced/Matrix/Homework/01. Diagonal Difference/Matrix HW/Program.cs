namespace Matrix_HW
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int sumL = 0;
            int sumR = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumL += matrix[row, row];
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumR += matrix[row, matrix.GetLength(0) - 1 - row];
            }

            Console.WriteLine(Math.Abs(sumL - sumR));
        }
    }
}
