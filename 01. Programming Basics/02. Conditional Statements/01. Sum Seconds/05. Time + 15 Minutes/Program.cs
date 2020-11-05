using System;

namespace _05._Time___15_Minutes
{
    public class Program
    {
        public static void Main()
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (minutes >= 45)
            {
                if (hour == 23)
                {
                    if (minutes + 15 - 60 < 10)
                    {
                        Console.WriteLine($"0:0{minutes + 15 - 60}");
                    }
                    else
                    {
                        Console.WriteLine($"0:{minutes + 15 - 60}");
                    }
                }
                else
                {
                    if (minutes + 15 - 60 < 10)
                    {
                        Console.WriteLine($"{hour + 1}:0{minutes + 15 - 60}");
                    }
                    else
                    {
                        Console.WriteLine($"{hour + 1}:{minutes + 15 - 60}");
                    }
                }
                
            }
            else
            {
                Console.WriteLine($"{hour}:{minutes+15}");
            }

            
        }
    }
}
