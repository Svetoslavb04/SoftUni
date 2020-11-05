using System;

namespace _07._World_Swimming_Record
{
    public class Program
    {
        public static void Main()
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double recordInMeters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double attempt = secondsPerMeter * recordInMeters;

            attempt = attempt + Math.Floor(recordInMeters / 15) * 12.5;

            if (attempt < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {attempt:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {attempt - recordInSeconds:f2} seconds slower.");
            }
        }
    }
}
