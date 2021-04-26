using System;

namespace snow_day
{
    class Program
    {
        static void Main(string[] args)
        {
            var balls = int.Parse(Console.ReadLine());

            for (int i = 1; i <= balls; i++)
            {
                var snowballSnow = int.Parse(Console.ReadLine());
                var snowballTime = int.Parse(Console.ReadLine());
                var snowballQuality = int.Parse(Console.ReadLine());
                double snowballValue = Math.Pow(snowballSnow / snowballTime, snowballQuality);
                snowballValue = (snowballSnow / snowballTime) ^ snowballQuality;
                
            }
        }
    }
}
