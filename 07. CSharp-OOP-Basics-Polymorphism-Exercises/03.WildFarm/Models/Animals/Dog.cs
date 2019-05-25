using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double GAINED_WEIGHT_PER_PC = 0.4;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
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
