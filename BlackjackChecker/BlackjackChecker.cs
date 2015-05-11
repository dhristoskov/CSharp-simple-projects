using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackChecker
{
    class Players
    {
        public string name;
        public int cardsValue;
        public int numberOfCards;

        public Players(string name, int cardsValue,int numberOfCards)
        {
            this.name = name;
            this.cardsValue = cardsValue;
            this.numberOfCards = numberOfCards;
        }
        public string Name
        {
            get { return this.name; }
        }
        public int NumberOfCards
        {
            get { return this.numberOfCards; }
        }
        public int CardsValue
        {
            get { return this.cardsValue; }
        }
    }
    class BlackjackChecker
    {
        static List<Players> allPlayers = new List<Players>();
        static bool tieCase = false;
        static bool fiveCardWinner = false;
        static int highestScore = 0;

        static void FiveCardWin()
        {
            foreach (var card in allPlayers)
            {
                int numCards = card.NumberOfCards;
                if (numCards == 5)
                {
                    if (card.CardsValue <= 21)
                    {
                        Console.WriteLine("{0} has won the game with 5 card trick", card.Name);
                        fiveCardWinner = true;
                        break;
                    }                    
                }
            }
        }

        static void CalcCardsValue()
        {
            bool gameWinner = false;
            string winner = String.Empty;
            foreach (var card in allPlayers)
            {
                int value = card.CardsValue;
                if (value < 21 || value == 21)
                {
                    if (value > highestScore)
                    {
                        highestScore = value;
                        winner = card.Name;
                        gameWinner = true;
                    }
                }
            }
            TieCase();
            if (!tieCase)
            {
                if (gameWinner)
                {
                    Console.WriteLine("{0} has won the game with {1} point", winner, highestScore);
                }
                else
                {
                    Console.WriteLine("No winner this game");
                }
            }           
        }

        static void TieCase()
        {
            int counter = 0;
            foreach (var n in allPlayers)
            {
                if (highestScore == n.CardsValue)
                {
                    counter++;
                }
            }
            if (counter > 1)
            {
                Console.WriteLine("'Tie' more then one winner");
                tieCase = true;
            }
        }

        static void Main(string[] args)
        {
            int playerNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < playerNumbers; i++)
            {
                string input = Console.ReadLine();
                string playerName = input.Split(':')[0];
                string[] playerCards = input.Split(':')[1].Split(',');
                int totalValue = 0;
                int counter = 0;
                foreach (var card in playerCards)
                {
                    counter++;
                    string cardValue = card.Split()[0];
                    switch (cardValue)
                    {
                        case "Two": totalValue += 2; break;
                        case "Three": totalValue += 3; break;
                        case "Four": totalValue += 4; break;
                        case "Five": totalValue += 5; break;
                        case "Six": totalValue += 6; break;
                        case "Seven": totalValue += 7; break;
                        case "Eight": totalValue += 8; break;
                        case "Nine": totalValue += 9; break;
                        case "Ten": totalValue += 10; break;
                        case "Jack": totalValue += 10; break;
                        case "Queen": totalValue += 10; break;
                        case "King": totalValue += 10; break;
                        case "Ace": totalValue += 11; break;
                        default: break;
                    }
                }
                allPlayers.Add(new Players(playerName, totalValue, counter));
            }

            FiveCardWin();
            if (!fiveCardWinner)
            {
                CalcCardsValue();
            }         
        }
    }
}
