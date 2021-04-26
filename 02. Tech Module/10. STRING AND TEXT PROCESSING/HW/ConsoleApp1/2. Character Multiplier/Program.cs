using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Character_Multiplier
{
    class Program
    {
        public static void Main()
        {
            var filePath = Console.ReadLine();

            var indexOfExt = filePath.IndexOf('.');
            var ext = filePath.Substring(indexOfExt + 1);

            var indexOfCh = filePath.LastIndexOf('\\');

            var lenth = filePath.Substring(indexOfCh + 1);

            var name = filePath.Substring(indexOfCh + 1, lenth.Length - ext.Length - 1);
            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {ext}");
        }
    }
}
