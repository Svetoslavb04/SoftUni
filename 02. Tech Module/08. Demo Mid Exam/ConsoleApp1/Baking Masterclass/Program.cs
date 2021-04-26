using System;
using System.Linq;

namespace Baking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var numberOfStudents = int.Parse(Console.ReadLine());
            var priceOfFlour = double.Parse(Console.ReadLine());
            var priceOfEggs = double.Parse(Console.ReadLine());
            var priceOfapron = double.Parse(Console.ReadLine());
            double percents = Math.Ceiling(numberOfStudents * 0.2);
            int freePackages = 0;
            if (numberOfStudents % 10 == 5)
            {
                freePackages = numberOfStudents / 5;
            }
            double apron = (priceOfapron * (numberOfStudents + percents));
            double eggs = (priceOfEggs * 10 * numberOfStudents);
            double flour = (priceOfFlour * (numberOfStudents - freePackages));

            var neededBudget = apron + eggs + flour;

            if (neededBudget <= budget)
            {
                Console.WriteLine($"Items purchased for {Math.Round(neededBudget, 2):f2}$.");
            }
            else
            {
                Console.WriteLine($"{Math.Round(Math.Abs(neededBudget - budget), 2):f2}$ more needed.");
            }


        }
    }
}
