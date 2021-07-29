using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main()
        {
            var identifiables = new List<IIdentifiable>();

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }

                if (command.Length == 3)
                {
                    var citizen = new Citizen(command[0], int.Parse(command[1]), command[2]);
                    identifiables.Add(citizen);
                }
                else
                {
                    var robot = new Robot(command[0], command[1]);
                    identifiables.Add(robot);
                }
            }

            string fakeFinish = Console.ReadLine();

            foreach (var identifiable in identifiables)
            {
                if (identifiable.Id.EndsWith(fakeFinish))
                {
                    Console.WriteLine(identifiable.Id);
                }
            }
        }
    }
}
