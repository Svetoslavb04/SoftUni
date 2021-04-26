namespace _04.Telephony
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            var smartphone = new Smartphone();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(smartphone.Call(numbers[i]));
            }

            for (int i = 0; i < urls.Length; i++)
            {
                Console.WriteLine(smartphone.Browser(urls[i])); 
            }
        }
    }
}
