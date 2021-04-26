using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            var registerOfPeople = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToList();
                string typeCommand = input[0];
                string name = input[1];
                string plate = string.Empty;

                if (typeCommand == "register")
                {
                    plate = input[2];
                    if (registerOfPeople.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registerOfPeople[name]}");
                    }
                    else
                    {
                        registerOfPeople.Add(name, plate);
                        Console.WriteLine($"{name} registered {registerOfPeople[name]} successfully");
                    }
                }
                else if (typeCommand == "unregister")
                {
                    if (!registerOfPeople.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        registerOfPeople.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    };
                }

            }
            foreach (var name in registerOfPeople)
            {
                Console.WriteLine($"{name.Key} => {name.Value}");
            }
        }
    }
}
