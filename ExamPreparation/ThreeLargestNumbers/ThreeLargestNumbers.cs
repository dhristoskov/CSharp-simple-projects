using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLargestNumbers
{
    class ThreeLargestNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<decimal> numbers = new List<decimal>();
            for (int i = 0; i < n; i++)
            {
                numbers.Add(decimal.Parse(Console.ReadLine()));
            }
            numbers.Sort();
            numbers.Reverse();
            for (int j = 0; j < numbers.Count; j++)
            {
                if (n == 1)
                {
                    Console.WriteLine(numbers[j]);
                    break;
                }
                else if (n == 2)
                {
                    Console.WriteLine(numbers[j]);
                    Console.WriteLine(numbers[j + 1]);
                    break;
                } 
                else if (n >= 3)
                {
                    Console.WriteLine(numbers[j]);
                    Console.WriteLine(numbers[j + 1]);
                    Console.WriteLine(numbers[j + 2]);
                    break;
                }
            }
        }
    }
}
