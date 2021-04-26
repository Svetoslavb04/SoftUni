using System;

namespace _05._Journey
{
    public class Program
    {
        public static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string typeHoliday = "";
            string destination = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";

                switch (season)
                {
                    case "summer":

                        typeHoliday = "Camp";
                        budget = budget * 0.3;

                        break;

                    case "winter":

                        typeHoliday = "Hotel";
                        budget = budget * 0.7;

                        break;

                    default:
                        break;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";

                switch (season)
                {
                    case "summer":

                        typeHoliday = "Camp";
                        budget = budget * 0.4;

                        break;

                    case "winter":

                        typeHoliday = "Hotel";
                        budget = budget * 0.8;

                        break;

                    default:
                        break;
                }
            }
            else
            {
                destination = "Europe";
                budget = budget * 0.9;
                typeHoliday = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeHoliday} - {budget:F2}");
        }
    }
}
