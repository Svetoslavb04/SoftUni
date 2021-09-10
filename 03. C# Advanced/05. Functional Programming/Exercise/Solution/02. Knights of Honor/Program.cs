using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split();

            Action<string> print = word => Console.WriteLine($"Sir {word}");

            foreach (var word in line)
            {
                print(word);
            }
        }
    }
}
