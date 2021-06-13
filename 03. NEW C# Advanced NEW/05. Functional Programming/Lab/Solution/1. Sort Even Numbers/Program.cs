using System;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split(", ").Select(int.Parse).Where(n => n % 2 == 0).OrderBy(n => n).ToArray();

            Console.WriteLine(string.Join(", ",line));
        }
    }
}
