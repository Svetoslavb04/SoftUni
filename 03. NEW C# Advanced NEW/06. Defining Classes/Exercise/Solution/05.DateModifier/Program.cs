﻿using System;

namespace _05.DateModifier
{
    class Program
    {
        static void Main()
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            Console.WriteLine(dateModifier.CalculateDifference(date1, date2));
        }
    }
}
