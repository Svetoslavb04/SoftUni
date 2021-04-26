using System;

namespace _2._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    Console.Write(words[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
