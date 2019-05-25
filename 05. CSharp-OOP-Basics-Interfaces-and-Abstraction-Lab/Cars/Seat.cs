using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;
        public string Model { get => this.model; set => model = value; }
        public string Color { get => this.color; set => color = value; }

        public string Start()
        {
            return "Car is running!";
        }

        public string Stop()
        {
            return "Car is no longer running!";
        }

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public override string ToString()
        {
            return $"{Color} {this.GetType().Name} {Model}\n{Start()}\n{Stop()}";
        }
    }
}
