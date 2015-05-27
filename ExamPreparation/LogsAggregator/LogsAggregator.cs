using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class LogsAggregator
    {
        static void Main(string[] args)
        {
            string pattern = @"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\s+([a-zA-Z]+)\s+(\d*)";
            Regex regex = new Regex(pattern);
            int entry = int.Parse(Console.ReadLine());
            var user = new SortedDictionary<string, string>();
            var duration = new Dictionary<string, int>();

            for (int i = 0; i < entry; i++)
            {
                Match match = regex.Match(Console.ReadLine());
                string ip = match.Groups[1].Value;
                string name = match.Groups[2].Value;
                int time = int.Parse(match.Groups[3].Value);

                if (!user.ContainsKey(name))
                {
                    user.Add(name, ip);
                    duration.Add(name, time);
                }
                else
                {
                    if (!user.ContainsValue(ip))
                    {
                        user[name] = ip;
                        duration[name] += time;
                    }
                    else
                    {
                        duration[name] += time;
                    }
                }
            }
            foreach (var name in user)
            {               
                Console.Write("{0} :",name.Key);
                foreach (var ip in name.Value)
                {
                    Console.Write(String.Join(",",ip));
                }

            }
        }
    }
}
