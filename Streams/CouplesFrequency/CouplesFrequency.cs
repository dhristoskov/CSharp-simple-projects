using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoupleFrequance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Dictionary<string, int> couples = new Dictionary<string, int>();
            int count = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < i + 2; j++)
                {
                    string current = numbers[i] + " " + numbers[j];
                    if (couples.ContainsKey(current))
                    {
                        couples[current]++;
                        count++;
                    }
                    else
                    {
                        couples.Add(current, 1);
                        count++;
                    }
                }
            }

            foreach (var couple in couples)
            {
                Console.Write(couple.Key + " ");
                Console.WriteLine("-> {0:P}", ((double)couple.Value / count));
            }

        }
    }
}
