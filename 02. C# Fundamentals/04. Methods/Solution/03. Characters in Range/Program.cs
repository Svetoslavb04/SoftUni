using System;

namespace _03._Characters_in_Range
{
    public class Program
    {
        public static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            for (int i = firstChar; i < secondChar - 1; i++)
            {
                firstChar++;

                Console.Write(firstChar + " ");
            }
        }
    }
}
