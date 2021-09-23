using System;

namespace Snake
{
    public class Program
    {
        public static void Main()
        {
            int[] coordinates = new int[] { 19, 10 };
            string[,] board = new string[20, 40];
            board = CreateBoard(board);
            DrawScreen(coordinates[0], coordinates[1], board);
            Console.Read();

            while (true)
            {
                coordinates = AcceptInput(19, 10);
                DrawScreen(coordinates[0], coordinates[1], board);
            }
        }

        private static int[] AcceptInput(int _left, int _top)
        {
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    _left--;
                    break;
                case ConsoleKey.RightArrow:
                    _left++;
                    break;
                case ConsoleKey.UpArrow:
                    _top--;
                    break;
                case ConsoleKey.DownArrow:
                    _top++;
                    break;

            }

            return new int[] { _left, _top };
        }
        private static void DrawScreen(int _left, int _top, string[,] board)
        {
            Console.Clear();
            DrawBoard(board);

            Console.SetCursorPosition(_left, _top);
            Console.Write("*");

        }

        public static string[,] CreateBoard(string [,] board)
        {
            for (int i = 0; i < board.GetLength(1); i++)
            {
                board[0,i] ="#";
            }
            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (j == 0 || j == board.GetLength(1) - 1)
                    {
                        board[i, j] = "#";
                    }
                    else
                    {
                        board[i, j] = " ";
                    }
                }
            }
            for (int i = 0; i < board.GetLength(1); i++)
            {
                board[board.GetLength(0)-1, i] = "#";
            }

            return board;
        }

        public static void DrawBoard(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
