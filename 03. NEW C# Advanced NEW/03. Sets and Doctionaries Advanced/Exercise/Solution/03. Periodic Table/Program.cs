using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < line.Length; j++)
                {
                    set.Add(line[j]);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
