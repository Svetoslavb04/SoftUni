using System;
using System.Linq;
using System.Collections.Generic;
namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfProducts = new Dictionary<string, double>();
            int counter = 0;
            var curQuantity = new Dictionary<string, long>();
            var curPrice = new Dictionary<string, double>();
            var productCounter = new Dictionary<string, long>();
            while (true)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToList();
                if (input[0] == "buy")
                {
                    break;
                }
                if (!productCounter.ContainsKey(input[0]))
                {
                    productCounter.Add(input[0], 1);
                }
                else
                {
                    productCounter[input[0]]++;
                }
                string product = input[0];
                double price = double.Parse(input[1]);
                if (productCounter[product] == 1)
                {
                    curPrice.Add(product, price);
                }
                else if (productCounter[product] % 2 == 0)
                {

                }
                else if (productCounter[product] % 3 == 0)
                {
                    curPrice.Remove(product);
                    curPrice.Add(product, price);
                }
                long quantity = long.Parse(input[2]);
                if (productCounter[product] == 1)
                {
                    curQuantity.Add(product, quantity);
                }
                else if (productCounter[product] % 2 == 0)
                {

                }
                else if (productCounter[product] % 3 == 0)
                {
                    curQuantity.Remove(product);
                    curQuantity.Add(product, quantity);
                }
                if (listOfProducts.ContainsKey(product))
                {
                    double valid = listOfProducts[product] / curQuantity[product];
                    double prevQuantity = listOfProducts[product] / curPrice[product];
                    if (valid == price)
                    {
                        listOfProducts[product] = valid * (quantity + prevQuantity);
                    }
                    else
                    {
                        listOfProducts[product] = price * (quantity + prevQuantity);

                    }
                }
                else
                {
                    listOfProducts.Add(product, price * quantity);
                }
                counter++;
            }
            foreach (var product in listOfProducts)
            {
                Console.WriteLine($"{product.Key} -> {product.Value:F2}");
            }
        }
    }
}
