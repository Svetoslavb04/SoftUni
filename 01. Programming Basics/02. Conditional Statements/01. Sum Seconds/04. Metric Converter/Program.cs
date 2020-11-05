using System;

namespace _04._Metric_Converter
{
    class Program
    {
        public static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            var input_metric = Console.ReadLine();
            var output_metric = Console.ReadLine();

            if (input_metric == "mm")
            {
                if (output_metric == "cm")
                {
                    Console.WriteLine($"{number / 10:f3}");
                }
                else
                {
                    Console.WriteLine($"{number / 1000:f3}");
                }
            }
            else if (input_metric == "m")
            {
                if (output_metric == "mm")
                {
                    Console.WriteLine($"{number * 1000:f3}");
                }
                else
                {
                    Console.WriteLine($"{number * 100:f3}");
                }
            }
            else
            {
                if (output_metric == "mm")
                {
                    Console.WriteLine($"{number * 10:f3}");
                }
                else
                {
                    Console.WriteLine($"{number / 100:f3}");
                }
            }
        }
    }
}
