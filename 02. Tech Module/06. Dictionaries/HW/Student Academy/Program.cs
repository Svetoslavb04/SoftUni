using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = int.Parse(Console.ReadLine());
            var sG = new Dictionary<string, List<double>>();
            var stud = new List<string>();
            var sGS = new Dictionary<string, double>();
            var sGA = new Dictionary<string, double>();
            double s = 0;
            double a = 0;
            for (int i = 0; i < l; i++)
            {
                string n = Console.ReadLine();
                double g = double.Parse(Console.ReadLine());

                if (sG.ContainsKey(n))
                {
                    sG[n].Add(g);
                }
                else
                {
                    sG.Add(n, new List<double>());
                    sG[n].Add(g);
                    stud.Add(n);
                }
            }
            for (int i = 0; i < sG.Count; i++)
            {
                s = sG[stud[i]].Sum();
                sGS[stud[i]] = s;
                s = 0;
                a = sGS[stud[i]] / sG[stud[i]].Count;
                sGA[stud[i]] = a;
                a = 0;
            }
            foreach (var p in sGA.Where(n => n.Value >= 4.50).OrderByDescending(n => n.Value))
            {
                Console.WriteLine($"{p.Key} -> {p.Value:f2}");
            }
        }
    }
}
