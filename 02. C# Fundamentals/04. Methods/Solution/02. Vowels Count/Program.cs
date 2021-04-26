using System;

namespace _02._Vowels_Count
{
    public class Program
    {
        public static void Main()
        {
            string word = Console.ReadLine();
            int vowels = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (ThereIsAVowel(word[i].ToString().ToLower()))
                {
                    vowels++;
                }
            }
            Console.WriteLine(vowels);
        }
        public static bool ThereIsAVowel(string letter)
        {
            bool vowel = false;
            if (letter == "a" || letter == "e" || letter == "i" || letter == "o" || letter == "u" || letter == "y")
            {
                vowel = true;
            }
            return vowel;
        }
    }
}
