using System;
using System.Linq;

namespace _02._Common_Elements
{
    public class Program
    {
        public static void Main()
        {

            string[] firstLine = Console.ReadLine().Split().ToArray();
            string[] secondLine = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < secondLine.Length; i++)
            {
                for (int j = 0; j < firstLine.Length; j++)
                {
                    if (secondLine[i] == firstLine[j])
                    {
                        Console.Write(secondLine[i] + " ");
                    }
                }
            }
        }
    }
}
