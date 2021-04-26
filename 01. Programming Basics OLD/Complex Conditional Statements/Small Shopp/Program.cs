using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine().ToLower();
            var city = Console.ReadLine().ToLower();
            var quantity = double.Parse(Console.ReadLine());
            double price;
            price = 0;

            switch (city)
            {
                case "sofia":
                    switch (product)
                    {
                        case "coffee":
                            price = 0.50 * quantity;
                         
                            break;
                        case "water":
                            price = 0.80 * quantity;
                            break;
                        case "beer":
                            price = 1.20 * quantity;
                            break;
                        case "sweets":
                            price = 1.45 * quantity;
                            break;
                        case "peanuts":
                            price = 1.60 * quantity;
                            break;
                        default:
                            break;
                    }
                break;
                case "plovdiv":
                    switch (product)
                    {
                        case "coffee":
                            price = 0.40 * quantity;
                            break;
                        case "water":
                            price = 0.70 * quantity;
                            break;
                        case "beer":
                            price = 1.15 * quantity;
                            break;
                        case "sweets":
                            price = 1.30 * quantity;
                            break;
                        case "peanuts":
                            price = 1.50 * quantity;
                            break;

                        default:
                            break;
                    }
                    break;
                case "varna":
                    switch (product)
                    {
                        case "coffee":
                            price = 0.45 * quantity;
                            break;
                        case "water":
                            price = 0.70 * quantity;
                            break;
                        case "beer":
                            price = 1.10 * quantity;
                            break;
                        case "sweets":
                            price = 1.35 * quantity;
                            break;
                        case "peanuts":
                            price = 1.55 * quantity;
                            break;
                        default:
                            break;
                    }
                    break;


                default:
                    break;

            }
            Console.WriteLine(price);
        }
    }
}
