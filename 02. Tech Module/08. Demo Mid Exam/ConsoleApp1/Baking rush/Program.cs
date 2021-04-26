using System;
using System.Collections.Generic;
using System.Linq;

namespace Baking_rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentEnergy = 100;
            int currentCoins = 100;

            var events = Console.ReadLine()
                .Split("|-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> eachEvent = new List<string>();
            List<int> numbers = new List<int>();

            for (int i = 0; i < events.Count; i += 2)
            {
                eachEvent.Add(events[i]);
                numbers.Add(int.Parse(events[i + 1]));
            }

            for (int i = 0; i < eachEvent.Count; i++)
            {
                if (eachEvent[i] == "rest")
                {
                    if (currentEnergy < 100)
                    {
                        if (numbers[i] + currentEnergy < 100)
                        {
                            currentEnergy = numbers[i] + currentEnergy;
                            Console.WriteLine($"You gained {numbers[i]} energy.");
                            Console.WriteLine($"Current energy: {currentEnergy}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You gained 0 energy.");
                        Console.WriteLine($"Current energy: {currentEnergy}.");
                    }
                }

                else if (eachEvent[i] == "order")
                {
                    if (currentEnergy >= 30)
                    {
                        currentCoins = currentCoins + numbers[i];
                        currentEnergy -= 30;
                        Console.WriteLine($"You earned {numbers[i]} coins.");
                    }
                    else
                    {
                        currentEnergy += 50;
                        Console.WriteLine($"You had to rest!");
                    }
                }
                else
                {
                    if (currentCoins >= numbers[i])
                    {
                        currentCoins -= numbers[i];
                        Console.WriteLine($"You bought {eachEvent[i]}.");
                    }
                    else
                    {
                        Console.WriteLine($"Closed!Cannot afford {eachEvent[i]}.");
                        return;
                    }
                }
            }
            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {currentCoins}");
            Console.WriteLine($"Energy: {currentEnergy}");


        }
    }
}
