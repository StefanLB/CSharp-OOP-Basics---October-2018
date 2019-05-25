using _03.WildFarm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animals
{
    public abstract class Bird : Animal, IBird
    {
        public double WingSize { get; protected set; }

        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
