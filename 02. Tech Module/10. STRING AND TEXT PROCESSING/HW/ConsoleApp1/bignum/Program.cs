using System;
using System.Linq;
using System.Text;

namespace bignum
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Console.ReadLine());
            
            short multi = short.Parse(Console.ReadLine());
            var sum = (int)sb * multi;
            Console.WriteLine(sum);
        }
    }
}
