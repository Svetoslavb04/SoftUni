using System;

namespace Number_09_to_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            if (a == 1)
            {
                Console.WriteLine("one");
            }
            else if (a == 2)
                    {
                        Console.WriteLine("two");
                    }
                    else if (a == 3)
                            {
                                Console.WriteLine("three");
                            }
                            else if (a == 4)
                                {
                                    Console.WriteLine("four");
                                }
                                else if (a == 5)
                                    {
                                        Console.WriteLine("five");
                                    }
                                    else if (a == 6)
                                        {
                                            Console.WriteLine("six");
                                        }
                                        else if (a == 7)
                                            {
                                                Console.WriteLine("seven");
                                            }
                                            else if (a == 8)
                                                {
                                                    Console.WriteLine("eight");
                                                }
                                                else if (a == 9)
                                                    {
                                                    Console.WriteLine("nine");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Number too big");
                                                    }
        }
    }
}
