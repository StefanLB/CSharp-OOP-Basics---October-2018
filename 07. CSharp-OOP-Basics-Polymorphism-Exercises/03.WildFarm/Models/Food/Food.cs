using _03.WildFarm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models
{
    public abstract class Food : IFood
    {
        public int Quantity { get; protected set; }

        public string Type
        {
            get { return this.GetType().Name; }
        }

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
