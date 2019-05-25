using _08.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public IReadOnlyCollection<IMission> Missions { get; }

        public Commando(string id, string firstName, string lastName, double salary, string corp, List<IMission> missions)
            : base(id, firstName, lastName, salary, corp)
        {
            Missions = missions;
        }

        public override string ToString()
        {
            var result = base.ToString() + "\nMissions:";

            foreach (var m in Missions)
            {
                result += $"\n{m}";
            }
            return result;
        }
    }
}
