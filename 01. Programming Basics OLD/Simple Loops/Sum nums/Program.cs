using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_nums
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            Console.WriteLine(sum);
        }
    }
}
