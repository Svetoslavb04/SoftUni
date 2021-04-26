using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.BirthdayCelebrations
{
    public class Program
    {
        public static void Main()
        {
            var all = new List<IBirthable>();
            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Pet")
                {
                    string name = input[1];
                    string birthdate = input[2];
                    var pet = new Pet(name, birthdate);
                    all.Add(pet);
                }
                else if (input[0] == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdate = input[4];
                    var citizen = new Citizen(name, age, id, birthdate);
                    all.Add(citizen);
                }
            }
            string year = Console.ReadLine();
            all
                .Where(e => e.Birthdate.EndsWith(year))
                .Select(e => e.Birthdate)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
