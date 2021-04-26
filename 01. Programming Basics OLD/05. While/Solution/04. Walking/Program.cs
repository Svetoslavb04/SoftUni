using System;

namespace _04._Walking
{
    public class Program
    {
        public static void Main()
        {
            int totalStepsWalked = 0;

            while (totalStepsWalked < 10000)
            {
                var input = Console.ReadLine();

                if (input == "Going home")
                {
                    int stepsToHome = int.Parse(Console.ReadLine());
                    totalStepsWalked += stepsToHome;

                    break;
                }

                int steps = int.Parse(input);

                totalStepsWalked += steps;
            }

            if (totalStepsWalked < 10000)
            {
                Console.WriteLine($"{10000 - totalStepsWalked} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalStepsWalked - 10000} steps over the goal!");
            }
        }
    }
}
