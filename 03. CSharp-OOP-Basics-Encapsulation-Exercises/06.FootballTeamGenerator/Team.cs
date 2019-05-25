using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            if (!players.Any(x => x.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }

            var playerToRemove = players.FirstOrDefault(x => x.Name == playerName);
            if (playerToRemove != null) // not necessary to check, as already checked...
            {
                players.Remove(playerToRemove);
            }
        }
        public int Rating()
        {
            if (players.Count == 0)
            {
                return 0;
            }
            else
            {
                return (int)Math.Round(players.Average(x => x.Stats.Average(y => y.Value))); // cast(decimal) if needed
            }
        }


        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }
    }
}
