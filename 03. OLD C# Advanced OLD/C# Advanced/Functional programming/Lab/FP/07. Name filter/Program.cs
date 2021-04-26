namespace _07._Name_filter
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(w => w.Length <= n).ToArray();

            foreach (var name in names)
            {
                Console.WriteLine($"{name}");
            }
        }
    }
}
