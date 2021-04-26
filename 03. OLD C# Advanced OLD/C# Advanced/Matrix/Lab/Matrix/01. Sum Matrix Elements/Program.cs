namespace _01._Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            int sum = 0;

            for (int row= 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            for (int col = 0; col < size[1]; col++)
            {
                for (int row = 0; row < size[0]; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
