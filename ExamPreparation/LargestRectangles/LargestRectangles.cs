using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LargestRectangles
{
    class LargestRectangles
    {
        static void Main(string[] args)
        {
            string pattern = @"\[\s*(\d+)\s*x\s*(\d+)\s*\]";
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            MatchCollection matches = Regex.Matches(input,pattern);

            foreach (Match match in matches)
            {
                int firstNum = int.Parse(match.Groups[1].Value);
                int secondNum = int.Parse(match.Groups[2].Value);
                int result = firstNum * secondNum;
                numbers.Add(result);    
            }
            int maxSum = int.MinValue;
            for (int i = 2; i < numbers.Count; i++)
            {
                int sum = numbers[i - 2] + numbers[i - 1] + numbers[i];
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}
