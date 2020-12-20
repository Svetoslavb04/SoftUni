using System;
using System.Linq;

namespace _04._Array_Rotation
{
    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)     //51 47 32 61 21    // 47 32 61 21 51    // 32 61 21 51 47
            {
                int firstNum = array[0];

                for (int j = 1; j < array.Length; j++)
                {
                    array[j - 1] = array[j];
                }

                array[array.Length - 1] = firstNum;
            }

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
