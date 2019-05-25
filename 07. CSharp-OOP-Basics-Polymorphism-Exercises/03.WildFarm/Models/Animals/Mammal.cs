using _03.WildFarm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        public string LivingRegion { get; protected set; }
        public Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
