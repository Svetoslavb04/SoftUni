using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string num = Console.ReadLine();

                if (dictionary.ContainsKey(num))
                {
                    dictionary[num]++;
                }
                else
                {
                    dictionary.Add(num, 1);
                }
            }

            Console.WriteLine(dictionary.Where(x => x.Value % 2 == 0).FirstOrDefault().Key);
        }
    }
}
