using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToList();

            int startNum = line[0];
            int lastNum = line[1];
            string oddOrEven = Console.ReadLine();

            Func<int, bool> isEven = num => num % 2 == 0;

            List<int> list = new List<int>();

            switch (oddOrEven)
            {
                case "even":
                    for (int i = startNum; i <= lastNum; i++)
                    {
                        if (isEven(i))
                        {
                            list.Add(i);
                        }
                    }
                    break;
                case "odd":
                    for (int i = startNum; i <= lastNum; i++)
                    {
                        if (!isEven(i))
                        {
                            list.Add(i);
                        }
                    }
                    break;
                default:
                    break;
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
