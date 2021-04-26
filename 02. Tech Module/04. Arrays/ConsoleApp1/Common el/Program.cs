using System;

namespace Common_el
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(' ');
            string[] text2 = Console.ReadLine().Split(' ');
          
            var text3 = new string[text.Length];
            if (text.Length > text2.Length)
            {
                for (int i = 0; i < text.Length - (text.Length - text2.Length); i++)
                {
                    for (int p = 0; p < text2.Length; p++)
                    {
                        if (text[i] == text2[p] )
                        {
                            text3[i] = text[i];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < text2.Length - (text2.Length - text.Length); i++)
                {
                    for (int p = 0; p < text.Length; p++)
                    {
                        if (text2[i] == text[p])
                        {
                            text3[i] = text2[i];
                        }
                    }
                }
            }

            for (int i = 0; i < text3.Length - 1; i++)
            {
                Console.Write($"{text3[i]} ");
            }
            Console.WriteLine();
        }
    }
}
