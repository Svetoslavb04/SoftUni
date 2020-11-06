using System;

namespace _9._Volleyball
{
    public class Program
    {
        public static void Main()
        {
            string typeYear = Console.ReadLine(); //leap or normal
            double holidays = double.Parse(Console.ReadLine());
            int weekendsToTravelHome = int.Parse(Console.ReadLine());

            double weekendsInSofia = 48 - weekendsToTravelHome;

            double totalVolleybalMatches = 0;

            totalVolleybalMatches = totalVolleybalMatches + weekendsInSofia * 3 / 4;
            totalVolleybalMatches = totalVolleybalMatches + weekendsToTravelHome;
            totalVolleybalMatches = totalVolleybalMatches + holidays * 2 / 3;

            if (typeYear == "leap")
            {
                totalVolleybalMatches = totalVolleybalMatches + totalVolleybalMatches * 0.15;
            }

            Console.WriteLine(Math.Floor(totalVolleybalMatches));
        }
    }
}
