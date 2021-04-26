namespace 1.GenericBoxOfString
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string value = Console.ReadLine();
                Box<string> box = new Box<string>(value);

                Console.WriteLine(box);
            }
        }
    }
}
