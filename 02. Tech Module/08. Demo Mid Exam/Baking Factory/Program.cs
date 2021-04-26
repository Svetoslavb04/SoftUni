using System;
using System.Collections.Generic;
using System.Linq;

namespace Baking_Factory
{
    class Program
    {
        static void Main()
        {
            List<long> currentBestBread = new List<long>();
            while (true)
            {
                var input = Console.ReadLine();
                long sumOfBestBread = 0;
                for (int i = 0; i <= currentBestBread.Count - 1; i++)
                {
                    sumOfBestBread += currentBestBread[i];
                }
                if (input == "Bake It!")
                {
                    Console.WriteLine($"Best Batch quality: {sumOfBestBread}");
                    break;
                }
                var bread = input
                    .Split("#", StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToList();
                double currentBestAvQ = bread.Sum() / bread.Count;
                if (bread.Sum() >= sumOfBestBread)
                {
                    if (bread.Sum() > sumOfBestBread)
                    {
                        if (currentBestBread.Count == 0)
                        {
                            for (int i = 0; i < bread.Count; i++)
                            {
                                currentBestBread.Add(bread[i]);
                            }
                        }
                        else
                        {
                            currentBestBread.Clear();
                            for (int i = 0; i <= bread.Count - 1; i++)
                            {
                                currentBestBread.Add(bread[i]);
                            }
                        }
                    }
                    else if (bread.Sum() == sumOfBestBread)
                    {
                        double BestAvQ = (currentBestBread.Sum()) / currentBestBread.Count;
                        if (BestAvQ <= currentBestAvQ)
                        {
                            if (BestAvQ < currentBestAvQ)
                            {
                                if (currentBestBread.Count == 0)
                                {
                                    for (int i = 0; i < bread.Count; i++)
                                    {
                                        currentBestBread.Add(bread[i]);
                                    }
                                }
                                else
                                {
                                    currentBestBread.Clear();
                                    for (int i = 0; i <= bread.Count - 1; i++)
                                    {
                                        currentBestBread.Add(bread[i]);
                                    }
                                }
                            }
                            if (BestAvQ == currentBestAvQ)
                            {
                                if (bread.Count > currentBestBread.Count)
                                {
                                    if (currentBestBread.Count == 0)
                                    {
                                        for (int i = 0; i < bread.Count; i++)
                                        {
                                            currentBestBread.Add(bread[i]);
                                        }
                                    }
                                    else
                                    {
                                        currentBestBread.Clear();
                                        for (int i = 0; i <= bread.Count - 1; i++)
                                        {
                                            currentBestBread.Add(bread[i]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
 

            }
            Console.WriteLine(string.Join(" ", currentBestBread));
        }
    }
}
