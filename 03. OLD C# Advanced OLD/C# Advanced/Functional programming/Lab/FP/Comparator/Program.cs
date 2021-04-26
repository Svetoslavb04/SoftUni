namespace Comparator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var evens = input.Where(i => i % 2 == 0).ToArray();
            var odds = input.Where(i => i % 2 != 0).ToArray();

            Array.Sort(evens);
            Array.Sort(odds);

            for (int i = 0; i < evens.Length; i++)
            {
                Console.Write($"{evens[i]} ");
            }
            for (int i = 0; i < odds.Length; i++)
            {
                Console.Write($"{odds[i]} ");
            }
            Console.WriteLine();
        }
    }
}
