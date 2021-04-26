using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var reader = new StreamReader(@"Resources\01. Odd Lines\Input.txt"))
            {
                int index = 0;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (index % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    index++;
                }
            }
        }
    }
}
