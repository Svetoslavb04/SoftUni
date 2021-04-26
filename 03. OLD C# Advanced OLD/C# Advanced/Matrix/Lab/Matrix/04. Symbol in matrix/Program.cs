namespace _04._Symbol_in_matrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                var currRow = new char[size];

                for (int i = 0; i < 3; i++)
                {
                    currRow[i] = input[i];
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            char toFind = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == toFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{toFind} does not occur in the matrix ");
        }
    }
}
