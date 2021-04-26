using System;

namespace Equal_words
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine().ToLower();
            var word2 = Console.ReadLine().ToLower();
            if (word == word2)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
