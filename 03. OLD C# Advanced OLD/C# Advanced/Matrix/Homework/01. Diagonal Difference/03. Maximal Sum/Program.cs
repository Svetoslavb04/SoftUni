namespace _03._Maximal_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int bestSum = 0;
            int indexR = -1;
            int indexC = -1;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currSum = 0;
                    currSum += matrix[row, col];
                    currSum += matrix[row + 1, col];
                    currSum += matrix[row + 2, col];
                    currSum += matrix[row, col + 1];
                    currSum += matrix[row + 1, col + 1];
                    currSum += matrix[row + 2, col + 1];
                    currSum += matrix[row, col + 2];
                    currSum += matrix[row + 1, col + 2];
                    currSum += matrix[row + 2, col + 2];
                    if (bestSum < currSum)
                    {
                        bestSum = currSum;
                        indexR = row;
                        indexC = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");
            Console.WriteLine($"{matrix[indexR, indexC]} {matrix[indexR, indexC + 1]} {matrix[indexR, indexC + 2]}");
            Console.WriteLine($"{matrix[indexR + 1, indexC]} {matrix[indexR + 1, indexC + 1]} {matrix[indexR + 1, indexC + 2]}");
            Console.WriteLine($"{matrix[indexR + 2, indexC]} {matrix[indexR + 2, indexC + 1]} {matrix[indexR + 2, indexC + 2]}");
        }
    }
}
