using System;
using System.Collections.Generic;
using System.Text;

namespace _08.RawData
{
    public class Car
    {
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private Engine engine = new Engine();

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        private Cargo cargo = new Cargo();

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        private Tire[] tires = new Tire[4];

        public Tire[] Tires
        {
            get { return tires; }
            set { Tires = tires; }
        }

        public Car(string model, Engine engine, Cargo cargo, Tire tire1, Tire tire2, Tire tire3, Tire tire4)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            tires[0] = tire1;
            tires[1] = tire2;
            tires[2] = tire3;
            tires[3] = tire4;
        }
    }
}
