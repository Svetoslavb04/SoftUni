using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                var input = Console.ReadLine();
                string[] command = input.Split();

                if (command[0] == "End")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }

                if (command[0] == "Insert")
                {
                    if (int.Parse(command[1]) > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                        break;
                    }
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                if (command[0] == "Remove")
                {
                    if (int.Parse(command[1]) > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                        break;
                    }
                    numbers.RemoveAt(int.Parse(command[1]));
                }

                if (command[0] == "Shift")
                {
                    var numberOfRotations = int.Parse(command[2]);
                    var direction = command[1];

                    if (direction == "left")
                    {
                        for (int i = 0; i < numberOfRotations; i++)
                        {
                            int toAdd = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(toAdd);
                        }
                    }

                    if (direction == "right")
                    {
                        for (int i = 0; i < numberOfRotations; i++)
                        {
                            int toAdd = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, toAdd);
                        }
                    }

                }


            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
