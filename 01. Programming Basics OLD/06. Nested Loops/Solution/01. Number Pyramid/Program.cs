using System;

namespace _01._Number_Pyramid
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int printed = 0;
            int current = 1;

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (printed == n)
                    {
                        break;
                    }

                    Console.Write($"{current} ");

                    current++;
                    printed++;

                }
                Console.WriteLine();
            }
        }
    }
}
