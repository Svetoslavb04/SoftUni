namespace _09._Miner
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int coalLeft = 0;
            int[] player = new int[] { 0, 0 };

            var commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int row = 0; row < size; row++)
            {
                var currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    if (currRow[col] == 'c')
                    {
                        coalLeft++;
                    }
                    else if (currRow[col] == 's')
                    {
                        player[0] = row;
                        player[1] = col;
                    }
                    matrix[row, col] = currRow[col];
                }
            }


            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up")
                {
                    if (player[0] - 1 < 0)
                    {
                        continue;
                    }
                    else
                    {
                        player[0]--;
                        if (matrix[player[0], player[1]] == 'c')
                        {
                            coalLeft--;
                            matrix[player[0], player[1]] = '*';
                            if (coalLeft == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({player[0]}, {player[1]})");
                                return;
                            }
                        }
                        else if (matrix[player[0], player[1]] == 'e')
                        {
                            Console.WriteLine($"Game over! ({player[0]}, {player[1]})");
                            return;
                        }
                    }
                }
                if (commands[i] == "down")
                {
                    if (player[0] + 1 > size - 1)
                    {
                        continue;
                    }
                    else
                    {
                        player[0]++;
                        if (matrix[player[0], player[1]] == 'c')
                        {
                            coalLeft--;
                            matrix[player[0], player[1]] = '*';
                            if (coalLeft == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({player[0]}, {player[1]})");
                                return;
                            }
                        }
                        else if (matrix[player[0], player[1]] == 'e')
                        {
                            Console.WriteLine($"Game over! ({player[0]}, {player[1]})");
                            return;
                        }
                    }
                }
                if (commands[i] == "right")
                {
                    if (player[1] + 1 > size - 1)
                    {
                        continue;
                    }
                    else
                    {
                        player[1]++;
                        if (matrix[player[0], player[1]] == 'c')
                        {
                            coalLeft--;
                            matrix[player[0], player[1]] = '*';

                            if (coalLeft == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({player[0]}, {player[1]})");
                                return;
                            }
                        }
                        else if (matrix[player[0], player[1]] == 'e')
                        {
                            Console.WriteLine($"Game over! ({player[0]}, {player[1]})");
                            return;
                        }
                    }
                }
                if (commands[i] == "left")
                {
                    if (player[1] - 1 < 0)
                    {
                        continue;
                    }
                    else
                    {
                        player[1]--;
                        if (matrix[player[0], player[1]] == 'c')
                        {
                            coalLeft--;
                            matrix[player[0], player[1]] = '*';
                            if (coalLeft == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({player[0]}, {player[1]})");
                                return;
                            }
                        }
                        else if (matrix[player[0], player[1]] == 'e')
                        {
                            Console.WriteLine($"Game over! ({player[0]}, {player[1]})");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine($"{coalLeft} coals left. ({player[0]}, {player[1]})");
        }
    }
}
