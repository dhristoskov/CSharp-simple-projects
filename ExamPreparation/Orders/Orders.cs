using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, SortedDictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int quentity = int.Parse(input[1]);
                string product = input[2];

                if (!list.ContainsKey(product))
                {
                    var buyer = new SortedDictionary<string, int>();
                    buyer.Add(name, quentity);
                    list.Add(product, buyer);
                }
                else
                {
                    if(!list[product].ContainsKey(name))
                    {
                        list[product].Add(name, quentity);
                    }
                    else
                    {
                        list[product][name] += quentity;
                    }                   
                }
            }
            foreach (var item in list)
            {
                Console.Write("{0} :", item.Key);
                foreach (var name in item.Value)
                {
                    Console.Write("{0} {1},",name.Key,name.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
