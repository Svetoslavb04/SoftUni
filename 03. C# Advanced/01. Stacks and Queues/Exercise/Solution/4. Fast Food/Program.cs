using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main()
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            var orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(orders.Max());

            int sumOfOrders = 0;

            while (orders.Count > 0)
            {
                int order = orders.Peek();
                sumOfOrders += order;

                if (quantityOfFood >= sumOfOrders)
                {
                    orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
