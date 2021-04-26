namespace _03._Primary_Diagonal
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    sum += matrix[row, row];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
