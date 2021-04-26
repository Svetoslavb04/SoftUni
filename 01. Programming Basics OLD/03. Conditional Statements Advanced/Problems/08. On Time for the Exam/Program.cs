using System;

namespace _08._On_Time_for_the_Exam
{
    public class Program
    {
        public static void Main()
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examHourInMinutes = examHour * 60;
            int arrivalHourInMinutes = arrivalHour * 60;

            int examTotalMinutes = examHourInMinutes + examMinutes;
            int arrivalTotalMinutes = arrivalHourInMinutes + arrivalMinutes;

            if (examTotalMinutes >= arrivalTotalMinutes)
            {
                if (examTotalMinutes - arrivalTotalMinutes < 60 && examTotalMinutes - arrivalTotalMinutes >= 0)
                {
                    if (examTotalMinutes - arrivalTotalMinutes == 0)
                    {
                        Console.WriteLine("On time");
                    }
                    else if ((examTotalMinutes - arrivalTotalMinutes) % 60 <= 30 && (examTotalMinutes - arrivalTotalMinutes) % 60 >= 0)
                    {
                        Console.WriteLine("On time");
                        Console.WriteLine($"{(examTotalMinutes - arrivalTotalMinutes) % 60} minutes before the start");
                    }
                    else if (examTotalMinutes - arrivalTotalMinutes > 30)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{(examTotalMinutes - arrivalTotalMinutes) % 60} minutes before the start");
                    }
                }
                else if (examTotalMinutes - arrivalTotalMinutes >= 60) // 9 40 6 55 580 415
                {
                    Console.WriteLine("Early");

                    if ((examTotalMinutes - arrivalTotalMinutes) % 60 >= 10) 
                    {
                        Console.WriteLine($"{(examTotalMinutes - arrivalTotalMinutes) / 60}:{(examTotalMinutes - arrivalTotalMinutes) % 60} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{(examTotalMinutes - arrivalTotalMinutes) / 60}:0{(examTotalMinutes - arrivalTotalMinutes) % 60} hours before the start");
                    }
                }
            }
            else
            {
                Console.WriteLine("Late"); 

                if (arrivalTotalMinutes - examTotalMinutes < 60  && arrivalTotalMinutes - examTotalMinutes >= 0) 
                {
                    Console.WriteLine($"{arrivalTotalMinutes - examTotalMinutes} minutes after the start");
                }
                else
                {
                    if ((arrivalTotalMinutes - examTotalMinutes) % 60 >= 10)
                    {
                        Console.WriteLine($"{(arrivalTotalMinutes - examTotalMinutes) / 60}:{(arrivalTotalMinutes - examTotalMinutes) % 60} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{(arrivalTotalMinutes - examTotalMinutes) / 60}:0{(arrivalTotalMinutes - examTotalMinutes) % 60} hours after the start");
                    }
                }
            }
        }
    }
}
