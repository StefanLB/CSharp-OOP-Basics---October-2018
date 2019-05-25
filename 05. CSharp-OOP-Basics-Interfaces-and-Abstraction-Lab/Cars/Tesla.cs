using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar, ICar
    {
        private int battery;
        private string model;
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Battery
        {
            get { return battery; }
            set { battery = value; }
        }

        public string Start()
        {
            return "Electric car is running!";
        }

        public string Stop()
        {
            return "Electric car is no longer running!";
        }

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public override string ToString()
        {
            return $"{Color} {this.GetType().Name} {Model} with {Battery} Batteries\n{Start()}\n{Stop()}";
        }
    }
}
