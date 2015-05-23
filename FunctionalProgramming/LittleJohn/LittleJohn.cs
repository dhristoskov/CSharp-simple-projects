using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LittleJohn
{
    class LittleJohn
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string pattern = @"(>>>----->>)|(>>----->)|(>----->)";
            Regex rg = new Regex(pattern);
            int large = 0;
            int med = 0;
            int small = 0;

            for (int i = 0; i < 4; i++)
            {
                sb.AppendFormat(" {0}", Console.ReadLine());
            }
            var arrows = rg.Matches(sb.ToString());
            foreach (Match arrow in arrows)
            {
                if (!String.IsNullOrEmpty(arrow.Groups[1].Value))
                {
                    large++;
                }
                else if (!String.IsNullOrEmpty(arrow.Groups[2].Value))
                {
                    med++;
                }
                else if (!String.IsNullOrEmpty(arrow.Groups[3].Value))
                {
                    small++;
                }
            }
            long number = long.Parse(string.Format("{0}{1}{2}", small, med, large));
            string binary = Convert.ToString(number, 2);
            string answer = binary + (string.Join("", binary.Reverse()));

            Console.WriteLine(answer);
        }
    }
}
