using System;
using System.Collections.Generic;
using System.Linq;
namespace P02
{
    class Program
    {
        public static void Main()
        {
            var words = new Dictionary<string, List<string>>();
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var word = Console.ReadLine();
                var synonym = Console.ReadLine();
                if (!words.ContainsKey(word))
                {
                    words.Add(word, new List<string>());
                }
                words[word].Add(synonym);
            }

            foreach (var item in words)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(", ", item.Value)}");
            }
        }
    }
}
