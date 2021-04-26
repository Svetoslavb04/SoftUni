using System;
using System.Linq;
using System.Collections.Generic;

namespace Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public Student()
        {
        }
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToList();
                var currStudent = new Student()
                {
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    Grade = 0
                };
                currStudent.FirstName = input[0];
                currStudent.LastName = input[1];
                currStudent.Grade = double.Parse(input[2]);
                students.Add(currStudent);
            }
            foreach (var student in students.OrderByDescending(n => n.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
