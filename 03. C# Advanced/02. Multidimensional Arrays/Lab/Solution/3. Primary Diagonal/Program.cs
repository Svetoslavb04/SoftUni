using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    public class Program
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int[,] matrix = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
