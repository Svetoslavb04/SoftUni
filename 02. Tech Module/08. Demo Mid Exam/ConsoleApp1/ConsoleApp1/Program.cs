using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> currentBestBread = new List<int>();
            currentBestBread.Add(3);
            currentBestBread.Add(3);
            currentBestBread.Add(3);
            currentBestBread.Add(5);
            Console.WriteLine(currentBestBread[3]);
        }
    }
}
