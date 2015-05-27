using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheNumbers
{
    class TheNumbers
    {
        static string ConvertToHex(string num)
        {
            string hexValue = "0x"+int.Parse(num).ToString("X4");
            return hexValue;
        }
        static void Main(string[] args)
        {
            string pattern = @"\s*\D+\s*";
            string input = Console.ReadLine();            
            string []numbers = Regex.Split(input, pattern);            
            var hex = new List<string>();

            foreach (var num in numbers)
            {
                if (!String.IsNullOrWhiteSpace(num))
                {
                    hex.Add(ConvertToHex(num));
                }                
            }
            Console.WriteLine(String.Join("-", hex));
        }
    }
}
