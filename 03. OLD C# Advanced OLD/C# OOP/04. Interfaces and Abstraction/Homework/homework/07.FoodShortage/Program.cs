namespace _07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int amountResident = int.Parse(Console.ReadLine());
            List<IBuyer> residents = new List<IBuyer>();

            for (int i = 0; i < amountResident; i++)
            {
                var input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    var citizen = new Citizen(name, age, id, birthdate);

                    residents.Add(citizen);
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    var rebel = new Rebel(name, age, group);

                    residents.Add(rebel);
                }
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                var buyer = residents.SingleOrDefault(b => b.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(residents.Sum(b => b.Food));
        }
    }
}
