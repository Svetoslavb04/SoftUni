namespace _02._Knights_of_Honor
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string[], int> sirrer = (n, i) =>
            {
                n[i] = $"Sir {n[i]}";
                Console.WriteLine(n[i]);
            };

            for (int i = 0; i < names.Length; i++)
            {
                sirrer(names, i);
            }
        }
    }
}
