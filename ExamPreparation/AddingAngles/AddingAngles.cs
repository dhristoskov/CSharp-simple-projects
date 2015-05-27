using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingAngles
{
    class AddingAngles
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<int> degrees = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isFullCircle = false;

            for (int a = 0; a < degrees.Count; a++)
            {
                for (int b = a + 1; b < degrees.Count; b++)
                {
                    for (int c = b + 1; c < degrees.Count; c++)
                    {
                        if ((degrees[a] + degrees[b] + degrees[c]) % 360 == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = 360 degrees",degrees[a], degrees[b], degrees[c]);
                            isFullCircle = true;
                        }
                    }
                }
            }
            if (!isFullCircle)
            {
                Console.WriteLine("No");
            }
        }
    }
}
