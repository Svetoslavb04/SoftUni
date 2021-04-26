using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02._Deciphering
{
    public class Program
    {
        public static void Main()
        {
            var toDecode = Console.ReadLine();
            string decodated = string.Empty;
            var regex = new Regex(@"[d-z]|[,]|[|]|[#]");
            for (int i = 0; i < toDecode.Length; i++)
            {
                var currChar = toDecode[i].ToString();
                bool hasMatch = regex.Match(currChar).Success;
                if (!hasMatch)
                {
                    Console.WriteLine("This is not the book you are looking for.");
                    return;
                }
            }

            for (int i = 0; i < toDecode.Length; i++)
            {
                char symbol = toDecode[i];
                int asciiNum = symbol;
                asciiNum -= 3;
                char nextSymbol = (char)asciiNum;
                decodated += nextSymbol;

            }

            var replace = Console.ReadLine().Split();
            var replacefrom = replace[0];
            var replacewith = replace[1];

            string replaced = decodated.Replace(replacefrom, replacewith);
            Console.WriteLine(replaced);
        }
    }
}
