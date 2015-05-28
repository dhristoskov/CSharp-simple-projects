using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace UncleScrooge
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string pattern = @"'(?i:coin)\s((?:\d+)(?:.?\d+)?)'";
            string input =
                "'coin 1', 'coin two', 'coin 5', 'coin 10.50', 'coin 20', 'coin 50', 'coin hundred', 'cigars 1'";

            int coins = 0;
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                double number = double.Parse(match.Groups[1].Value);
                if (number / (int)number == 1)
                {
                    coins += (int)number;
                }
            }

            Console.WriteLine("gold: {0}", coins / 100);
            coins = coins % 100;
            Console.WriteLine("silver: {0}", coins / 10);
            coins = coins % 10;
            Console.WriteLine("bronze: {0}", coins);
        }
    }
}
