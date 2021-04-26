using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = string.Empty;
            int counter = 0;

            for (int i = user.Length-1 ; i >= 0; i--)
            {
                pass += user[i];
            }

            for (int i = 1; i <=4; i++)
            {
                string pass1 = Console.ReadLine();
                if (pass1 == pass)
                {
                    Console.WriteLine($"User {user} logged in.");
                    return;
                }
                if (pass1 != pass)
                {
                    counter++;
                    if (counter == 4)
                    {
                        Console.WriteLine($"User {user} blocked!");
                        i = 6;
                        return;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
