using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladkoNotebook
{
    class VladkoNotebook
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Player> players = new Dictionary<string, Player>();
            while (input != "END")
            {
                string[] entryLine = input.Split('|');
                string color = entryLine[0];
                string opponentInfo = entryLine[1];
                string nameOrAge = entryLine[2];


                if (!players.ContainsKey(color))
                {
                    players.Add(color, new Player());
                    if (opponentInfo == "age")
                    {
                        players[color].Age = nameOrAge;
                    }
                    else if (opponentInfo == "name")
                    {
                        players[color].Name = nameOrAge;
                    }
                    else if (opponentInfo == "win")
                    {
                        players[color].Wins++;
                        if (players[color].Opponents == null)
                        {
                            players[color].Opponents = new List<string>();
                        }
                        players[color].Opponents.Add(nameOrAge);
                    }
                    else
                    {
                        if (players[color].Opponents == null)
                        {
                            players[color].Opponents = new List<string>();
                        }
                        players[color].Loses++;
                        players[color].Opponents.Add(nameOrAge);
                    }

                }
                else
                {
                    if (opponentInfo == "age")
                    {
                        players[color].Age = nameOrAge;
                    }
                    else if (opponentInfo == "name")
                    {
                        players[color].Name = nameOrAge;
                    }
                    else if (opponentInfo == "win")
                    {
                        if (players[color].Opponents == null)
                        {
                            players[color].Opponents = new List<string>();
                        }
                        players[color].Wins++;
                        players[color].Opponents.Add(nameOrAge);
                    }
                    else
                    {
                        if (players[color].Opponents == null)
                        {
                            players[color].Opponents = new List<string>();
                        }
                        players[color].Loses++;
                        players[color].Opponents.Add(nameOrAge);
                    }
                }


                input = Console.ReadLine();
            }

            var rankings = players.Select(p => p).Where(p => p.Value.Name != null && p.Value.Age != null).ToList();

            foreach (var player in rankings.OrderBy(s => s.Key))
            {
                Console.WriteLine("Color: {0}", player.Key);
                Console.WriteLine(player.Value.ToString());
            }
            if (rankings.Count == 0)
            {
                Console.WriteLine("No data recovered.");
            }
        }
    }

    class Player
    {
        public string Name;
        public string Age;
        public int Wins;
        public int Loses;
        public List<string> Opponents;

        public double CalculateRank()
        {
            return (double)(Wins + 1) / (Loses + 1);
        }
        public override string ToString()
        {
            return String.Format("-age: {1}\n-name: {0}\n-opponents: {2}\n-rank: {3:f2}", Name, Age, 
                Opponents == null ? "(empty)" : string.Join(", ", Opponents.OrderBy(s => s, StringComparer.Ordinal)), this.CalculateRank());
        }
    }
}