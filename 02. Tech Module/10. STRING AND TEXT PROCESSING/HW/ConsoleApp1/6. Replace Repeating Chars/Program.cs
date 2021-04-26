using System;
using System.Linq;

namespace _6._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToCharArray();

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text.Length - 1)
                {
                    Console.Write(text[i]);
                }
                else
                {
                    if (text[i] == text[i + 1])
                    {

                    }
                    else
                    {
                        Console.Write(text[i]);
                    }
                }
                
            }
            Console.Write(text[text.Length-1]);
            Console.WriteLine();
        }
    }
}
