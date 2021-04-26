using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Quest_Journal
{
    public class Program
    {
        public static void Main()
        {
            var journal = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                var command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Retire!")
                {
                    break;
                }
                if (command[0] == "Start")
                {
                    if (!journal.Contains(command[1]))
                    {
                        journal.Add(command[1]);
                    }
                }
                if (command[0] == "Complete")
                {
                    if (journal.Contains(command[1]))
                    {
                        journal.Remove(command[1]);
                    }
                }
                if (command[0] == "Side Quest")
                {
                    var sideQuest = command[1].Split(':');
                    if (journal.Contains(sideQuest[0]))
                    {
                        if (!journal.Contains(sideQuest[1]))
                        {
                            var index = journal.IndexOf(sideQuest[0]);
                            journal.Insert(index + 1, sideQuest[1]);
                        }                       
                    }
                }
                if (command[0] == "Renew")
                {
                    if (journal.Contains(command[1]))
                    {
                        var indexOfCommand = journal.IndexOf(command[1]);
                        var currQuest = journal[indexOfCommand];
                        journal.Remove(currQuest);
                        journal.Add(currQuest);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
