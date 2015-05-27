using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parachute
{
    class Program
    {
        static List<char[]> field = new List<char[]>();
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int startingPos = -1;
            int startingrow = 0;
            while (input != "END")
            {
                field.Add(input.ToCharArray());
                if (startingPos == -1)
                {
                    startingPos = input.IndexOf('o');
                    if (startingPos == -1)
                    {
                        startingrow++;
                    }
                }
                input = Console.ReadLine();
            }

            for (int i = startingrow; i < field.Count - 1; i++)
            {
                if (!MoveParachuter(field[i + 1], ref startingPos))
                {
                    break;
                }
                startingrow++;
            }
            startingrow++;
            Console.WriteLine("{0} {1}", startingrow, startingPos);

        }

        static bool MoveParachuter(char[] line, ref int startpos)
        {
            int move = 0;
            foreach (char c in line)
            {
                if (c == '<')
                {
                    move--;
                }
                else if (c == '>')
                {
                    move++;
                }
            }
            switch (line[startpos + move])
            {
                case '~':
                    Console.WriteLine("Drowned in the water like a cat!");
                    startpos = startpos + move;
                    return false;
                case '_':
                    Console.WriteLine("Landed on the ground like a boss!");
                    startpos = startpos + move;
                    return false;
                case '/':
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    startpos = startpos + move;
                    return false;
                case '\\':
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    startpos = startpos + move;
                    return false;
                case '|':
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    startpos = startpos + move;
                    return false;
            }
            line[startpos] = '-';
            line[startpos + move] = 'o';
            startpos = startpos + move;
            return true;
        }
    }
}
