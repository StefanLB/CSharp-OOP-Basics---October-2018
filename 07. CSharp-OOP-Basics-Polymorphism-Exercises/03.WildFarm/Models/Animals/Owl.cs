using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double GAINED_WEIGHT_PER_PC = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Eat(Food food)
        {
            if (food.Type != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.Type}!");
            }
            this.Weight += food.Quantity * GAINED_WEIGHT_PER_PC;
            this.FoodEaten += food.Quantity;
        }
    }
}
