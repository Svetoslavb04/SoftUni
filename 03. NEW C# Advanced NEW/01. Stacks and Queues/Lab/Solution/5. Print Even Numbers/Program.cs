using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split().Select(int.Parse);
            var queue = new Queue<int>(line);
            var numbers = new List<int>();

            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 != 0)
                {
                    queue.Dequeue();
                }
                else if(queue.Peek() % 2 == 0)
                {
                    numbers.Add(queue.Dequeue());
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
