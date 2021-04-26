namespace _07._Pascal_Triangle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[rows][];
            pascalTriangle[0] = new long[1];
            pascalTriangle[0][0] = 1;

            for (int row = 0; row < rows; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    if (col == 0 || col == pascalTriangle[row].Length - 1)
                    {
                        pascalTriangle[row][col] = 1;
                    }
                    else
                    {
                        pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                    }                   
                }
            }

            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }        
        }
    }
}
