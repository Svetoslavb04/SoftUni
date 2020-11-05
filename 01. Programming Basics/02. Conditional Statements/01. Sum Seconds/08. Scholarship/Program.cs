using System;

namespace _08._Scholarship
{
    public class Program
    {
        public static void Main()
        {
            double income = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minimalSalaray = double.Parse(Console.ReadLine());

            bool scholarShipOpportunity = false;
            bool socialScholarShipOpportunity = false;

            double scholarShip = 0;
            double socialScholarShip = 0;

            if (income < minimalSalaray && averageSuccess > 4.5)
            {
                socialScholarShipOpportunity = true;
                socialScholarShip = Math.Floor(minimalSalaray * 0.35);
            }
            if (averageSuccess >= 5.5)
            {
                scholarShipOpportunity = true;
                scholarShip = Math.Floor(averageSuccess * 25);
            }

            if (socialScholarShipOpportunity)
            {
                if (socialScholarShip > scholarShip)
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarShip} BGN");
                }
                else if (scholarShip != socialScholarShip)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {scholarShip} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {scholarShip} BGN");
                }
            }
            else if (scholarShipOpportunity)
            {
                if (socialScholarShip > scholarShip)
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarShip} BGN");
                }
                else if (scholarShip != socialScholarShip)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {scholarShip} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {scholarShip} BGN");
                }
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
