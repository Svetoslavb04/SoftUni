using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pipe_in_pool
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = int.Parse(Console.ReadLine());
            var pipe1 = int.Parse(Console.ReadLine());
            var pipe2 = int.Parse(Console.ReadLine());
            var hours = double.Parse(Console.ReadLine());
            var full = pipe1 * hours + pipe2 * hours;
            var pp1 = (pipe1 * hours / full * 100);
            var pp2 = (pipe2 * hours / full * 100);
            full = (full * 100) / v;
           
            
                if (pipe1 * hours + pipe2 * hours <= v)
                {
                    Console.WriteLine($"The pool is {Math.Truncate(full)}% full. Pipe 1: {Math.Truncate(pp1)}%. Pipe 2: {Math.Truncate(pp2)}%.");
                }

                else
                {
                    Console.WriteLine($"For {hours} hours the pool overflows with {full - v} liters.");
                }
            
        }
    }
}
