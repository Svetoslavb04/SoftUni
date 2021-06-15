using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main()
        {
            Func<List<int>, int> min = list => list.Min();

            Console.WriteLine(min(Console.ReadLine().Split().Select(int.Parse).ToList()));
        }
    }
}
