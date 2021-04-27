using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Hot_Potato
{
    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split().ToList();
            var queue = new Queue<string>(line);

            int n = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 0; i < n-1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
