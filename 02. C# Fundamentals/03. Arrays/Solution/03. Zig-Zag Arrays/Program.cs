using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArr = new int[n];
            int[] secondArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstArr[i] = numbers[0];
                    secondArr[i] = numbers[1];
                }
                else
                {
                    secondArr[i] = numbers[0];
                    firstArr[i] = numbers[1];
                }
            }

            Console.WriteLine(string.Join(' ',firstArr));
            Console.WriteLine(string.Join(' ',secondArr));
        }
    }
}
