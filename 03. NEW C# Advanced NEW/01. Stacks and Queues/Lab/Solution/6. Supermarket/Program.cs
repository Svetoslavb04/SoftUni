using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    public class Program
    {
        public static void Main()
        {
            var queue = new Queue<string>();
            int remaining = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                if (command == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    remaining = 0;
                }
                else
                {
                    queue.Enqueue(command);
                    remaining++;
                }
            }
            Console.WriteLine($"{remaining} people remaining.");
        }
    }
}
