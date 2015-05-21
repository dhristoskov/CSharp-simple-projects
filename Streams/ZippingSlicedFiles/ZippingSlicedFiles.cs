using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ZippingSlicedFiles
{
    class Program
    {
        static List<string> names = new List<string>();
        static void Main(string[] args)
        {
            Slice("bla.mp3", "../dir/", 5);
            Assemble(names, "newBla.mp3", "../Test/");
        }

        static void Slice(string filename, string destinationDir, int parts)
        {

            FileStream reader = new FileStream(filename, FileMode.Open);
            byte[] buffer = new byte[4096];
            Directory.CreateDirectory(destinationDir);
            long size = reader.Length / parts;
            using (reader)
            {
                for (int i = 1; i <= parts; i++)
                {
                    using (FileStream writer = new FileStream(destinationDir + i + filename + ".gz", FileMode.Create))
                    {
                        using (GZipStream gz = new GZipStream(writer, CompressionMode.Compress, false))
                        {
                            int newSize = 0;
                            int difference = 0;
                            while (true)
                            {
                                if (newSize + 4096 > size)
                                {
                                    difference = newSize + 4096 - (int)size;
                                }
                                int bytes = reader.Read(buffer, 0, buffer.Length - difference);
                                if (newSize == size || bytes == 0)
                                {
                                    break;
                                }
                                gz.Write(buffer, 0, bytes);
                                newSize += buffer.Length - difference;
                            }
                        }
                    }
                    names.Add(i + filename + ".gz");
                }
            }
        }

        static void Assemble(List<string> file, string name, string destinationDir)
        {
            Directory.CreateDirectory(destinationDir);
            FileStream write = new FileStream(destinationDir + name, FileMode.Append);

            byte[] buffer = new byte[4096];
            using (write)
            {
                for (int i = 0; i < file.Count; i++)
                {
                    using (FileStream reader = new FileStream("../dir/" + file[i], FileMode.Open))
                    {
                        using (GZipStream gz = new GZipStream(reader, CompressionMode.Decompress, false))
                        {
                            while (true)
                            {
                                int bytes = reader.Read(buffer, 0, buffer.Length);
                                if (bytes == 0)
                                {
                                    break;
                                }
                                write.Write(buffer, 0, bytes);
                            }
                        }
                    }
                }
            }
        }
    }
}
