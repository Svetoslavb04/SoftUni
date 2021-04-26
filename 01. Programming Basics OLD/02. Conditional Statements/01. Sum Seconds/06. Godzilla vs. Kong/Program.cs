using System;

namespace _06._Godzilla_vs._Kong
{
    public class Program
    {
        public static void Main()
        {
            double filmBudget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double statistOutfitPrice = double.Parse(Console.ReadLine());

            double decor = 0.1 * filmBudget;

            if (statists > 150)
            {
                statistOutfitPrice = statistOutfitPrice - statistOutfitPrice * 0.1;
            }

            double requiredBudget = decor + statistOutfitPrice * statists;

            if (requiredBudget > filmBudget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {requiredBudget - filmBudget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {filmBudget - requiredBudget:f2} leva left.");
            }
        }
    }
}
