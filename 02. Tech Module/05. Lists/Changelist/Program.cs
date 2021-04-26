using System;
using System.Collections.Generic;
using System.Linq;

namespace Changelist
{
    class Program
    {
        static void Main(string[] args)
        {
             var number = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToList();

            while (true)
            {
                var input = Console.ReadLine();
                string[] command = input.Split();

                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "Delete")
                {
                    number.Remove(int.Parse(command[1]));
                }

                if (command[0] == "Insert")
                {
                    number.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }
            }
            Console.WriteLine(string.Join(" ",number));
        }
    }
}
