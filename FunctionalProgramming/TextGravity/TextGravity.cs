using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TextGravity
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            List<char[]> grid = new List<char[]>();
            int index = 0;
            for (int i = 0; i <= input.Length / n; i++)
            {
                grid.Add(new char[n]);
                for (int j = 0; j < n; j++)
                {
                    try
                    {
                        grid[i][j] = input[index];
                    }
                    catch
                    {
                        grid[i][j] = ' ';
                    }

                    index++;
                }
            }

            for (int w = 0; w < grid.Count; w++)
            {
                for (int i = grid.Count - 1; i >= 1; i--)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == ' ')
                        {
                            SwapChar(ref grid[i][j], ref grid[i - 1][j]);
                        }
                    }
                }
            }
            Console.WriteLine(CreateHTML(grid));

        }

        static string CreateHTML(List<char[]> csList)
        {
            StringBuilder sb = new StringBuilder("<table>");

            foreach (char[] line in csList)
            {
                sb.Append("<tr>");
                foreach (char c in line)
                {
                    sb.Append("<td>");
                    sb.Append(c);
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }


        static void SwapChar(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
    }
}
