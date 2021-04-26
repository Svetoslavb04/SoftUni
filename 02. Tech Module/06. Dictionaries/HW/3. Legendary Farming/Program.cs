using System;
using System.Collections.Generic;
using System.Linq;
namespace _3._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Dictionary<string, int>();
            materials.Add("shards", 0);
            materials.Add("fragments", 0);
            materials.Add("motes", 0);
            var junk = new SortedDictionary<string, int>();
            bool winner = false;
            while (true)
            {
                var input = Console.ReadLine()
                .ToLower()
                .Split()
                .ToList();
                for (int i = 0; i < input.Count; i+=2)
                {
                    int currentQuantity = int.Parse(input[i]);
                    string currentMaterials = input[i + 1];
                    if (currentMaterials == "shards" || currentMaterials == "fragments" || currentMaterials == "motes")
                    {
                        materials[currentMaterials] += currentQuantity;
                    }
                    else
                    {
                        if (!junk.ContainsKey(currentMaterials))
                        {
                            junk.Add(currentMaterials, currentQuantity);
                        }
                        else
                        {
                            junk[currentMaterials] += currentQuantity;
                        }
                    }
                    if (materials.Any(x => x.Value >= 250))
                    {
                        winner = true;
                        break;
                    }
                }
                if (winner)
                {
                    if (materials["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        materials["shards"] -= 250;
                        break;
                    }
                    else if (materials["fragments"] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        materials["fragments"] -= 250;
                        break;
                    }
                    else if (materials["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        materials["motes"] -= 250;
                        break;
                    }
                }
            }
            foreach (var material in materials.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");

            }
        }
    }
}
