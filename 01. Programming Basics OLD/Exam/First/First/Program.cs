using System;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceEgg = int.Parse(Console.ReadLine());
            var chikenFirst = int.Parse(Console.ReadLine());
            var boughtSecond = int.Parse(Console.ReadLine());
            var boughtThird = int.Parse(Console.ReadLine());
            double sum = priceEgg * 0.01;

            int eggsFirst = chikenFirst * 20;
            int second = (boughtSecond + chikenFirst) * 20;
            int third = boughtThird * 20 + second;
            int all = eggsFirst + second + third;
            double withB = all - (all * 0.04);
            double prize = withB * sum;
            Console.WriteLine($"Profit: {Math.Floor(prize)} Lv.");
        }
    }
}
