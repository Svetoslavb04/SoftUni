using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int sumLeftDiag = 0;

            for (int i = 0; i < n; i++)
            {
                sumLeftDiag += matrix[i, i];
            }

            int sumRightDiag = 0;
            int k = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                sumRightDiag += matrix[k, i];
                k++;
            }

            Console.WriteLine(Math.Abs(sumRightDiag - sumLeftDiag));
        }
    }
}
