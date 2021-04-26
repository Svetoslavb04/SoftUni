namespace _04._Copy_Binary_File
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            using (var readet = new FileStream(@"copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream(@"copied.png", FileMode.Create))
                {
                    while (true)
                    {

                        byte[] buffer = new byte[4096];
                        int byteSize = readet.Read(buffer, 0, buffer.Length);
                        if (byteSize < 1)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, byteSize);
                    }
                }
            }
        }
    }
}
