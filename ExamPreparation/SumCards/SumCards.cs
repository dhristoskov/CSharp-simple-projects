using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumCards
{
    class SumCards
    {
        static int GetCard(string s)
        {
            if (s.StartsWith("2")) { return 2; }
            if (s.StartsWith("3")) { return 3; }
            if (s.StartsWith("4")) { return 4; }
            if (s.StartsWith("5")) { return 5; }
            if (s.StartsWith("6")) { return 6; }
            if (s.StartsWith("7")) { return 7; }
            if (s.StartsWith("8")) { return 8; }
            if (s.StartsWith("9")) { return 9; }
            if (s.StartsWith("10")) { return 10; }
            if (s.StartsWith("J")) { return 12; }
            if (s.StartsWith("Q")) { return 13; }
            if (s.StartsWith("K")) { return 14; }
            else { return 15; }

        }
        static void Main(string[] args)
        {
            string[] cards = Console.ReadLine().Split();
            int sum = 0;
            int counter = 0;
            int prevValue = 0;

            foreach (var card in cards)
            {
                int value = GetCard(card);
                if (value == prevValue)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }
                sum = sum + value;
                if (counter == 2)
                {
                    sum = sum + 2 * value;
                }
                if (counter > 2)
                {
                    sum = sum + value;
                }
                prevValue = value;
            }
            Console.WriteLine(sum);
        }        
    }
}
