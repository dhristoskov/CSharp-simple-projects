using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountBeers
{
    class CountBeers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;

            while (input != "End")
            {
                string[] entry = input.Split();
                int count = int.Parse(entry[0]);
                string measure = entry[1];
                if (measure == "beers")
                {
                    sum += count;
                }else
                {
                    sum += count * 20;
                }
                input = Console.ReadLine();
            }
            int stacks = sum / 20;
            int beers = sum % 20;
            Console.WriteLine("{0} stacks + {1} beers",stacks, beers);
        }
    }
}
