using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            //int counter = 1;

            for (int i = 0; i < number; i++)
            {
                string[] inputLineColor = Console.ReadLine().Split(new string[] { " -> " },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = inputLineColor[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                string clothes = inputLineColor[1];
                string[] inputClotes = clothes.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var item in inputClotes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }

                //for (int j = 0; j < inputClotes.Length; j++)
                //{
                //    if (! wardrobe[color].ContainsKey(inputClotes[j]))
                //    {
                //        counter = 1;
                //        wardrobe[color][inputClotes[j]] = counter;
                //    }

                //    else
                //    {
                //        counter++;
                //        wardrobe[color][inputClotes[j]] = counter;
                //    }
                //}
            }

            string[] inputFinal = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var kvpColor in wardrobe)
            {
                Console.WriteLine($"{kvpColor.Key} clothes:");

                foreach (var kvpClothes in kvpColor.Value)
                {
                    if (kvpColor.Key == inputFinal[0] && kvpClothes.Key == inputFinal[1])
                    {
                        Console.WriteLine($"* {kvpClothes.Key} - {kvpClothes.Value} (found!)");
                    }

                    else
                    {
                        Console.WriteLine($"* {kvpClothes.Key} - {kvpClothes.Value}");
                    }
                }
            }
        }
    }
