using System;

namespace _02._Bonus_Score
{
    class Program
    {
        public static void Main()
        {
            int points = int.Parse(Console.ReadLine());

            double bonus = 0;

            if (points <= 100)
            {
                bonus = 5;
            }
            else if (points > 100 && points <= 1000)
            {
                bonus = points * 0.20;
            }
            else
            {
                bonus = points * 0.1;
            }

            if (points % 2 == 0)
            {
                bonus++;
            }
            else if (points % 5 == 0)
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(bonus + points);
        }
    }
}
