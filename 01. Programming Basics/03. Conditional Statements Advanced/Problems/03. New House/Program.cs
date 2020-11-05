using System;

namespace _03._New_House
{
    public class Program
    {
        public static void Main()
        {
            string flower = Console.ReadLine();
            int amountFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double requiredBudget = 0;

            switch (flower)
            {
                case "Roses":

                    requiredBudget = amountFlowers * 5;

                    if (amountFlowers > 80)
                    {
                        requiredBudget = requiredBudget - requiredBudget * 0.1;
                    }

                    break;

                case "Dahlias":

                    requiredBudget = amountFlowers * 3.8;

                    if (amountFlowers > 90)
                    {
                        requiredBudget = requiredBudget - requiredBudget * 0.15;
                    }

                    break;

                case "Tulips":

                    requiredBudget = amountFlowers * 2.8;

                    if (amountFlowers > 80)
                    {
                        requiredBudget = requiredBudget - requiredBudget * 0.15;
                    }

                    break;

                case "Narcissus":

                    requiredBudget = amountFlowers * 3;

                    if (amountFlowers < 120)
                    {
                        requiredBudget = requiredBudget + requiredBudget * 0.15;
                    }

                    break;

                case "Gladiolus":

                    requiredBudget = amountFlowers * 2.5;

                    if (amountFlowers < 80)
                    {
                        requiredBudget = requiredBudget + requiredBudget * 0.2;
                    }

                    break;

                default:
                    break;
            }

            if (budget >= requiredBudget)
            {
                Console.WriteLine($"Hey, you have a great garden with {amountFlowers} {flower} and {budget-requiredBudget:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(budget - requiredBudget):f2} leva more.");
            }
        }
    }
}
