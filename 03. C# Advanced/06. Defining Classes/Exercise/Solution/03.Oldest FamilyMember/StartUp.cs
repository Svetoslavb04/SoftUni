using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            Func<string, int> parser = n => int.Parse(n);

            int n = parser(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();

                Person person = new Person(line[0], parser(line[1]));

                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember().ToString());
        }
    }
}
