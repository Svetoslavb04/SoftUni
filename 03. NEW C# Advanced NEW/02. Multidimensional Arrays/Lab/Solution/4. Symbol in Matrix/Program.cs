using System;

namespace _4._Symbol_in_Matrix
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j].ToString();
                }
            }

            string symbol = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j].ToString() == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }
    }
}
