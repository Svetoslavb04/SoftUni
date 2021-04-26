namespace _01._Oscars_ceremony
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var rent = int.Parse(Console.ReadLine());

            var statues = 0.7 * rent;
            var catering = 0.85 * statues;
            var sound = 0.5 * catering;

            Console.WriteLine($"{(statues + catering + sound + rent):F2}");
        }
    }
}
