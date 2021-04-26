using System;

namespace _01._Sum_Seconds
{
    class Program
    {
        public static void Main()
        {
            int firtTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int totalTime = firtTime + secondTime + thirdTime;
            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            if (seconds <=9)
                {
                    Console.WriteLine($"{minutes}:0{seconds}");
                }
                else
                    {
                        Console.WriteLine($"{minutes}:{seconds}");
                    }

        }
    }
}
