using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double GAINED_WEIGHT_PER_PC = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(Food food)
        {
            this.Weight+=food.Quantity* GAINED_WEIGHT_PER_PC;
            this.FoodEaten += food.Quantity;
        }
    }
}
