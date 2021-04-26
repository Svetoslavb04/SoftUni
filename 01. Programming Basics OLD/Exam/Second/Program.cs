using System;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            var poket = double.Parse(Console.ReadLine());
            var winings = double.Parse(Console.ReadLine());
            var lost = double.Parse(Console.ReadLine());
            var price = double.Parse(Console.ReadLine());

            double poketMoney = 5 * poket;
            double winingsWeek = winings * 5;
            double all = poketMoney + winingsWeek;
            double clear = all - lost;

            if (clear >= price)
            {
                Console.WriteLine($"Profit: {clear} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {price - clear, 2:F2} BGN.");
            }


        }
    }
}
