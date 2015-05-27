using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatrixShuffle
{
    class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            string toFill = Console.ReadLine();
            bool isEven = false;

            int position = 0;
            int count = n;
            int value = -n;
            int sum = -1;

            do
            {
                value = -1 * value / n;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    try
                    {
                        matrix[sum / n, sum % n] = toFill[position++];
                    }
                    catch (Exception)
                    {
                        matrix[sum / n, sum % n] = ' ';
                    }

                }
                value *= n;
                count--;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    try
                    {
                        matrix[sum / n, sum % n] = toFill[position++];
                    }
                    catch (Exception)
                    {
                        matrix[sum / n, sum % n] = ' ';
                    }
                }
            } while (count > 0);

            int index = 0;
            StringBuilder black = new StringBuilder();
            StringBuilder white = new StringBuilder();

            if (n % 2 == 0)
            {
                isEven = true;
            }
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {

                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {

                    if (index % 2 == 0)
                    {
                        black.Append(matrix[i, j]);
                        index++;
                    }
                    else
                    {
                        white.Append(matrix[i, j]);
                        index++;
                    }
                }
                if (isEven)
                {
                    index++;
                }

            }
            black.Append(white);
            if (isPalindrome(black.ToString()))
            {
                Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", black);
            }
            else
            {
                Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", black);
            }
        }

        static bool isPalindrome(string x)
        {
            string pattern = @"\W";
            Regex rgx = new Regex(pattern);
            x = rgx.Replace(x, "").ToLower();
            char[] y = x.Reverse().ToArray();
            if (new string(y) == x)
            {
                return true;
            }
            return false;
        }
    }
}
