using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OfficeStuff
{
    class OfficeStuff
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-Za-z]+)\s*-\s*(\d+)\s*-\s*([A-Za-z]+)";
            Regex regex = new Regex(pattern);
            var officeStuff = new SortedDictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Match match = regex.Match(Console.ReadLine());
                string name = match.Groups[1].Value;
                string stuff = match.Groups[3].Value;
                int quentity = int.Parse(match.Groups[2].Value);

                if(!officeStuff.ContainsKey(name))
                {
                    var items = new Dictionary<string, int>();
                    items.Add(stuff,quentity);
                    officeStuff.Add(name,items);
                }
                else 
                {
                    if (!officeStuff[name].ContainsKey(stuff))
                    {                      
                        officeStuff[name].Add(stuff, quentity);
                    }
                    else
                    {
                        var newDate = officeStuff[name];
                        newDate[stuff] += quentity;
                        officeStuff[name] = newDate;                       
                    }
                }                
            }
            foreach (var company in officeStuff.Keys)
            {
                Console.Write("{0}:", company);
                var inventar = officeStuff[company];
                foreach (var stuff in inventar)
                {
                    Console.Write("{0} - {1},", stuff.Key, stuff.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
