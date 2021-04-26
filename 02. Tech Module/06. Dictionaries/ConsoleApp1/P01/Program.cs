
namespace P01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            var count = new SortedDictionary<double, int>();
            foreach (var number in numbers)
            {
                if (count.ContainsKey(number))
                {
                    count[number]++;
                }
                else
                {
                    count.Add(number, 1);
                }
            }
            foreach (var number in count)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
