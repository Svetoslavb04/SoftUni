using System;

namespace _03._Odd_or_Even_Position
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMin = int.MaxValue;
            double oddMax = int.MinValue;
            double evenSum = 0;
            double evenMin = int.MaxValue;
            double evenMax = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += number;

                    if (evenMin > number)
                    {
                        evenMin = number;
                    }
                    if (evenMax < number)
                    {
                        evenMax = number;
                    }
                }
                else
                {
                    oddSum += number;

                    if (oddMin > number)
                    {
                        oddMin = number;
                    }
                    if (oddMax < number)
                    {
                        oddMax = number;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");

            if (oddMin == int.MaxValue)
            {
                Console.WriteLine($"OddMin=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
            }
            if (oddMax == int.MinValue)
            {
                Console.WriteLine($"OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMax={oddMax:f2},");
            }

            Console.WriteLine($"EvenSum={evenSum:f2},");

            if (evenMin == int.MaxValue)
            {
                Console.WriteLine($"EvenMin=No,");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
            }
            if (evenMax == int.MinValue)
            {
                Console.WriteLine($"EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
