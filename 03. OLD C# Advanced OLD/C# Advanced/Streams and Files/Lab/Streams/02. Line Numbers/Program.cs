using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"..\..\..\..\Resources\02. Line Numbers\Input.txt"))
            {
                int index = 0;

                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    using (var writer = new StreamWriter("Output.txt", true))
                    {
                        writer.WriteLine($"{index}. {line}");
                    }
                    index++;
                }
                
            }
        }
    }
}
