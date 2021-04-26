using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Console.WriteLine(new string(' ', input + 1) + "|");

            for (int i = input - 1; i >= 0; i--)
            {
                Console.WriteLine(new string(' ',i) + new string('*', input - i) + ' ' + '|' + ' ' + new string('*', input - i));
            }
        }
    }
}
