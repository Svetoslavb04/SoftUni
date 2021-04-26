using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }
                var quantity = int.Parse(Console.ReadLine());
                if (dict.ContainsKey(input))
                {
                    dict[input] += quantity;
                }
                else
                {
                    dict[input] = quantity;
                }
            }
            foreach (var el in dict)
            {
                Console.WriteLine($"{el.Key} -> {el.Value}");
            }
        }
    }
}
