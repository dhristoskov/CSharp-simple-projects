using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace SumValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input = Console.ReadLine();

            char[] startKey = input.TakeWhile(s => !Char.IsDigit(s)).ToArray();
            char[] endKey = input.Reverse().TakeWhile(s => !char.IsDigit(s)).Reverse().ToArray();

            input = Console.ReadLine();
            if (startKey.Length == 0 || endKey.Length == 0)
            {
                Console.WriteLine("<p>A key is missing</p>");
            }
            else
            {
                Results(startKey, endKey, input);
            }
        }

        static void Results(char[] startkey, char[] endkey, string text)
        {
            string pattern = new string(startkey) + @"([\d.]+)" + new string(endkey);

            Match m = Regex.Match(text, pattern);
            double? result = null;
            while (m.Success)
            {
                if (result == null)
                {
                    result = double.Parse(m.Groups[1].Value);
                }
                else
                {
                    result += double.Parse(m.Groups[1].Value);
                }

                m = m.NextMatch();
            }
            if (result != null)
            {
                Console.WriteLine("<p>The total value is: <em>{0}</em></p>", result);
            }
            else
            {
                Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            }
        }
    }
}
