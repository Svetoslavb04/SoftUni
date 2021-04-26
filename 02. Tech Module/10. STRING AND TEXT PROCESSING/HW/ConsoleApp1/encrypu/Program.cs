using System;
using System.Collections.Generic;
using System.Linq;

namespace encrypu
{
    class Program
    {
        static void Main(string[] args)
        {
            var textToEncrypt = Console.ReadLine()
                .ToCharArray();
            var encryptedText = string.Empty;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                char symbol = textToEncrypt[i];
                int inInt = symbol;
                inInt += 3;
                char nextSymbol = (char)inInt;
                encryptedText += nextSymbol;
            }
            Console.WriteLine(encryptedText);
        }
    }
}
