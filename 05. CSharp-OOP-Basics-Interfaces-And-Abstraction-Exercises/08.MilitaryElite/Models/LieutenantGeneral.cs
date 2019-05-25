using _08.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public IReadOnlyCollection<IPrivate> Privates { get; } 
        public LieutenantGeneral(string id, string firstName,string lastName, double salary,List<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public override string ToString()
        {
            string result = base.ToString() + "\nPrivates:";
            foreach (var p in Privates)
            {
                result += $"\n{p}";
            }
            return result;
        }
    }
}
