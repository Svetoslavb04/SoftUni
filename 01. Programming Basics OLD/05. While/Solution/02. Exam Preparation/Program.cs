using System;

namespace _02._Exam_Preparation
{
    public class Program
    {
        public static void Main()
        {
            int undesireableMarksThreshold = int.Parse(Console.ReadLine());
            int undesireableMarks = 0;

            double marks = 0;
            double marksSum = 0;

            int solvedProblems = 0;
            string lastProblem = "";

            while (undesireableMarks < undesireableMarksThreshold)
            {
                string problem = Console.ReadLine();

                if (problem == "Enough")
                {
                    double AvgMark = marksSum / marks;

                    Console.WriteLine($"Average score: {AvgMark:F2}");
                    Console.WriteLine($"Number of problems: {solvedProblems}");
                    Console.WriteLine($"Last problem: {lastProblem}");

                    return;
                }

                lastProblem = problem;
                solvedProblems++;

                int mark = int.Parse(Console.ReadLine());

                if (mark <= 4)
                {
                    undesireableMarks++;
                }

                marks++;
                marksSum += mark;
            }

            Console.WriteLine($"You need a break, {undesireableMarks} poor grades.");
        }
    }
}
