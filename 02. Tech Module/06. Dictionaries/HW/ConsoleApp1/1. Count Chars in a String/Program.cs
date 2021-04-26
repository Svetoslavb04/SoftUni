using System;
using System.Collections.Generic;
using System.Linq;


namespace _1._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] chars = text.ToCharArray();
            var symbols = new Dictionary<char, int>();

            foreach (var l in chars)
            {
                if (l == ' ')
                {

                }
                else
                {
                    if (symbols.ContainsKey(l))
                    {
                        symbols[l]++;
                    }
                    else
                    {
                        symbols[l] = 1;
                    }
                }
            }
            foreach (var i in symbols)
            {
                Console.WriteLine($"{i.Key} -> {i.Value}");
            }
        }
    }
}