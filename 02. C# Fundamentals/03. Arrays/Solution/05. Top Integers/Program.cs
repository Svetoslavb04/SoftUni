using System;
using System.Linq;

namespace _05._Top_Integers
{
    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                bool bigger = true;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] <= array[j])
                    {
                        bigger = false;
                        break;
                    }
                }

                if (bigger)
                {
                    Console.Write(array[i] + " ");
                }
            }
        }
    }
}
