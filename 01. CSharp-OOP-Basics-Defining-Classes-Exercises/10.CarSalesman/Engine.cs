using System;
using System.Collections.Generic;
using System.Text;

namespace _10.CarSalesman
{
    public class Engine
    {
        //<Model> <Power> <Displacement> <Efficiency>”. 

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        private int displacement;

        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        private string efficiency;

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }




    }
}
