using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;

namespace SimpleExpression
{
    class SimpleExpression
    {
        static void Main(string[] args)
        {           
            string input = Console.ReadLine().Replace(" ", "");
            string[] operators = Regex.Split(input, @"[0-9.]+");
            string[] numbers = Regex.Split(input, @"[^0-9.]+");
            decimal sum = decimal.Parse(numbers[0]);

            for (int i = 1; i < operators.Length; i++)
            {
                decimal num = decimal.Parse(numbers[i]);
                if(!String.IsNullOrWhiteSpace(operators[i])&&
                    !String.IsNullOrWhiteSpace(numbers[i]))
                {
                    if (operators[i] == "+")
                    {
                        sum += num;
                    }
                    else if (operators[i] == "-")
                    {
                        sum -= num;
                    }
                }              
            }
            Console.WriteLine(sum);
        }
    }
}
