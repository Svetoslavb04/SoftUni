using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split().ToArray();

            var stack = new Stack<string>();

            int output = 0;

            for (int i = line.Length - 1; i >= 0; i--)
            {
                stack.Push(line[i]);
            }

            output += int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string operatorr = stack.Pop();
                int number = int.Parse(stack.Pop());

                if (operatorr == "+")
                {
                    output += number;
                }
                else
                {
                    output -= number;
                }
            }

            Console.WriteLine(output);
        }
    }
}
