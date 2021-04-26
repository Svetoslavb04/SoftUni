using System;

namespace _04._Vacation_books_list
{
    class Program
    {
        static void Main()
        {
            int pages = int.Parse(Console.ReadLine());
            double pages_per_hour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double hours_per_days = pages / pages_per_hour / days;

            Console.WriteLine(hours_per_days);
        }
    }
}
