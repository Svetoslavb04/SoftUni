using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    class Program
    {
        static void Main()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elementsToPushN = line[0];
            int elementsToPopS = line[1];
            int searchedElementX = line[2];

            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            for (int i = 0; i < elementsToPopS; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(searchedElementX))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.ToArray().Min());
            }
        }
    }
}
