using System;

namespace _04._Train_The_Trainers
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double avgGradeAtAll = 0;
            int totalPresentations = 0;
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Finish")
                {
                    break;
                }

                double avgGrade = 0;
                for (int i = 0; i < n; i++)
                {
                    double grade = double.Parse(Console.ReadLine());

                    avgGrade += grade;
                }

                totalPresentations++;
                avgGrade = avgGrade / n;
                avgGradeAtAll += avgGrade;

                Console.WriteLine($"{input} - {avgGrade:f2}");
            }

            Console.WriteLine($"Student's final assessment is {avgGradeAtAll / totalPresentations:F2}.");
        }
    }
}
