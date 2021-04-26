using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var type = Console.ReadLine().ToLower();
            var day = Console.ReadLine().ToLower();
            double totalPrice = 0;

            if (type == "students")
            {
                if (day == "friday")
                {
                    totalPrice = numberOfPeople * 8.45;
                    if (numberOfPeople >= 30)
                    {
                        totalPrice = totalPrice - totalPrice * 0.15;
                    }
                }
                else if (day == "saturday")
                {
                    totalPrice = numberOfPeople * 9.8;
                    if (numberOfPeople >= 30)
                    {
                        totalPrice = totalPrice - totalPrice * 0.15;
                    }
                }
                else if (day == "sunday")
                {
                    totalPrice = numberOfPeople * 10.46;
                    if (numberOfPeople >= 30)
                    {
                        totalPrice = totalPrice - totalPrice * 0.15;
                    }
                }
            }
            else if (type == "business")
            {
                if (day == "friday")
                {
                    totalPrice = numberOfPeople * 10.9;
                    if (numberOfPeople >= 100)
                    {
                        totalPrice = totalPrice - 10 * 10.9;
                    }
                }
                else if (day == "saturday")
                {
                    totalPrice = numberOfPeople * 15.6;
                    if (numberOfPeople >= 100)
                    {
                        totalPrice = totalPrice - 10 * 15.6;
                    }
                }
                else if (day == "sunday")
                {
                    totalPrice = numberOfPeople * 16;
                    if (numberOfPeople >= 100)
                    {
                        totalPrice = totalPrice - 10 * 16;
                    }
                }
            }
            else if (type == "regular")
            {
                if (day == "friday")
                {
                    totalPrice = numberOfPeople * 15;
                    if (numberOfPeople >= 10 && numberOfPeople <= 20)
                    {
                        totalPrice = totalPrice - totalPrice * 0.05;
                    }
                }
                else if (day == "saturday")
                {
                    totalPrice = numberOfPeople * 20;
                    if (numberOfPeople >= 10 && numberOfPeople <= 20)
                    {
                        totalPrice = totalPrice - totalPrice * 0.05;
                    }
                }
                else if (day == "sunday")
                {
                    totalPrice = numberOfPeople * 22.5;
                    if (numberOfPeople >= 10 && numberOfPeople <=20)
                    {
                        totalPrice = totalPrice - totalPrice * 0.05;
                    }
                }
            }
            Console.WriteLine($"Total price: {totalPrice:F2}");


        }
    }
}
