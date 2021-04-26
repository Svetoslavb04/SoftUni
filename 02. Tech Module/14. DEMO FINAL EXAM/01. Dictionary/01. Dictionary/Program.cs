using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    public class Program
    {
        public static void Main()
        {
            var wordWithDefinitons = new Dictionary<string, List<string>>();
            var wordDef = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < wordDef.Count; i++)
            {
                var currdef = wordDef[i].Split(": ", StringSplitOptions.RemoveEmptyEntries);
                if (wordWithDefinitons.ContainsKey(currdef[0]))
                {
                    wordWithDefinitons[currdef[0]].Add(currdef[1]);
                }
                else
                {
                    wordWithDefinitons.Add(currdef[0], new List<string>());
                    wordWithDefinitons[currdef[0]].Add(currdef[1]);
                }
            }
           
            var wordsToCheck = Console.ReadLine()
                .Split(" | ")
                .ToList();          
            for (int i = 0; i < wordsToCheck.Count; i++)
            {
                if (wordWithDefinitons.ContainsKey(wordsToCheck[i]))
                {
                    Console.WriteLine(wordsToCheck[i]);
                    foreach (var deff in wordWithDefinitons[wordsToCheck[i]].OrderByDescending(d => d.Length))
                    {
                        Console.WriteLine($"-{deff}");
                    }                    
                }
            }

            var endOrList = Console.ReadLine();

            if (endOrList == "End")
            {
                return;
            }
            if (endOrList == "List")
            {
                foreach (var word in wordWithDefinitons.OrderBy(w => w.Key))
                {
                    Console.Write($"{word.Key} ");
                }
            }
            Console.WriteLine();
        }
    }
}
