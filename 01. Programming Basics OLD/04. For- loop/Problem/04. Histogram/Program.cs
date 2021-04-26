using System;

namespace _04._Histogram
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double amountOne = 0;
            double amountTwo = 0;
            double amountThree = 0;
            double amountFour = 0;
            double amountFive = 0;

            double totalNumbers = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                totalNumbers ++;

                if (number < 200)
                {
                    amountOne++;
                }
                else if (number < 400)
                {
                    amountTwo++;
                }
                else if (number < 600)
                {
                    amountThree++;
                }
                else if (number < 800)
                {
                    amountFour++;
                }
                else
                {
                    amountFive++;
                }
            }

            Console.WriteLine($"{amountOne * 100 / totalNumbers:F2}%");
            Console.WriteLine($"{amountTwo * 100 / totalNumbers:F2}%");
            Console.WriteLine($"{amountThree * 100 / totalNumbers:F2}%");
            Console.WriteLine($"{amountFour * 100 / totalNumbers:F2}%");
            Console.WriteLine($"{amountFive * 100 / totalNumbers:F2}%");
        }
    }
}
