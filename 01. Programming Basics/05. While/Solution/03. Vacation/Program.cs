using System;

namespace _03._Vacation
{
    public class Program
    {
        public static void Main()
        {
            double requriedMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int totalDays = 0;
            int daysOfSpending = 0;

            while (availableMoney < requriedMoney)
            {
                totalDays++;

                string input = Console.ReadLine();
                double amountMoney = double.Parse(Console.ReadLine());

                if (input == "spend")
                {
                    daysOfSpending++;

                    if (daysOfSpending == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(totalDays);
                        return;
                    }

                    availableMoney -= amountMoney;

                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }
                }
                else if (input == "save")
                {
                    daysOfSpending = 0;

                    availableMoney += amountMoney;
                }
            }

            Console.WriteLine($"You saved the money for {totalDays} days.");

        }
    }
}
