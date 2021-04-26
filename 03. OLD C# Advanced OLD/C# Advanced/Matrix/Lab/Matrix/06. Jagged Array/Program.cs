namespace _06._Jagged_Array
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            if (size < 0)
            {
                return;
            }
            int[][] jagged = new int[size][];

            for (int row = 0; row < jagged.Length; row++)
            {
                string[] inputNumbers = Console.ReadLine().Split(' ');
                jagged[row] = new int[inputNumbers.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = int.Parse(inputNumbers[col]);
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    break;
                }

                if (input[0] == "Add")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int number = int.Parse(input[3]);

                    if (row < jagged.Length && row >= 0)
                    {
                        if (col < jagged[row].Length && col >= 0)
                        {
                            jagged[row][col] += number;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }

                }

                if (input[0] == "Subtract")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int number = int.Parse(input[3]);

                    if (row < jagged.Length && row >= 0)
                    {
                        if (col < jagged[row].Length && col >= 0)
                        {
                            jagged[row][col] -= number;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
