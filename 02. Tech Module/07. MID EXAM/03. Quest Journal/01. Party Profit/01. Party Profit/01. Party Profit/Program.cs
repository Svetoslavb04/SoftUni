using System;

namespace _01._Party_Profit
{
    public class Program
    {
        public static void Main()
        {
            var partySize = int.Parse(Console.ReadLine());
            var partyLength = int.Parse(Console.ReadLine());
            double totalCoins = 0;
            var spentCoins = 0;
            var gainedCoins = 0;

            for (int i = 1; i <= partyLength; i++)
            {
                spentCoins += 2 * partySize;
                gainedCoins += 50;
                if (i % 10 == 0)
                {
                    partySize -= 2;
                }
                if (i % 15 == 0)
                {
                    partySize += 5;
                }                
                if (i % 5 == 0 && i % 3 == 0)
                {
                    spentCoins += 5 * partySize;
                    gainedCoins += 20 * partySize;
                    continue;
                }
                if (i % 5 == 0)
                {
                    gainedCoins += 20 * partySize;
                }
                if (i % 3 == 0)
                {
                    spentCoins += 3 * partySize;
                }                
            }
            totalCoins = gainedCoins - spentCoins;            
            Console.WriteLine($"{partySize} companions received {Math.Floor(totalCoins / partySize)} coins each.");
        }
    }
}
