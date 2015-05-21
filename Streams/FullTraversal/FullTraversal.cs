using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FullTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filenames = Directory.GetFiles("../../", ".", SearchOption.AllDirectories).ToArray();
            var dbDictionary = new SortedDictionary<string, List<string>>();

            foreach (var filename in filenames)
            {
                FileInfo name = new FileInfo(filename);
                if (dbDictionary.ContainsKey(name.Extension))
                {
                    dbDictionary[name.Extension].Add(string.Format("{0}.{1} - {2}kb", name.Name, name.Extension,
                        name.Length));
                }
                else
                {
                    dbDictionary.Add(name.Extension,
                        new List<string> { string.Format("{0}.{1} - {2}kb", name.Name, name.Extension, name.Length) });

                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter writer = new StreamWriter(path + "/results.txt"))
            {
                foreach (var list in dbDictionary.OrderByDescending(s => s.Value.Count))
                {
                    writer.WriteLine(list.Key);
                    foreach (var str in list.Value)
                    {
                        writer.WriteLine("--" + str);
                    }
                }
            }
        }
    }
}
