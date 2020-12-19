using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    public class Program
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                int firstDigit = i / 100000;
                int secondDigit = i / 10000 % 10;
                int thirdDigit = i / 1000 % 10;
                int fourthDigit = i / 100 % 10;
                int fifthDigit = i / 10 % 10;
                int sixthDigit = i / 1 % 10;

                int sumOdd = firstDigit + thirdDigit + fifthDigit;
                int sumEven = secondDigit + fourthDigit + sixthDigit;

                if (sumEven == sumOdd)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
