using System;

namespace _04._Fishing_Boat
{
    public class Program
    {
        public static void Main()
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());

            double requiredAmount = 0;

            switch (season)
            {
                case "Spring":

                    requiredAmount = 3000;

                    if (fishers <= 6)
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.1;
                    }
                    else if (fishers <= 11)
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.15;
                    }
                    else
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.25;
                    }

                    break;
                case "Summer":

                    requiredAmount = 4200;

                    if (fishers <= 6)
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.1;
                    }
                    else if (fishers <= 11)
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.15;
                    }
                    else
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.25;
                    }

                    break;

                case "Autumn":

                    requiredAmount = 4200;

                    if (fishers <= 6)
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.1;
                    }
                    else if (fishers <= 11)
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.15;
                    }
                    else
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.25;
                    }

                    break;

                case "Winter":

                    requiredAmount = 2600;

                    if (fishers <= 6)
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.1;
                    }
                    else if (fishers <= 11)
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.15;
                    }
                    else
                    {
                        requiredAmount = requiredAmount - requiredAmount * 0.25;
                    }

                    break;

                default:
                    break;
            }

            if (fishers % 2 == 0 && season != "Autumn")
            {
                requiredAmount = requiredAmount - requiredAmount * 0.05;
            }

            if (budget >= requiredAmount)
            {
                Console.WriteLine($"Yes! You have {budget - requiredAmount:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {requiredAmount - budget:F2} leva.");
            }
        }
    }
}
