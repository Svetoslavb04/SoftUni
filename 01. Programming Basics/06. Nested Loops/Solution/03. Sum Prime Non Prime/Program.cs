using System;

namespace _03._Sum_Prime_Non_Prime
{
    public class Program
    {
        public static void Main()
        {
            int sumPrimeNumbers = 0;
            int sumNonPrimeNumbers = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                int number = int.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative");
                }
                else
                {
                    int dividableNumber = 0;
                    for (int i = 2; i < number; i++)
                    {
                        if (number % i == 0)
                        {
                            dividableNumber++;
                        }
                    }

                    if (dividableNumber == 0)
                    {
                        sumPrimeNumbers += number;
                    }
                    else
                    {
                        sumNonPrimeNumbers += number;
                    }
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNumbers}");
        }
    }
}
