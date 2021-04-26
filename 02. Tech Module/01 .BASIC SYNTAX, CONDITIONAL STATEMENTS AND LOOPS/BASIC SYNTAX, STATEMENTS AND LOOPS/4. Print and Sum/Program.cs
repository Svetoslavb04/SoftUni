using System;

namespace _4._Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = int.Parse(Console.ReadLine());
            var to = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = from; i <= to; i++)
            {
                Console.Write($"{i} ");
                sum = sum + i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
