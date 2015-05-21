using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader reader = new StreamReader("test.txt", Encoding.GetEncoding("windows-1251"));
                int counter = 1;
                using (reader)
                {
                    using (StreamWriter write = File.CreateText("test2.txt"))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            write.WriteLine("LINE {0}:{1}", counter, line);
                            counter++;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (IOException)
            {
                Console.WriteLine("Error");
            }           
        }
    }
}
