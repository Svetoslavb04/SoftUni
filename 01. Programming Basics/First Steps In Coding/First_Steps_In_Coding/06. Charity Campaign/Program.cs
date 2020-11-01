using System;

namespace _06._Charity_Campaign
{
    class Program
    {
        static void Main()
        {
            int campaign_days = int.Parse(Console.ReadLine());
            int confectioner = int.Parse(Console.ReadLine());

            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cake_price = 45;
            double waffle_price = 5.8;
            double pancake_price = 3.2;

            double amount_before_cost = ((cakes * cake_price + waffles * waffle_price + pancakes * pancake_price) * confectioner) * campaign_days;
            double amount_after_cost = amount_before_cost - amount_before_cost / 8;

            Console.WriteLine(amount_after_cost);
        }
    }
}
