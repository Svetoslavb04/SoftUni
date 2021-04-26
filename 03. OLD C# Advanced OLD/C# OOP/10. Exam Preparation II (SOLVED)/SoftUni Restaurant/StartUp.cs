using SoftUniRestaurant.Core;
using SoftUniRestaurant.Models.Drinks.Factories;
using SoftUniRestaurant.Models.Foods.Factories;
using SoftUniRestaurant.Models.Tables.Factories;
using System;
using System.Reflection;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            var controller = new RestaurantController();

            var controllerType = Type.GetType($"SoftUniRestaurant.Core.RestaurantController");
            var methods = controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static);

            while (true)
            {
                var command = Console.ReadLine().Split();

                string[] commandArgs = new string[command.Length - 1];

                for (int i = 1; i < command.Length; i++)
                {
                    commandArgs[i - 1] = command[i];
                }

                if (command[0] == "END")
                {
                    break;
                }

                Console.WriteLine(controllerType.GetMethod(command[0]).Invoke(controller, commandArgs));
            }
        }
    }
}
