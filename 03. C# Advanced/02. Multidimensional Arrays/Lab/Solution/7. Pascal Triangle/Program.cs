using System;

namespace _7._Pascal_Triangle
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];

            triangle[0] = new long[1] { 1 };

            for (int i = 2; i <= n; i++)
            {
                long[] line = new long[i];
                line[0] = 1;

                for (int j = 1; j < i - 1; j++)
                {
                    line[j] = triangle[i - 2][j - 1] + triangle[i - 2][j];
                }

                line[i - 1] = triangle[i - 2][i - 2];

                triangle[i-1] = line;
            }

            foreach (var item in triangle)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
