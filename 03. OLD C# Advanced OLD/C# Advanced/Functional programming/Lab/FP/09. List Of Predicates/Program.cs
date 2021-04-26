namespace _09._List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int range = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<int, int, bool> Divisible = (integer, divider) => integer % divider == 0;

            for (int i = 1; i <= range; i++)
            {
                int counter = 0;
                for (int k = 0; k < dividers.Count; k++)
                {
                    if (Divisible(i, dividers[k]))
                    {
                        counter++;
                    }
                }
                if (counter == dividers.Count)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
