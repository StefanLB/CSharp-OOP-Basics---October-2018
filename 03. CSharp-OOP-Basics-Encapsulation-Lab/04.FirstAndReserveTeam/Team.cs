using System;
using System.Collections.Generic;
using System.Text;

namespace _04.FirstAndReserveTeam
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public List<Person> ReserveTeam
        {
            get { return reserveTeam; }
        }

        public List<Person> FirstTeam
        {
            get { return firstTeam; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person player)
        {
            if (player.Age<40)
            {
                FirstTeam.Add(player);
            }
            else
            {
                ReserveTeam.Add(player);
            }
        }
    }
}
