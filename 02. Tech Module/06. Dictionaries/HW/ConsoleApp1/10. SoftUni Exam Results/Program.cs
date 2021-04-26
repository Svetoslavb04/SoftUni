using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main()
        {
            var submitions = new Dictionary<string, int>();
            var people = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                var input = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "exam finished")
                {
                    break;
                }
                if (input[1] == "banned")
                {
                    if (people[input[0]].ContainsKey(input[0]))
                    {
                        people[input[0]].Remove(input[0]);
                    }
                }
                if (submitions.ContainsKey(input[1]))
                {
                    submitions[input[1]] ++;
                }
                else
                {
                    submitions.Add(input[1], 1);
                }
                if (!(people.ContainsKey(input[0])))
                {
                    people.Add(input[0], new Dictionary<string, int>());
                    people[input[0]][input[1]] = int.Parse(input[2]);
                }
                else if (people.ContainsKey(input[0]) && people[input[0]].ContainsKey(input[1]))
                {
                    if (people[input[0]][input[1]] > int.Parse(input[2]))
                    {
                        people[input[0]][input[1]] = int.Parse(input[2]);                        
                    } 
                    else
                    {
                        submitions[input[1]]++;
                    }
                }
            }
            Console.WriteLine("Results:");
            foreach (var person in people)
            {
                
                Console.WriteLine($"{person.Key} | {person.Value.Values}");
            }
            foreach (var language in submitions.OrderByDescending(n => n.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
