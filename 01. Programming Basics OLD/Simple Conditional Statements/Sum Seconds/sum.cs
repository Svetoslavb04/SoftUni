using System;

namespace Bonus_score
{
    class Program
    {
        static void Main(string[] args)
        {
            var secFirst = int.Parse(Console.ReadLine());
            var secSecond = int.Parse(Console.ReadLine());
            var secThird = int.Parse(Console.ReadLine());
            var summedSecs = secFirst + secSecond + secThird;

            if (summedSecs > 0 && summedSecs <= 59)
                {
                    if (summedSecs < 10)
                    {
                    Console.WriteLine($"0:0{summedSecs}");
                    }
                        else
                        {
                            Console.WriteLine($"0:{summedSecs}");
                        }
                }
                else if (summedSecs >= 60 && summedSecs <= 119)
                    {
                        summedSecs -= 60;
                        if (summedSecs < 10)
                        {
                            Console.WriteLine($"1:0{summedSecs}");
                        }
                            else
                            {
                                Console.WriteLine($"1:{summedSecs}");
                            }
                    }
                    else if (summedSecs > 120 && summedSecs < 179)
                    {
                        summedSecs -= 120;
                            if (summedSecs < 10)
                            {
                                Console.WriteLine($"2:0{summedSecs}");
                            }
                                else
                                {
                                    
                                    Console.WriteLine($"2:{summedSecs}");
                                }
                    }
            }
        }
    }

