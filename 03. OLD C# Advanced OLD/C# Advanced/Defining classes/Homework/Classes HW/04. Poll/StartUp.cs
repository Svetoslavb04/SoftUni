using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {

            int numberOfLines = int.Parse(Console.ReadLine());
            var family = new List<Person>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                family.Add(person);
            }

            foreach (var person in family.OrderBy(m => m.Name).Where(m => m.Age >= 30))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
