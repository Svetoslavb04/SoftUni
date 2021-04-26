using System;

namespace _05._Divide_Without_Remainder
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double dividableByTwo = 0;
            double dividableByThree = 0;
            double dividableByFour = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    dividableByTwo++;
                }
                if (number % 3 == 0)
                {
                    dividableByThree++;
                }
                if (number % 4 == 0)
                {
                    dividableByFour++;
                }
            }

            double percentDividableByTwo = dividableByTwo * 100 / n;
            double percentDividableByThree = dividableByThree * 100 / n;
            double percentDividableByFour = dividableByFour * 100 / n;

            Console.WriteLine($"{percentDividableByTwo:F2}%");
            Console.WriteLine($"{percentDividableByThree:F2}%");
            Console.WriteLine($"{percentDividableByFour:F2}%");
        }
    }
}
