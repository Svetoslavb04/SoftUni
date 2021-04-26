namespace _03._Chore_Wars
{
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var regexDishes = new Regex(@"(?<=\<)[a-z0-9]*(?=>)");
            var regexHouse = new Regex(@"((?<=\[)[A-Z0-9]*(?=]))");
            var regexLaundry = new Regex(@"(?<={).*(?=})");
            int minsDishes = 0;
            int minsHouse = 0;
            int minsLaundry = 0;
            int currMin = 0;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "wife is happy")
                {
                    break;
                }
                bool hasMatchDishes = regexDishes.Match(input).Success;
                bool hasMatchHouse = regexHouse.Match(input).Success;
                bool hasMatchLaundry = regexLaundry.Match(input).Success;
                
                if (hasMatchDishes)
                {
                    var command = regexDishes.Matches(input)[0].ToString();
                    int currSum = 0;
                    for (int i = 0; i < command.Length; i++)
                    {
                        int currNum = 0;
                        var str = command[i].ToString();
                        int.TryParse(str, out currNum);
                        minsDishes += currNum;
                        currMin += currNum;
                    }
                    continue;
                }
                if (hasMatchHouse)
                {
                    var command = regexHouse.Matches(input)[0].ToString();
                    int currSum = 0;
                    for (int i = 0; i < command.Length; i++)
                    {
                        int currNum = 0;
                        var str = command[i].ToString();
                        int.TryParse(str, out currNum);
                        minsHouse += currNum;
                        currMin += currNum;
                    }
                    continue;
                }
                if (hasMatchLaundry)
                {
                    var command = regexLaundry.Matches(input)[0].ToString();
                    int currSum = 0;
                    for (int i = 0; i < command.Length; i++)
                    {
                        int currNum = 0;
                        var str = command[i].ToString();
                        int.TryParse(str, out currNum);
                        minsLaundry += currNum;
                        currMin += currNum;
                    }
                }                
            }
            Console.WriteLine($"Doing the dishes - {minsDishes} min.");
            Console.WriteLine($"Cleaning the house - {minsHouse} min.");
            Console.WriteLine($"Doing the laundry - {minsLaundry} min.");
            Console.WriteLine($"Total - {currMin} min.");
        }
    }
}
