using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("test.txt", Encoding.GetEncoding("Windows-1251"));

            using (reader)
            {
                int index = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (index % 2 == 0)
                    {
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    index++;
                }
            }
        }
    }
}