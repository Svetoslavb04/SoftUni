using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jagged = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                jagged[i] = line;
            }

            while (true)
            {
                var line = Console.ReadLine().Split().ToArray();

                if (line[0] == "END")
                {
                    break;
                }

                if (line[0] == "Add")
                {
                    int row = int.Parse(line[1]);
                    int col = int.Parse(line[2]);
                    int value = int.Parse(line[3]);

                    if (row < 0 || row >= n)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else if (col >= jagged[row].Length || col < 0)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        jagged[row][col] += value;
                    }
                }
                else
                {
                    int row = int.Parse(line[1]);
                    int col = int.Parse(line[2]);
                    int value = int.Parse(line[3]);

                    if (row < 0 || row >= n)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else if (col >= jagged[row].Length || col < 0)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        jagged[row][col] -= value;
                    }
                }
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
