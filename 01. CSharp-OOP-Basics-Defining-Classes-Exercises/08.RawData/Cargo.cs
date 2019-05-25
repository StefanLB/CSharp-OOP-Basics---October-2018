using System;
using System.Collections.Generic;
using System.Text;

namespace _08.RawData
{
    public class Cargo
    {
        private int cargoWeight;

        public int CargoWeight
        {
            get { return cargoWeight; }
            set { cargoWeight = value; }
        }

        private string cargoType;

        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }

        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }

        public Cargo()
        {

        }
    }
}
