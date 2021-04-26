using System;

namespace Bonus_score
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            double score = 0;0
            if (a > 1000)
            {
                score += (a * 0.10);
            }
            else if (a > 100)
                {
                    score += (a * 0.20);
                }
                    if (a < 101)
                        {
                            score += 5;
                        }
            if (a % 2 == 0)
                {
                    score += 1;
                }
                else if (a % 10 == 5)
                    {
                    score += 2;
                    }
            


            
            Console.WriteLine(score);
            Console.WriteLine(a + score);
        }
    }
}
