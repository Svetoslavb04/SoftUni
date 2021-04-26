using System;

namespace Guess_the_password
{
    class Program
    {
        static void Main(string[] args)
        {
            var pass = Console.ReadLine();
            if (pass == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
