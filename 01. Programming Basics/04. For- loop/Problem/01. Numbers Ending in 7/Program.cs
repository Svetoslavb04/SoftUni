using System;

namespace _01._Numbers_Ending_in_7
{
    public class Program
    {
        public static void Main()
        {
            for (int i = 1; i <= 997 ; i++)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
