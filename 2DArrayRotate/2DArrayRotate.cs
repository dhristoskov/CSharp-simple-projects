//http://www.reddit.com/r/dailyprogrammer/comments/29i9jw/6302014_challenge_169_easy_90_degree_2d_array/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArrayRotate
{
    class Program
    {
        static int[,] matrix;
        static int n;

        static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] +" ");
                }
                Console.WriteLine();
            }
        }
        static int[,] RotateMatrix()
        {
            int[,] newMatrix = new int[n, n];
            for (int c = 0; c < matrix.GetLength(0); c++)
            {
                for (int d = 0; d < matrix.GetLength(1); d++)
                {
                    newMatrix[c, d] = matrix[n - d - 1, c];
                }
            }
            matrix = newMatrix;
            return matrix;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number 'n' for matrix size n*n");
            n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            int counter = 1;

            for (int a = 0; a < matrix.GetLength(0); a++)
            {
                for (int b = 0; b < matrix.GetLength(1); b++)
                {
                    matrix[a, b] = counter;
                    counter++;
                }
            }
            PrintMatrix();
            Console.WriteLine();
            RotateMatrix();
            PrintMatrix();
            Console.WriteLine();
            RotateMatrix();
            PrintMatrix();
        }
    }
}
