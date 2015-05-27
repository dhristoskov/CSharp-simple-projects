using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozensEggs
{
    class AddingAngles
    {
        static void Main(string[] args)
        {
            int eggs = 0;
            int dozen = 0;
            int finalEggs=0;
            for (int a = 0; a < 7; a++)
            {
                string[] entry = Console.ReadLine().Split();
                int num = int.Parse(entry[0]);
                string mesure = entry[1];
                if (mesure == "eggs")
                {
                    eggs += num;
                }
                else
                {
                    eggs += num * 12;
                }
            }
            dozen = eggs / 12;
            finalEggs = eggs % 12;
            Console.WriteLine("{0} dozens + {1} eggs",dozen, finalEggs);
        }
    }
}
