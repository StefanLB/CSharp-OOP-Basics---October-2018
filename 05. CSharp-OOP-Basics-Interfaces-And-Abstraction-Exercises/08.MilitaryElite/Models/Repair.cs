using _08.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public string PartName { get; }
        public int Hours { get; }
        public Repair(string partName, int hours)
        {
            PartName = partName;
            Hours = hours;
        }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {Hours}";
        }
    }
}
