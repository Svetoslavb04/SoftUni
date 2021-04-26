namespace _05._Applied_Arithmetics
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] integers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int, int> executor;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                if (input == "add")
                {
                    executor = (num, index) => num[index]++;
                    Executor(integers, executor);

                }
                else if (input == "multiply")
                {
                    executor = (num, index) =>num[index] = num[index] * 2;
                    for (int i = 0; i < integers.Length; i++)
                    {
                        executor(integers, i);
                    }

                }
                else if (input == "subtract")
                {
                    executor = (num, index) => num[index]--;
                    Executor(integers, executor);
                    
                }
                else if (input == "print")
                {
                    foreach (var number in integers)
                    {
                        Console.Write($"{number} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static int[] Executor(int[] ints, Func<int[], int, int> exec)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                exec(ints, i);
            }
            return ints;
        }
    }
}
