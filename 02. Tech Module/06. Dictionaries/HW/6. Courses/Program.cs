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
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                if (input[0] == "end")
                {
                    break;
                }
                string typeOfCourse = input[0];
                string nameOfStudent = input[1];
                if (courses.ContainsKey(typeOfCourse))
                {
                    courses[typeOfCourse].Add(nameOfStudent);
                }
                else
                {
                    courses.Add(typeOfCourse, new List<string>());
                    courses[typeOfCourse].Add(nameOfStudent);
                }
            }
            foreach (var course in courses.OrderByDescending(n => n.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var user in course.Value.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }
    }
}
