namespace _03._Oscars_week_in_cinema
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var filmName = Console.ReadLine();
            var hall = Console.ReadLine();
            var tickets = double.Parse(Console.ReadLine());

            if (filmName == "A Star Is Born")
            {
                if (hall == "normal")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 7.5:F2} lv.");
                }
                else if (hall == "luxury")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 10.5:F2} lv.");
                }
                else if (hall == "ultra luxury")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 13.5:F2} lv.");
                }
            }
            else if (filmName == "Bohemian Rhapsody")
            {
                if (hall == "normal")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 7.35:F2} lv.");
                }
                else if (hall == "luxury")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 9.45:F2} lv.");
                }
                else if (hall == "ultra luxury")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 12.75:F2} lv.");
                }
            }
            else if (filmName == "Green Book")
            {
                if (hall == "normal")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 8.15:F2} lv.");
                }
                else if (hall == "luxury")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 10.25:F2} lv.");
                }
                else if (hall == "ultra luxury")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 13.25:F2} lv.");
                }
            }
            else if (filmName == "The Favourite")
            {
                if (hall == "normal")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 8.75:F2} lv.");
                }
                else if (hall == "luxury")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 11.55:F2} lv.");
                }
                else if (hall == "ultra luxury")
                {
                    Console.WriteLine($"{filmName} -> {tickets * 13.95:F2} lv.");
                }
            }
        }
    }
}
