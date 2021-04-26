namespace _02._Line_Numbers
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    int index = 1;
                    while (true)
                    {
                        var line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        int chars = 0;
                        int puncts = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == '-' || line[i] == ',' || line[i] == '.' || line[i] == '?' || line[i] == '!' || line[i] == '\'')
                            {
                                puncts++;
                            }
                            else if (line[i] != ' ')
                            {
                                chars++;
                            }
                        }

                        writer.WriteLine($"Line {index}: {line} ({chars})({puncts})");
                    }
                }
            }
        }
    }
}
