using System;

namespace _01._Old_Books
{
    public class Program
    {
        public static void Main()
        {
            string searchedBook = Console.ReadLine();
            int checkedBooks = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {checkedBooks} books.");
                    break;
                }

                if (input == searchedBook)
                {
                    Console.WriteLine($"You checked {checkedBooks} books and found it.");
                    break;
                }

                checkedBooks++;
            }
        }
    }
}
