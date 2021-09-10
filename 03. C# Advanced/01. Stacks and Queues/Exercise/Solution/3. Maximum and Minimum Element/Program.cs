using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main()
        {
            var stack = new Stack<int>();

            int numberOfQueriesN = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfQueriesN; i++)
            {
                var line = Console.ReadLine().Split().ToArray();

                if (line[0] == "1")
                {
                    stack.Push(int.Parse(line[1]));
                }
                else if (line[0] == "2")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (line[0] == "3")
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.ToArray().Max());
                    }
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.ToArray().Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
