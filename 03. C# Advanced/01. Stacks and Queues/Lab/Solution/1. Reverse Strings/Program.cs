using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            var stack = new Stack<string>();

            for (int i = 0; i < line.Length; i++)
            {
                stack.Push(line[i].ToString());
            }

            for (int i = 0; i < line.Length; i++)
            {
                Console.Write($"{stack.Pop()}");
            }
        }
    }
}
