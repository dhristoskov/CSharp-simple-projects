using System;

class Disk
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        int centerRow = n / 2;
        int centerCol = n / 2;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                int x = col - centerCol;
                int y = row - centerRow;
                double distanceToCenter = Math.Sqrt(x * x + y * y);
                bool isWithinDisk = distanceToCenter <= r;

                if (isWithinDisk)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}
