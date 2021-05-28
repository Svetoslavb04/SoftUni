using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    public class Program
    {
        public static void Main()
        {
            var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < nm[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < nm[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
