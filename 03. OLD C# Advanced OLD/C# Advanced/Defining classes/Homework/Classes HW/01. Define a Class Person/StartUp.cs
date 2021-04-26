namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Person person = new Person();

            person.Name = Console.ReadLine();
            person.Age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {person.Name} Age: {person.Age}");
        }
    }
}
