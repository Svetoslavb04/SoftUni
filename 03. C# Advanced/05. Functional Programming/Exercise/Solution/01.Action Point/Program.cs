using System;

namespace _01.Action_Point
{
    class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split();

            Action<string> print = word => Console.WriteLine(word);

            foreach (var word in line)
            {
                print(word);
            }
        }
    }
}
