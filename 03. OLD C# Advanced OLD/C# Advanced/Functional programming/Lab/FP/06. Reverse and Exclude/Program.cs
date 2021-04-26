namespace _06._Reverse_and_Exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<int, int, bool> isDivisible = (integer, num) => integer % num == 0;

            int toDivide = int.Parse(Console.ReadLine());

           List<int> numbers = new List<int>();

            for (int i = input.Count - 1; i >= 0; i--)
            {
                numbers.Add(input[i]);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (isDivisible(numbers[i], toDivide))
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            foreach (var num in numbers)
            {
                Console.Write($"{num} ");
            }
        }
    }
}
