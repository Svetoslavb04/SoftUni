using System;

namespace _07.Tuple
{
    public class Program
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine().Split();
            CoolTuple<string, string, string> firstTuple = new CoolTuple<string, string, string>(firstLine[0] + " " + firstLine[1], firstLine[2], firstLine[3]);
            Console.WriteLine(firstTuple);

            var secondLine = Console.ReadLine().Split();
            CoolTuple<string, int, bool> secondTuple = new CoolTuple<string, int, bool>(secondLine[0], int.Parse(secondLine[1]), secondLine[2] == "drunk" ? true : false);
            Console.WriteLine(secondTuple);

            var thirdLine = Console.ReadLine().Split();
            CoolTuple<string, double, string> thirdTuple = new CoolTuple<string, double, string>(thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]);
            Console.WriteLine(thirdTuple);
        }
    }
}
