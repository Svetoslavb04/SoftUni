namespace _05._Snake_Moves
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[sizes[0], sizes[1]];

            string str = Console.ReadLine();
            Queue<char> snake = new Queue<char>(str);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (snake.Count < matrix.GetLength(1))
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        snake.Enqueue(str[i]);
                    }
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snake.Dequeue();
                }
                for (int i = 0; i < str.Length; i++)
                {
                    snake.Enqueue(str[i]);
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
