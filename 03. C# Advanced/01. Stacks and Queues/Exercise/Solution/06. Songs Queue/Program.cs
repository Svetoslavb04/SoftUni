using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Songs_Queue
{
    public class Program
    {
        public static void Main()
        {
            var songs = new Queue<string>();

            var startSongs = Console.ReadLine().Split(", ");

            foreach (var song in startSongs)
            {
                if (!songs.Contains(song))
                {
                    songs.Enqueue(song);
                }
            }

            while (songs.Count > 0)
            {
                var command = Console.ReadLine().Split().ToList();

                if (command[0] == "Add")
                {
                    command.RemoveAt(0);

                    string song = string.Join(" ", command);

                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else if (command[0] == "Play")
                {
                    songs.Dequeue();
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
