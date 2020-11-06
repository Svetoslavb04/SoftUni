using System;

namespace Problem
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum = sum + int.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);

            //Example for for loops idk
        }
    }
}
