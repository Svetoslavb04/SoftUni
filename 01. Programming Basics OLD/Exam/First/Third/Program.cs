using System;

namespace Third
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string restaurant = Console.ReadLine();
            var portions = int.Parse(Console.ReadLine());
            char yn = char.Parse(Console.ReadLine());
            double total = 0;

            if (yn == 'Y')
            {
                total = total + (total * 0.2);
            }
            if (restaurant == "Sushi Zone")
            {
                if (type == "sashimi")
                {
                    total = portions * 4.99;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "maki")
                {
                    total = portions * 5.29;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "uramaki")
                {
                    total = portions * 5.99;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "temaki")
                {
                    total = portions * 4.29;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");                  
                }
            }
            if (restaurant == "Sushi Time")
            {
                if (type == "sashimi")
                {
                    total = portions * 5.49;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "maki")
                {
                    total = portions * 4.69;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "uramaki")
                {
                    total = portions * 4.49;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "temaki")
                {
                    total = portions * 5.19;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
            }
            if (restaurant == "Sushi Bar")
            {
                if (type == "sashimi")
                {
                    total = portions * 5.25;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "maki")
                {
                    total = portions * 5.55;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "uramaki")
                {
                    total = portions * 6.25;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "temaki")
                {
                    total = portions * 4.75;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
            }
            if (restaurant == "Asian Pub")
            {
                if (type == "sashimi")
                {
                    total = portions * 4.50;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "maki")
                {
                    total = portions * 4.80;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "uramaki")
                {
                    total = portions * 5.50;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                if (type == "temaki")
                {
                    total = portions * 5.50;
                    if (yn == 'Y')
                    {
                        total = total + (total * 0.2);
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
            }
            if (restaurant != "Sushi Zone" && restaurant != "Sushi Time" && restaurant != "Sushi Bar" && restaurant != "Asian Pub")
            {
                Console.WriteLine($"{restaurant} is invalid restaurant!");
            }
        }
    }
}
