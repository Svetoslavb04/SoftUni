using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    public class Program
    {
        public static void Main()
        {
            var clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var racks = 1;

            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRack = 0;

            while (clothes.Count > 0)
            {
                if (clothes.Peek() + currentRack <= rackCapacity)
                {
                    currentRack += clothes.Pop();
                }
                else
                {
                    racks++;
                    currentRack = 0;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
