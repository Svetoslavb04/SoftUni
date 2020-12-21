using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] sequence = new int[1];
            int numbersInSequence = 1;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        numbersInSequence++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (sequence.Length < numbersInSequence)
                {
                    sequence = new int[numbersInSequence];

                    for (int k = 0; k < numbersInSequence; k++)
                    {
                        sequence[k] = array[i];
                    }
                }

                numbersInSequence = 1;
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
