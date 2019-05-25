using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public string Name { get; protected set; }
        public string FavouriteFood { get; private set; }
        public virtual string ExplainSelf()
        {
            return string.Format(
              "I am {0} and my favourite food is {1}",
              this.Name,
              this.FavouriteFood);
        }

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }
    }
}
