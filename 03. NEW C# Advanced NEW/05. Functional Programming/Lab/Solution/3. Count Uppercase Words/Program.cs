using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    public class Program
    {
        public static void Main()
        {
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];

            var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(checker).ToArray();

            foreach (var item in line)
            {
                Console.WriteLine(item);
            }
        }
    }
}
