using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elementsToPushN = line[0];
            int elementsToPopS = line[1];
            int searchedElementX = line[2];

            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            for (int i = 0; i < elementsToPopS; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Contains(searchedElementX))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.ToArray().Min());
            }
        }
    }
}
