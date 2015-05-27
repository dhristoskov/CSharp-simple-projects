using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GandalfStash
{
    class GandalfStash
    {
        static void Main(string[] args)
        {
            int moodInput = int.Parse(Console.ReadLine());
            string pattern = @"([a-zA-Z]+)";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (var s in matches)
            {
                moodInput += CheckFoodValue(s.ToString());
            }
            MoodCheck(moodInput);
        }
        static int CheckFoodValue(string x)
        {
            Console.WriteLine(x);
            switch (x.ToLower())
            {
                case "cram":
                    return 2;
                case "lembas":
                    return 3;
                case "apple":
                    return 1;
                case "melon":
                    return 1;
                case "honeycake":
                    return 5;
                case "mushrooms":
                    return -10;
                default:
                    return -1;
            }
        }
        static void MoodCheck(int x)
        {
            if (x < -5)
            {
                Console.WriteLine(x);
                Console.WriteLine("Angry");
            }
            else if (x >= -5 && x < 0)
            {
                Console.WriteLine(x);
                Console.WriteLine("Sad");
            }
            else if (x >= 0 && x < 15)
            {
                Console.WriteLine(x);
                Console.WriteLine("Happy");
            }
            else
            {
                Console.WriteLine(x);
                Console.WriteLine("Special JavaScript mood");
            }
        }
    }
}