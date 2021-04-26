using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var bigBox = new List<Box<int>>();

            for (int i = 0; i < count; i++)
            {
                var item = int.Parse(Console.ReadLine());
                bigBox.Add(new Box<int>(item));
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(bigBox, indexes[0], indexes[1]);

            foreach (var box in bigBox)
            {
                Console.WriteLine(box);
            }
        }

        static void Swap<T>(List<Box<T>> list, int index1, int index2)
        {
            Box<T> temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
