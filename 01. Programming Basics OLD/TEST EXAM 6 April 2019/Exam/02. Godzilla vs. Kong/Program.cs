namespace _02._Godzilla_vs._Kong
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var budjet = double.Parse(Console.ReadLine());
            var statists = int.Parse(Console.ReadLine());
            var cloth = double.Parse(Console.ReadLine()) * statists;

            var decor = 0.1 * budjet;

            if (statists >= 150)
            {
                cloth = cloth - cloth * 0.1;
            }

            if (decor + cloth > budjet)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(decor + cloth) - budjet:F2} leva more.");
            }

            if (decor + cloth <= budjet)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budjet - (decor + cloth):F2} leva left.");
            }
        }
    }
}
