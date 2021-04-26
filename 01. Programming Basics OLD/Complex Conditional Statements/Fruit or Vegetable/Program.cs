using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_or_Vegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine().ToLower();
            string type = "";
            switch (product)
            {
                case "banana":
                    type = "fruit";
                    Console.WriteLine(type);
                    break;
                case "apple":
                    type = "fruit";
                    Console.WriteLine(type);
                    break;
                case "kiwi":
                    type = "fruit";
                    Console.WriteLine(type);
                    break;
                case "cherry":
                    type = "fruit";
                    Console.WriteLine(type);
                    break;
                case "lemon":
                    type = "fruit";
                    Console.WriteLine(type);
                    break;
                case "grapes":
                    type = "fruit";
                    Console.WriteLine(type);
                    break;
                case "tomato":
                    type = "vegetable";
                    Console.WriteLine(type);
                    break;
                case "cucumber":
                    type = "vegetable";
                    Console.WriteLine(type);
                    break;
                case "pepper":
                    type = "vegetable";
                    Console.WriteLine(type);
                    break;
                case "carrot":
                    type = "vegetable";
                    Console.WriteLine(type);
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
            
        }
    }
}
