using System;
using System.Linq;

public class ItVillage
{
    public static void Main()
    {
        string[] boardLayout = Console.ReadLine()
            .Split(new[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] startPosition = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int[] moves = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        string[] board = new string[12];

        board[0] = boardLayout[0];
        board[1] = boardLayout[1];
        board[2] = boardLayout[2];
        board[3] = boardLayout[3];
        board[4] = boardLayout[7];
        board[5] = boardLayout[11];
        board[6] = boardLayout[15];
        board[7] = boardLayout[14];
        board[8] = boardLayout[13];
        board[9] = boardLayout[12];
        board[10] = boardLayout[8];
        board[11] = boardLayout[4];

        int startIndex;

        switch (startPosition[0] - 1)
        {
            case 0:
                startIndex = startPosition[1] - 1;
                break;
            case 1:
                startIndex = startPosition[1] - 1 == 0 ? 11 : 4;
                break;
            case 2:
                startIndex = startPosition[1] - 1 == 0 ? 9 : 5;
                break;
            default:
                startIndex = (10 - startPosition[1]);
                break;
        }

        int money = 50;
        int innsOwned = 0;
        int totalInns = boardLayout.Count(x => x == "I");
        int nextIndex = startIndex;

        for (int i = 0; i < moves.Length; i++)
        {
            money += 20 * innsOwned;

            nextIndex = (nextIndex + moves[i]) % 12;

            string currentLocation = board[nextIndex];

            switch (currentLocation)
            {
                case "P":
                    money -= 5;
                    break;
                case "I":
                    if (money >= 100)
                    {
                        money -= 100;
                        innsOwned++;
                    }
                    else
                    {
                        money -= 10;
                    }
                    break;
                case "F":
                    money += 20;
                    break;
                case "S":
                    i += 2;
                    break;
                case "V":
                    money *= 10;
                    break;
                case "N":
                    Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                    return;
            }

            if (innsOwned == totalInns)
            {
                Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>", money);
                return;
            }

            if (money < 0)
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
                return;
            }
        }

        Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>", money);
    }
}