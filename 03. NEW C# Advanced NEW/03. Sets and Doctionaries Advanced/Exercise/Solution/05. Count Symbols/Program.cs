using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine();

            var dictionary = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (dictionary.ContainsKey(symbol))
                {
                    dictionary[symbol]++;
                }
                else
                {
                    dictionary.Add(symbol, 1);
                }
            }

            foreach (var symbol in dictionary)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
