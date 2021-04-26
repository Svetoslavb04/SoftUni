namespace _01.ClubParty
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());

            Queue<Stack<int>> halls = new Queue<Stack<int>>();
            Queue<string> names = new Queue<string>();

            List<string> line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            for (int i = 0; i < line.Count; i++)
            {
                int number;
                bool isNumeric = int.TryParse(line[i], out number);

                if (isNumeric)
                {
                    if (names.Any())
                    {
                        int sumOfValues = CheckCapacity(halls);

                        if (sumOfValues >= capacity)
                        {
                            List<int> values = new List<int>();

                            int countOfValues = halls.Peek().Count;

                            for (int j = 0; j < countOfValues; j++)
                            {
                                values.Add(halls.Peek().Pop());
                            }

                            values.Reverse();

                            Console.WriteLine($"{names.Dequeue()} -> {string.Join(", ", values)}");

                            halls.Dequeue();
                            halls.Enqueue(new Stack<int>());

                            if (!names.Any())
                            {
                                continue;
                            }

                            if (int.Parse(line[i]) < capacity)
                            {
                                halls.Peek().Push(int.Parse(line[i]));
                            }
                        }
                        else
                        {
                            if (int.Parse(line[i]) + sumOfValues <= capacity)
                            {
                                halls.Peek().Push(int.Parse(line[i]));
                            }
                            else
                            {
                                List<int> values = new List<int>();

                                int countOfValues = halls.Peek().Count;

                                for (int j = 0; j < countOfValues; j++)
                                {
                                    values.Add(halls.Peek().Pop());
                                }

                                values.Reverse();

                                Console.WriteLine($"{names.Dequeue()} -> {string.Join(", ", values)}");

                                halls.Dequeue();
                                halls.Enqueue(new Stack<int>());

                                if (!names.Any())
                                {
                                    continue;
                                }

                                if (int.Parse(line[i]) < capacity)
                                {
                                    halls.Peek().Push(int.Parse(line[i]));
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (halls.Any())
                    {
                        int sumOfValues = CheckCapacity(halls);

                        if (names.Count != 0 && sumOfValues >= capacity)
                        {
                            List<int> values = new List<int>();

                            int countOfValues = halls.Peek().Count;

                            for (int j = 0; j < countOfValues; j++)
                            {
                                values.Add(halls.Peek().Pop());
                            }

                            Console.WriteLine($"{names.Dequeue()} -> {string.Join(", ", values)}");

                            
                            halls.Enqueue(new Stack<int>());
                        }
                    }
                    else
                    {
                        halls.Enqueue(new Stack<int>());
                    }
                    names.Enqueue(line[i]);
                }
            }
        }

        public static int CheckCapacity(Queue<Stack<int>> halls)
        {
            var sum = 0;

            int[] copyStack = new int[halls.Peek().Count];

            int countStack = halls.Peek().Count;

            for (int i = 0; i < countStack; i++)
            {
                int currentValue = halls.Peek().Pop();
                sum += currentValue;
                copyStack[i] = currentValue;
            }

            halls.Dequeue();
            halls.Enqueue(new Stack<int>(copyStack.Reverse()));

            return sum;
        }
    }
}
