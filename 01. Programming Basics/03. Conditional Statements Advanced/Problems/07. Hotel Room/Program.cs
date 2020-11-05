using System;

namespace _07._Hotel_Room
{
    public class Program
    {
        public static void Main()
        {
            var month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double studio = 0;
            double apartment = 0;

            switch (month)
            {
                case "May":
                case "October":

                    studio = 50 * days;
                    apartment = 65 * days;

                    if (days > 7 && days <= 14)
                    {
                        studio = studio - studio * 0.05;
                    }
                    else if (days > 14)
                    {
                        studio = studio - studio * 0.3;
                    }

                    break;

                case "June":
                case "September":

                    studio = 75.2 * days;
                    apartment = 68.7 * days;

                    if (days > 14)
                    {
                        studio = studio - studio * 0.2;
                    }

                    break;

                case "July":
                case "August":

                    studio = 76 * days;
                    apartment = 77 * days;

                    break;

                default:
                    break;
            }

            if (days > 14)
            {
                apartment = apartment - apartment * 0.1;
            }

            Console.WriteLine($"Apartment: {apartment:F2} lv.");
            Console.WriteLine($"Studio: {studio:F2} lv.");
        }
    }
}
