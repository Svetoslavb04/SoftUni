using System;
using System.Linq;

namespace _3._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                for (int r = i + 1; r < numbers.Length ; r++)
                {
                    int secondNumber = numbers[r];

                    if (number < secondNumber)
                    {
                        break;
                    }
                    else if (r == numbers.Length - 1)
                    {
                        Console.Write($"{number} ");
                    }
                }
            }
            
            Console.WriteLine(numbers[numbers.Length-1]);

        }
    }
}
