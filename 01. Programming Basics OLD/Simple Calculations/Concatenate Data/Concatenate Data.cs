﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concatenate_Data
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var firstName = Console.ReadLine();     
            var lastName = Console.ReadLine();      
            var age = int.Parse(Console.ReadLine());          
            var town = Console.ReadLine();

            Console.WriteLine($"You are {firstName} {lastName}, a {age}-years old person from {town}.");

        }
    }
}
