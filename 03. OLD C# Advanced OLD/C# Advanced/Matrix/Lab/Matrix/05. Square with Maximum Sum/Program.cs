namespace _05._Square_with_Maximum_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int bestSum = 0;
            int Brow = 0;
            int Bcol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                var currSum = 0;
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 1, col];
                    if (currSum > bestSum)
                    {
                        bestSum = currSum;
                        Brow = row;
                        Bcol = col;
                    }
                }
            }

            Console.Write($"{matrix[Brow,Bcol]} {matrix[Brow,Bcol+1]}");
            Console.WriteLine();
            Console.Write($"{matrix[Brow+1, Bcol]} {matrix[Brow + 1, Bcol + 1]}");
            Console.WriteLine();
            Console.WriteLine(bestSum);
        }
    }
}
