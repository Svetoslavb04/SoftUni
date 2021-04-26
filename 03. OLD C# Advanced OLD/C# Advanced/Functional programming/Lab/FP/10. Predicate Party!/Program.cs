namespace _10._Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> members = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                if (input[0] == "Party!")
                {
                    break;
                }

                if (input[0] == "Remove")
                {
                    if (input[1] == "StartsWith")
                    {
                        var startsWith = members.Where(m => m.StartsWith(input[2])).ToArray();
                        for (int i = 0; i < startsWith.Length; i++)
                        {
                            members.Remove(startsWith[i]);
                        }
                    }
                    if (input[1] == "Length")
                    {
                        var startsWith = members.Where(m => m.Length == int.Parse(input[2])).ToArray();
                        for (int i = 0; i < startsWith.Length; i++)
                        {
                            members.Remove(startsWith[i]);
                        }
                    }
                    if (input[1] == "EndsWith")
                    {
                        var startsWith = members.Where(m => m.EndsWith(input[2])).ToArray();
                        for (int i = 0; i < startsWith.Length; i++)
                        {
                            members.Remove(startsWith[i]);
                        }
                    }
                }
                else if (input[0] == "Double")
                {
                    if (input[1] == "StartsWith")
                    {
                        var startsWith = members.Where(m => m.StartsWith(input[2])).ToArray();
                        for (int i = 0; i < startsWith.Length; i++)
                        {
                            members.Add(startsWith[i]);
                        }
                    }
                    if (input[1] == "Length")
                    {
                        var startsWith = members.Where(m => m.Length == int.Parse(input[2])).ToArray();
                        for (int i = 0; i < startsWith.Length; i++)
                        {
                            members.Add(startsWith[i]);
                        }
                    }
                    if (input[1] == "EndsWith")
                    {
                        var startsWith = members.Where(m => m.EndsWith(input[2])).ToArray();
                        for (int i = 0; i < startsWith.Length; i++)
                        {
                            members.Add(startsWith[i]);
                        }
                    }
                }
            }
            if (members.Count > 0)
            {
                Console.Write(string.Join(", ", members.OrderBy(m => m)) + ' ');
                Console.Write($"are going to the party!");
            }           
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            Console.WriteLine();
        }
    } 
}
