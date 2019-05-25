using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animals
{
    class Tiger : Feline
    {
        private const double GAINED_WEIGHT_PER_PC = 1;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
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
