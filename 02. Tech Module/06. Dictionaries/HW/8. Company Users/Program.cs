using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();
            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                if (input[0] == "End")
                {
                    break;
                }
                string Firm = input[0];
                string employee = input[1];
                if (courses.ContainsKey(Firm))
                {
                    if (!courses[Firm].Contains(employee))
                    {
                        courses[Firm].Add(employee);
                    }
                }
                else
                {
                    courses.Add(Firm, new List<string>());
                    courses[Firm].Add(employee);
                }
            }
            foreach (var course in courses.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{course.Key}");
                foreach (var user in course.Value)
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }
    }
}
