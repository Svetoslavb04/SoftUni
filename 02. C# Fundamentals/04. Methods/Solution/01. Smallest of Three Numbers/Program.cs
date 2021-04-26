using System;

namespace _01._Smallest_of_Three_Numbers
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int smallestNumber = int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                smallestNumber = IsBigger(smallestNumber, numbers[i]);
            }

            Console.WriteLine(smallestNumber);
        }

        public static int IsBigger(int currentSmallestNumber, int pretender)
        {
            int smallest = currentSmallestNumber;

            if (pretender < currentSmallestNumber)
            {
                smallest = pretender;
            }

            return smallest;
        }
           
    }
}
