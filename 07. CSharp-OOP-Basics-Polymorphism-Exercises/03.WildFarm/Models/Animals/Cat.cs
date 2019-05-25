using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double GAINED_WEIGHT_PER_PC = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(Food food)
        {
            if (food.Type != "Vegetable" && food.Type != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.Type}!");
            }
            this.Weight += food.Quantity * GAINED_WEIGHT_PER_PC;
            this.FoodEaten += food.Quantity;
        }
    }
}
