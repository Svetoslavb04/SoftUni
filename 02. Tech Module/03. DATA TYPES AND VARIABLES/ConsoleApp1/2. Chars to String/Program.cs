using System;

namespace _2._Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = char.Parse(Console.ReadLine());
            var second = char.Parse(Console.ReadLine());
            var third = char.Parse(Console.ReadLine());

            first.ToString();
            second.ToString();
            third.ToString();

            Console.WriteLine($"{first}{second}{third}");
        }
    }
}
