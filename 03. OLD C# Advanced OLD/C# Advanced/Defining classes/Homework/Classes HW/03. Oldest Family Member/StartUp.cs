using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {

            int numberOfLines = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
