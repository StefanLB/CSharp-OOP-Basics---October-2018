using System;
using System.Collections.Generic;
using System.Text;

namespace _08.RawData
{
    public class Tire
    {
        private int tireAge;

        public int TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }

        private double tirePressure;

        public double TirePressure
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }

        public Tire(double tirePressure, int tireAge)
        {
            TirePressure = tirePressure;
            TireAge = tireAge;
        }

    }
}
