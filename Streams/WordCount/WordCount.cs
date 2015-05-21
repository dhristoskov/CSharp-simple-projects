using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("word.txt");
            StreamReader reader2 = new StreamReader("text.txt");
            StreamWriter writer = new StreamWriter("results.txt");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            using (reader2)
            {
                string text = reader2.ReadToEnd();
                using (reader)
                {
                    while (!reader.EndOfStream)
                    {
                        string wordToMatch = reader.ReadLine();
                        string pattern = "\\b" + wordToMatch + "\\b";
                        int count = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
                        dict.Add(wordToMatch, count);
                    }
                }
            }
            using (writer)
            {
                foreach (var i in dict.OrderByDescending(s => s.Value))
                {
                    writer.WriteLine(String.Format("{0} - {1}", i.Key, i.Value));
                }
            }

        }
    }
}