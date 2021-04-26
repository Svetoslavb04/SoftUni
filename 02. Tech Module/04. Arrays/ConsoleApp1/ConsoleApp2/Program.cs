using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfWagons = int.Parse(Console.ReadLine());
            var people = new int[numberOfWagons];
            int sum = 0;

            for (int i = 0; i < numberOfWagons; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
                Console.Write($"{people[i]} ");
                sum = sum + people[i];
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
