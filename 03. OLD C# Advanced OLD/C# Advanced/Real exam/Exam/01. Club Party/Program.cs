namespace _01._Club_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>(line);
            var halls = new Dictionary<string, List<int>>();
            string currentHall = string.Empty;
            Queue<string> allHalls = new Queue<string>();

            for (int i = 0; i < line.Length; i++)
            {
                string currSymbol = stack.Pop();
                bool Isnumber = int.TryParse(currSymbol, out int number);

                if (!Isnumber)
                {
                    halls.Add(currSymbol, new List<int>());
                    if (currentHall == string.Empty)
                    {
                        currentHall = currSymbol;
                    }
                    else
                    {
                        allHalls.Enqueue(currSymbol);
                    }
                }
                else
                {                
                    if (currentHall == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        int currentNumber = int.Parse(currSymbol);
                        var sum = Sum(halls, currentHall, currentNumber);
                        if (sum <= hallCapacity)
                        {
                            halls[currentHall].Add(currentNumber);
                        }
                        else
                        {
                            if (!allHalls.Any())
                            {
                                continue;
                            }
                            currentHall = allHalls.Dequeue();
                            halls[currentHall].Add(currentNumber);
                        }
                    }
                }
            }

            foreach (var reservation in halls)
            {
                if (reservation.Value.Count == 0)
                {
                    continue;
                }
                Console.Write($"{reservation.Key} -> {string.Join(", ",reservation.Value)}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        public static void AddToHall(Dictionary<string, List<int>> halls, string currentHall, string currSymbol)
        {
            int currentNumber = int.Parse(currSymbol);
            halls[currentHall].Add(currentNumber);
        }

        public static int Sum(Dictionary<string,List<int>> halls, string currentHall, int currentNumber)
        {
            List<int> numbersOfReservations = halls[currentHall];
            int sum = 0;
            for (int j = 0; j < numbersOfReservations.Count; j++)
            {
                sum += numbersOfReservations[j];
            }
            
            return sum + currentNumber;
        }
    }
}
