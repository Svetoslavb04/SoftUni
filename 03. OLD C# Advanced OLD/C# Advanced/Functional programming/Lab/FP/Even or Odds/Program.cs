namespace Even_or_Odds
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Predicate<int> predicate;

            int[] range = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string filter = Console.ReadLine();

            if (filter == "even")
            {
                predicate = n => n % 2 == 0;
            }
            else
            {
                predicate = n => n % 2 != 0;
            }

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (predicate(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
