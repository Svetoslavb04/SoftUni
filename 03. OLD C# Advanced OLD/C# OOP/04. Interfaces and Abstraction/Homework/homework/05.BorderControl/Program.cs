using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    public class Program
    {
        public static void Main()
        {
            var all = new List<IIdentifiable>();
            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];
                    var robot = new Robot(model, id);
                    all.Add(robot);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    var citizen = new Citizen(name,age,id);
                    all.Add(citizen);
                }
            }
            string fakeFactor = Console.ReadLine();
            all
                .Where(e => e.Id.EndsWith(fakeFactor))
                .Select(e => e.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
