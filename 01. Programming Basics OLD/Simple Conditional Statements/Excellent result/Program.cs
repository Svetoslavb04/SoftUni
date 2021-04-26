using System;

namespace Excellent_result
{
    class Program
    {
        static void Main(string[] args)
        {
            var grade = double.Parse(Console.ReadLine());

            if (grade > 5.49)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}