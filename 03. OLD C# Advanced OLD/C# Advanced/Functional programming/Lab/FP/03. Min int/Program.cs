namespace _03._Min_int
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var ints = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.pa).ToArray();
            Func<int[], int> miner = intArray => intArray.Min();

            Console.WriteLine(miner(ints));
        }
    }
}
