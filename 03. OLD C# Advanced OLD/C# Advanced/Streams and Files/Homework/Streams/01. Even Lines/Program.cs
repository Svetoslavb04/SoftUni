namespace _01._Even_Lines
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    int index = 0;
                    while (true)
                    {
                        if (index % 2 !=0)
                        {
                            index++;
                            continue;
                        }
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == '-' || line[i] == ',' || line[i] == '.' || line[i] == '?' || line[i] == '!')
                            {
                                char[] array = line.ToCharArray();
                                array[i] = '@';
                                line = new string(array);
                            }
                        }

                        string toWrite = string.Empty;
                        for (int i = line.Length - 1; i >= 0; i--)
                        {
                            toWrite += line[i];
                        }

                        index++;
                        writer.WriteLine(toWrite);
                    }
                }
            }
        }
    }
}
