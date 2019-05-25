using _08.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public IReadOnlyCollection<IRepair> Repairs { get; }

        public Engineer(string id, string firstName, string lastName, double salary, string corp, List<IRepair> repairs)
            : base(id, firstName, lastName, salary,corp)
        {
            Repairs = repairs;
        }

        public override string ToString()
        {
            var result = base.ToString() + "\nRepairs:";

            foreach (var r in Repairs)
            {
                result += $"\n{r}";
            }
            return result;
        }
    }
}
