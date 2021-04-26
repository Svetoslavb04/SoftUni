namespace _01._Sort_Even_nums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>, int> print = (n, i) => Console.WriteLine(n[i]);

            for (int i = 0; i < names.Count; i++)
            {
                print(names, i);
            }
        }
    }
}
