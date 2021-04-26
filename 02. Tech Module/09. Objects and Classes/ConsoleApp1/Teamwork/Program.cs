using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamwork
{
    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var teamWithMembers = new Dictionary<string, List<string>>();
            var creators = new Dictionary<string, string>();
            bool toSkip = false;
            for (int i = 0; i < lines; i++)
            {
                var line = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);
                var currCreator = line[0];
                var currTeamName = line[1];
                
                if (teamWithMembers.ContainsKey(currTeamName))
                {
                    Console.WriteLine($"Team {currTeamName} was already created!");
                    continue;
                }
                foreach (var creator in creators)
                {
                    if (creator.Value == line[0])
                    {
                        Console.WriteLine($"{currCreator}cannot create another team!");
                        toSkip = true;
                    }
                }
                if (toSkip == false)
                {
                    teamWithMembers.Add(currTeamName, new List<string>());
                    creators.Add(currTeamName, currCreator);
                    Console.WriteLine($"Team {currTeamName} has been created by {currCreator}!");
                }
            }
            toSkip = false;
            while (true)
            {
                var input = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "end of assignment")
                {
                    break;
                }
                if (!teamWithMembers.ContainsKey(input[1]))
                {
                    Console.WriteLine($"Team {input[1]} does not exist!");
                    continue;
                }
                foreach (var team in teamWithMembers)
                {
                        if (creators[team.Key] == input[0])
                        {
                            Console.WriteLine($"Member {input[0]} cannot join team {input[1]}!");
                            toSkip = true;
                        }
                }
                if (input[0] != creators[input[1]])
                {
                    teamWithMembers[input[1]].Add(input[0]);
                }
            }

            foreach (var team in teamWithMembers.OrderByDescending(n => n.Value.Count).ThenBy(n => n.Key).Where(n => n.Value.Count > 0))
            {
                Console.WriteLine($"{team.Key}");
                Console.WriteLine($"- {creators[team.Key]}");
                foreach (var people in team.Value.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {people}");
                }
            }
            var emptyTeams = new List<string>();
            foreach (var team in teamWithMembers)
            {
                if (team.Value.Count == 0)
                {
                    emptyTeams.Add(team.Key);
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in emptyTeams.OrderBy(n => n))
            {
                Console.WriteLine($"{team}");
            }
        }
    }
}
