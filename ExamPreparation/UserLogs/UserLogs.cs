using System;
using System.Collections.Generic;
using System.Runtime.DesignerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace UserLogs
{
    class UserLogs
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> results = new SortedDictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string pattern = @"IP=\s*?([^\s]*)(?:\s*?message=.+\s*?user=\s*?)(\w.*)";
                Match m = Regex.Match(input, pattern);
                string ip = m.Groups[1].ToString();
                string name = m.Groups[2].ToString();
                if (!results.ContainsKey(name))
                {
                    var counter = new Dictionary<string, int>();
                    counter.Add(ip, 1);
                    results.Add(name, counter);
                }
                else
                {
                    if (results[name].ContainsKey(ip))
                    {
                        results[name][ip]++;
                    }
                    else
                    {
                        results[name].Add(ip, 1);
                    }

                }
                input = Console.ReadLine();
            }
            StringBuilder test = new StringBuilder();
            foreach (var dictionary in results)
            {
                test.Clear();
                Console.WriteLine("{0}: ", dictionary.Key);
                foreach (var pair in dictionary.Value)
                {
                    //Console.Write("{0} => {1}, ",pair.Key,pair.Value);
                    test.Append(string.Join(" => ", pair.Key, pair.Value));
                    test.Append(", ");
                }
                test.Remove(test.Length - 2, 2);
                test.Append('.');
                Console.WriteLine(test.ToString());
            }
        }
    }
}
