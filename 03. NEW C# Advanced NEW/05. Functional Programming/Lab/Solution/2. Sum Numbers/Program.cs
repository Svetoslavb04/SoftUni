using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split(", ").Select(int.Parse);

            Console.WriteLine(line.Count());
            Console.WriteLine(line.Sum());

        }
    }
}
