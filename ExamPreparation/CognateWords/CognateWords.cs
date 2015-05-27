using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CognateWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"[a-zA-Z]+";
            MatchCollection matches = Regex.Matches(input, pattern);
            var list = matches.Cast<Match>().Select(x => x.Value).ToList();
            HashSet<string> results = new HashSet<string>();
            bool hasMatch = false;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i; j < list.Count; j++)
                {
                    string tocheck = string.Concat(list[i], list[j]);
                    string tocheck2 = string.Concat(list[j], list[i]);
                    foreach (var test in list)
                    {
                        if (test == tocheck)
                        {
                            results.Add(string.Format("{0}|{1}={2}", list[i], list[j], test));
                            hasMatch = true;
                        }
                        if (tocheck2 == test)
                        {
                            results.Add(string.Format("{0}|{1}={2}", list[j], list[i], test));
                            hasMatch = true;
                        }
                    }
                }
            }
            foreach (var match in results)
            {
                Console.WriteLine(match);
            }
            if (!hasMatch)
            {
                Console.WriteLine("No");
            }
        }
    }
}