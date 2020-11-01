using System;

namespace _03._Deposit_Calculator
{
    class Program
    {
        static void Main()
        {
            double sum = double.Parse(Console.ReadLine());
            int range = int.Parse(Console.ReadLine()); //months 1...12
            double year_interest = double.Parse(Console.ReadLine());

            //сума = депозирана сума + срок на депозита *((депозирана сума* годишен лихвен процент ) / 12)
            double result = sum + range * ((sum * year_interest / 100) / 12);

            Console.WriteLine(result);
        }
    }
}
