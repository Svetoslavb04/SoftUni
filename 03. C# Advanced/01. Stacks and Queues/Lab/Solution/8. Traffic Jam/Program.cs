using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    public class Program
    {
        public static void Main()
        {
            var traffic = new Queue<string>();
            int passed = 0;

            int n = int.Parse(Console.ReadLine());

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                if (input != "green")
                {
                    traffic.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (traffic.Count > 0)
                        {
                            Console.WriteLine($"{traffic.Dequeue()} passed!");
                            passed++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"{passed} cars passed the crossroads.");
        }
    }
}
