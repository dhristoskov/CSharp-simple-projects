using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthDash
{
    internal class Program
    {
        private static int lifes = 3;
        private static int x = 0;
        private static int y = 0;
        private static List<char[]> labirith;
        private static string directions;
        private static int counter = 0;
        private static bool fellOf;
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            labirith = new List<char[]>();
            for (int i = 0; i < n; i++)
            {
                labirith.Add(Console.ReadLine().ToCharArray());
            }
            directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                if (lifes == 0)
                {
                    Console.WriteLine("No lifes left! Game Over!");
                    break;
                }
                if (fellOf)
                {
                    break;
                }
                Move(directions[i]);
            }
            Console.WriteLine("Total moves made: {0}", counter);

        }

        private static bool checkChar(char c)
        {
            switch (c)
            {
                case '$':
                    Console.WriteLine("Awesome!Lifes left {0}", ++lifes);
                    labirith[x][y] = '.';
                    lifes++;
                    return true;
                case '_':
                    Console.WriteLine("Bumped a wall.");
                    return false;
                case '|':
                    Console.WriteLine("Bumped a wall.");
                    return false;
                case '@':
                    if (lifes - 1 == 0)
                    {
                        lifes--;
                        return true;
                    }
                    Console.WriteLine("Ouch! That hurt! Lives left: {0}", --lifes);
                    return true;
                case '#':
                    if (lifes - 1 == 0)
                    {
                        lifes--;
                        return true;
                    }
                    Console.WriteLine("Ouch! That hurt! Lives left: {0}", --lifes);
                    return true;
                case '*':
                    if (lifes - 1 == 0)
                    {
                        lifes--;
                        return true;
                    }
                    Console.WriteLine("Ouch! That hurt! Lives left: {0}", --lifes);
                    return true;
                case ' ':
                    Console.WriteLine("Fell off a cliff! Game Over!");
                    fellOf = true;
                    counter++;
                    return false;
                case '.':
                    Console.WriteLine("Made a move!");
                    return true;
                default:
                    return false;

            }
        }

        private static void Move(char c)
        {
            try
            {
                switch (c)
                {
                    case '>':
                        if (checkChar(labirith[x][y + 1]))
                        {
                            counter++;
                            y++;
                        }
                        break;
                    case '<':
                        if (checkChar(labirith[x][y - 1]))
                        {
                            counter++;
                            y--;
                        }
                        break;
                    case 'v':
                        if (checkChar(labirith[x + 1][y]))
                        {
                            counter++;
                            x++;
                        }
                        break;
                    case '^':
                        if (checkChar(labirith[x - 1][y]))
                        {
                            counter++;
                            x--;
                        }
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fell off a cliff! Game Over!");
                fellOf = true;
                counter++;
            }
        }
    }
}
