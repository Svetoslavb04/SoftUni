namespace _03._Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var toCheck = new List<string>();
            using (var reader = new StreamReader("words.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    toCheck.Add(line);
                }
            }

            var words = new Dictionary<string, int>();

            for (int i = 0; i < toCheck.Count; i++)
            {
                words.Add(toCheck[i], 0);
            }

            using (var reader = new StreamReader("text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    line = line.ToLower();


                    for (int i = 0; i < words.Count; i++)
                    {
                        if (line.Contains(toCheck[i]))
                        {
                            words[toCheck[i]]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter("actualResult.txt"))
            {
                foreach (var item in words.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }            
        }
    }
}
