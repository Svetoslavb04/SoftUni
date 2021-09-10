using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();
            var stack = new Stack<string>();
            stack.Push(builder.ToString());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToList();
                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        input.RemoveAt(0);
                        builder.Append(string.Join("",input));
                        stack.Push(builder.ToString());
                        break;
                    case 2:
                        int number = int.Parse(input[1]);
                        builder.Remove(builder.Length - number, number);
                        stack.Push(builder.ToString());
                        break;
                    case 3:
                        int index = int.Parse(input[1]);
                        Console.WriteLine(builder[index - 1]);
                        break;
                    case 4:
                        stack.Pop();
                        builder = new StringBuilder();
                        builder.Append(stack.Peek());
                        break;
                }
            }
        }
    }
}
