using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClearingCommands
{
    class Program
    {
        static List<char[]> garbage = new List<char[]>();
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                garbage.Add(input.ToCharArray());
                input = Console.ReadLine();
            }

            for (int i = 0; i < garbage.Count; i++)
            {
                for (int j = 0; j < garbage[i].Length; j++)
                {
                    if (garbage[i][j] == '>' || garbage[i][j] == 'v' || garbage[i][j] == '^' || garbage[i][j] == '<')
                    {
                        try
                        {
                            int index = 1;
                            switch (garbage[i][j])
                            {
                                case '<':

                                    while (true)
                                    {
                                        if (garbage[i][j - index] == '>' || garbage[i][j - index] == 'v' || garbage[i][j - index] == '^' || garbage[i][j - index] == '<')
                                        {
                                            break;
                                        }
                                        garbage[i][j - index] = ' ';
                                        index++;
                                    }
                                    break;
                                case '>':
                                    while (true)
                                    {
                                        if (garbage[i][index + j] == '>' || garbage[i][index + j] == 'v' || garbage[i][index + j] == '^' || garbage[i][index + j] == '<')
                                        {
                                            break;
                                        }
                                        garbage[i][index + j] = ' ';
                                        index++;
                                    }
                                    break;
                                case 'v':
                                    while (true)
                                    {
                                        if (garbage[i + index][j] == '>' || garbage[i + index][j] == 'v' || garbage[i + index][j] == '^' || garbage[i + index][j] == '<')
                                        {
                                            break;
                                        }
                                        garbage[i + index][j] = ' ';
                                        index++;
                                    }
                                    break;
                                case '^':
                                    while (true)
                                    {
                                        if (garbage[i - index][j] == '>' || garbage[i - index][j] == 'v' || garbage[i - index][j] == '^' || garbage[i - index][j] == '<')
                                        {
                                            break;
                                        }
                                        garbage[i - index][j] = ' ';
                                        index++;
                                    }
                                    break;
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }

            foreach (var VARIABLE in garbage)
            {
                Console.WriteLine("<p>" + SecurityElement.Escape(new string(VARIABLE)) + "</p>");
            }
        }
    }
}
