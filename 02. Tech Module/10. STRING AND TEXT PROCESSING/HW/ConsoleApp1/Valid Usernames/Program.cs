using System;
using System.Collections.Generic;
using System.Linq;

namespace Valid_Usernames
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            bool firstCheck = false;
            bool secondCheck = false;
            bool thirdCheck = false;
            for (int i = 0; i < text.Count; i++)
            {
                if (text[i].Length >= 3 && text[i].Length <=16)
                {
                    firstCheck = true;
                }
                var str = text[i];
                var arr = str.ToCharArray();
                bool f = !Char.IsLetterOrDigit(text[i][0]) && text[i][0] != '_';
                if (!f)
                {
                    secondCheck = true;
                }               
                int counter = 0;
                foreach (char c in arr)
                {
                    if (!Char.IsLetterOrDigit(c) && c != '_' && c != '-')
                    {
                        
                    }
                    else
                    {
                        counter++;
                    }
                }
                if (counter == text[i].Length)
                {
                    thirdCheck = true;
                }
                if (firstCheck == true && secondCheck == true && thirdCheck == true)
                {
                    Console.WriteLine(text[i]);
                }
                firstCheck = false;
                secondCheck = false;
                thirdCheck = false;
            } 
        }
    }
}
