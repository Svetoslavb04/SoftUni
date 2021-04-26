namespace _06._Cinema_Tickets
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double percentageStandart = 0;
            double percentageStudents = 0;
            double percentageKids = 0;
            int totalTickets = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Finish")
                {
                    break;
                }

                string filmName = Console.ReadLine();
                int room = int.Parse(Console.ReadLine());
                int tickets = 0;
                double percentage = 0;

                for (int i = 0; i < room; i++)
                {
                    var ticketType = Console.ReadLine();

                    i   

                    if (ticketType == "student")
                    {
                        totalTickets++;
                        percentageStudents++;
                    }
                    if (ticketType == "standard")
                    {
                        totalTickets++;
                        percentageStandart++;
                    }
                    if (ticketType == "kid")
                    {
                        totalTickets++;
                        percentageKids++;
                    }
                }
            }
        }
    }
}
