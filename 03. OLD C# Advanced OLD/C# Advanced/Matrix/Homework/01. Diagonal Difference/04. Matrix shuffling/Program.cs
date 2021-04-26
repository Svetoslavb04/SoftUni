namespace _04._Matrix_shuffling
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }
                if (input.Length != 5 || input[0] != "swap" || int.Parse(input[1]) > matrix.GetLength(0) || int.Parse(input[2]) > matrix.GetLength(0) || int.Parse(input[3]) > matrix.GetLength(1) || int.Parse(input[4]) > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int[] firstCords = new int[2];
                firstCords[0] = int.Parse(input[1]);
                firstCords[1] = int.Parse(input[2]);

                int[] secondCords = new int[2];
                secondCords[0] = int.Parse(input[3]);
                secondCords[1] = int.Parse(input[4]);

                int firstValue = matrix[firstCords[0], firstCords[1]];
                int secondValue = matrix[secondCords[0], secondCords[1]];

                matrix[firstCords[0], firstCords[1]] = secondValue;
                matrix[secondCords[0], secondCords[1]] = firstValue;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row,col]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
