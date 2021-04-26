namespace _03.Ferrari
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            string driver = Console.ReadLine();
            var ferrari = new Ferrari(driver);
            StringBuilder printer = new StringBuilder();

            printer
                .Append(ferrari.Model)
                .Append($"/{ferrari.Brakes()}")
                .Append($"/{ferrari.Gas()}")
                .Append($"/{ferrari.Driver}");
            Console.WriteLine(printer);
        }
    }
}
