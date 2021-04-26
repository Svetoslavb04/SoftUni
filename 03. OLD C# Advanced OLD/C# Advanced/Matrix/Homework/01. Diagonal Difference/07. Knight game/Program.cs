namespace _07._Knight_game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            for (int row = 0; row < size; row++)
            {
                var curRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = curRow;
            }

            int counter = 0;

            var killCount = new List<int>();

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (!(matrix[row][col] == 'K'))
                    {
                        continue;
                    }
                    bool hasKilled = false;

                    if (matrix[row][])
                    {

                    }

                }
            }
        }
    }
}
