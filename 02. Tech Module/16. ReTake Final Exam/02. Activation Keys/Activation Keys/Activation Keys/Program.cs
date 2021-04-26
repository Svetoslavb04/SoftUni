using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Activation_Keys
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            string regex = @"&?[a-zA-z0-9]{16,25}&?";
            var match = Regex.Match(input, regex);
            var allKeys = new List<string>();
            if (match.Success)
            {
                var matches = match.ToString().Split('&');
                for (int i = 0; i < matches.Length; i++)
                {
                    if (matches[i].Length == 16)
                    {
                        var groups = new List<string>();
                        for (int j = 0; j < 16; j++)
                        {
                            if (j < 4)
                            {
                                groups[0] += matches[i][j];
                            }
                            if (j > 3 && j < 8)
                            {
                                groups[1] += matches[i][j];
                            }
                            if (j > 7 && j < 12)
                            {
                                groups[2] += matches[i][j];
                            }
                            if (j > 13)
                            {
                                groups[2] += matches[i][j];
                            }
                        }
                        string key = groups[0] + "-" + groups[1] + "-" + groups[2] + "-" + groups[3] + "-";
                        string nums = @"[0-9]";
                        Match matchs = Regex.Match(key, nums);
                        var indexes = new int[matchs.Length];
                        for (int k = 0; k < matchs.Length; k++)
                        {
                            for (int j = 0; j < key.Length; j++)
                            {
                                if (key[j] == matchs.ToString()[0])
                                {
                                    indexes[k] = key.IndexOf(key[j]);
                                }
                            }
                        }
                        /*for (int h = 0; h < matchs.Length; h++)
                        {
                            char toReplace = matchs[].ToString()[0];
                            key.Replace(matchs[h].ToString(), 9 - matchs[h]);
                        }*/
                    }
                }
            }
        }
    }
}
