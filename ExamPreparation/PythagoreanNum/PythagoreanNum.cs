using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythagoreanNum
{
    class PythagoreanNum_10
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            int[] nums = new int[inputNum];
            bool isResult = false;

            for (int a = 0; a < inputNum; a++)
            {
                nums[a] = int.Parse(Console.ReadLine());
            }
            List<int> squares = nums.Select(x => x * x).ToList();

            foreach (int num in squares)
            {
                foreach (int num2 in squares)
                {
                    int sqrtC = num + num2;
                    if (num2 >= num && squares.Contains(sqrtC))
                    {
                        int num1 = (int)Math.Sqrt(num);
                        int _num2 = (int)Math.Sqrt(num2);
                        int num3 = (int)Math.Sqrt(sqrtC);
                        Console.WriteLine("{0}*{0}+{1}*{1}={2}*{2}", num1, _num2, num3);
                        isResult = true;
                    }
                }
            }
            if (!isResult)
            {
                Console.WriteLine("No");
            }
        }
    }
}
