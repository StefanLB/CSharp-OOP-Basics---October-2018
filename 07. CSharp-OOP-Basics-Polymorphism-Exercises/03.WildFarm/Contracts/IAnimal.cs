using _03.WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        void AskForFood();
        void Eat(Food food);
    }
}
