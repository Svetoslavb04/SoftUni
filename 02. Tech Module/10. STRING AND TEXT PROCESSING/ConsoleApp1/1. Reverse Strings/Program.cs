using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                var rev = string.Empty;
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    rev += input[i];
                }
                Console.WriteLine($"{input} = {rev}");
            }
        }
    }
}
