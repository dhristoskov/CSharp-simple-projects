using System;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

namespace UppercaseWords
{
    class Program
    {
        static void Main()
        {
            string pattern2 = @"[A-Z]";

            string input = Console.ReadLine();
            while (input != "END")
            {
                Match m = Regex.Match(input, @"\b[0-9]?(" + pattern2 + @"+)[0-9]?\b");
                while (m.Success)
                {
                    if (string.Join("", m.Groups[1].Value.Reverse()) == m.Groups[1].Value)
                    {
                        string change = m.Groups[1].Value.Select(s => s.ToString() + s.ToString()).Aggregate((a, b) => a + b);
                        input = Regex.Replace(input, @"\b[0-9]?(" + m.Groups[1].Value + @"+)[0-9]?\b", change);
                    }
                    else
                    {
                        input = input.Replace(m.Groups[1].Value, string.Join("", m.Groups[1].Value.Reverse()));
                    }


                    m = m.NextMatch();
                }
                Console.WriteLine(SecurityElement.Escape(input));
                input = Console.ReadLine();
            }
        }
    }
}
