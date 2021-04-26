namespace _06._Bomb_Basement
{
    using System;
    using System.Linq;

    public class Program
    {
       public static void Main()
        {
            var size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var bombProps = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    double distance = Math.Sqrt(Math.Pow(row - bombProps[0], 2) - Math.Pow(col - bombProps[1], 2));

                    if (distance <= bombProps[2])
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
