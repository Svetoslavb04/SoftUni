using System;

namespace _07._Fruit_Market
{
    class Program
    {
        static void Main()
        {
            double strawberry_price = double.Parse(Console.ReadLine());
            double bananas = double.Parse(Console.ReadLine());
            double oranges = double.Parse(Console.ReadLine());
            double raspberry = double.Parse(Console.ReadLine());
            double strawberries = double.Parse(Console.ReadLine());

            double raspberry_price = strawberry_price / 2;
            double orange_price = raspberry_price - (0.4 * raspberry_price);
            double banana_price = raspberry_price - (0.8 * raspberry_price);

            double required_amonut = bananas * banana_price + oranges * orange_price + raspberry * raspberry_price + strawberries * strawberry_price;

            Console.WriteLine(required_amonut);
        }
    }
}
