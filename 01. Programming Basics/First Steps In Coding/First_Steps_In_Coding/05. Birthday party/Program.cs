using System;

namespace _05._Birthday_party
{
    class Program
    {
        static void Main()
        {
            double rent_hall = double.Parse(Console.ReadLine());

            double cake_price = 0.2 * rent_hall;
            double drinks_price = cake_price - cake_price * 0.45;
            double animator_price = rent_hall / 3;

            double required_money = rent_hall + cake_price + drinks_price + animator_price;

            Console.WriteLine(required_money);
        }
    }
}
