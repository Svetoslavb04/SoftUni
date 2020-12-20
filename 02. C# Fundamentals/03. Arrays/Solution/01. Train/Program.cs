using System;

namespace _01._Train
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] wagoons = new int[n];

            for (int i = 0; i < n; i++)
            {
                wagoons[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(' ', wagoons));

            int sum = 0;

            for (int i = 0; i < wagoons.Length; i++)
            {
                sum += wagoons[i];
            }

            Console.WriteLine(sum);
        }
    }
}
