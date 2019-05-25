using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FootballTeamGenerator
{
    public class Player
    {
        private const int STAT_MIN_VALUE = 0;
        private const int STAT_MAX_VALUE = 100;

        private string name;
        private Dictionary<string,int> stats;

        public Dictionary<string,int> Stats
        {
            get { return stats; }
            private set
            {
                foreach (var stat in value)
                {
                    if (stat.Value<STAT_MIN_VALUE||stat.Value>STAT_MAX_VALUE)
                    {
                        throw new ArgumentException($"{stat.Key} should be between {STAT_MIN_VALUE} and {STAT_MAX_VALUE}.");
                    }
                }
                stats = value;
            }
        }

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

        public Player(string name, Dictionary<string,int> stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

    }
}
