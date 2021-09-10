using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<char>(Console.ReadLine());
            Queue<char> secondQueue =  new Queue<char>(queue.Reverse());

            bool isBalanced = false;

            for (int i = 0; i < queue.Count / 2; i++)
            {
                char firstChar = queue.Dequeue();
                char secondChar = secondQueue.Dequeue();

                if (firstChar == '{')
                {
                    if (secondChar == '}')
                    {
                        isBalanced = true;

                    }
                }
                if (firstChar == '(')
                {
                    if (secondChar == ')')
                    {
                        isBalanced = true;

                    }
                }
                if (firstChar == '[')
                {
                    if (secondChar == ']')
                    {
                        isBalanced = true;

                    }
                }
            }

            if (isBalanced == true)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
