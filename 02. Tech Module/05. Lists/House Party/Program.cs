using System;
using System.Collections.Generic;
using System.Linq;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            List<string> isGoing = new List<string>();

            for (int i = 1; i <= numberOfCommands; i++)
            {
                string input = Console.ReadLine();
                string[] com = input.Split();
                if (com[2] != "not" && isGoing.Contains(com[0]))
                {
                    Console.WriteLine($"{com[0]} is already in the list!");
                    continue;
                }
                if (com[2] != "not")
                {
                    isGoing.Add(com[0]);
                }
                if (com[2] == "not" && isGoing.Contains(com[0]))
                {
                    isGoing.Remove(com[0]);
                    continue;
                }
                if (com[2] == "not")
                {
                    Console.WriteLine($"{com[0]} is not in the list!");
                }
            }
            for (int i = 0; i < isGoing.Count; i++)
            {
                Console.WriteLine(isGoing[i]);
            }
        }
    }
}
