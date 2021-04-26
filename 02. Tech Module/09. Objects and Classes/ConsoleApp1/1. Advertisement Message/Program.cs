using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            var Phares = new List<string>()
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            var Events = new List<string>()
            {   "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            var Authors = new List<string>()
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            var Cities = new List<string>()
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };
            var random = new Random();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int pos1 = 0; pos1 < Phares.Count; pos1++)
                {
                    var pos2 = random.Next(0,Phares.Count);
                    var val = Phares[pos1];
                    Phares[pos1] = Phares[pos2];
                    Phares[pos2] = val;
                }
                for (int pos1 = 0; pos1 < Events.Count; pos1++)
                {
                    var pos2 = random.Next(0, Events.Count);
                    var val = Events[pos1];
                    Events[pos1] = Events[pos2];
                    Events[pos2] = val;
                }
                for (int pos1 = 0; pos1 < Authors.Count; pos1++)
                {
                    var pos2 = random.Next(0, Authors.Count);
                    var val = Authors[pos1];
                    Authors[pos1] = Authors[pos2];
                    Authors[pos2] = val;
                }
                for (int pos1 = 0; pos1 < Cities.Count; pos1++)
                {
                    var pos2 = random.Next(0, Cities.Count);
                    var val = Cities[pos1];
                    Cities[pos1] = Cities[pos2];
                    Cities[pos2] = val;
                }
                var pos3 = random.Next(0, Phares.Count-1);
                var pos4 = random.Next(0, Phares.Count-1);
                var pos5 = random.Next(0, Phares.Count-1);
                var pos6 = random.Next(0, Phares.Count-1);

                Console.WriteLine($"{Phares[pos3]} {Events[pos4]} {Authors[pos5]} - {Cities[pos6]}");
            }
        }
    }
}
