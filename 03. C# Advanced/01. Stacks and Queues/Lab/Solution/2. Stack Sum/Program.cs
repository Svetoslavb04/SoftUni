using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            while (true)
            {
                var input = Console.ReadLine().Split().ToArray();

                if (input[0] == "end")
                {
                    break;
                }

                if (input[0].ToLower() == "add")
                {
                    stack.Push(int.Parse(input[1]));
                    stack.Push(int.Parse(input[2]));
                }

                if (input[0].ToLower() == "remove")
                {
                    if (stack.Count >= int.Parse(input[1]))
                    {
                        for (int i = 0; i < int.Parse(input[1]); i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
