using System;
using System.Collections.Generic;
using System.Text;

namespace _05.PizzaCalories
{
    public class Topping
    {
        private string type;
        private decimal weight;
        private decimal caloriesPerGram;

        public decimal CaloriesPerGram
        {
            get { return caloriesPerGram; }
        }

        public decimal TotalCalories()
        {
            return CaloriesPerGram * Weight;
        }
        private string Type
        {
            get { return type; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        private decimal Weight
        {
            get { return weight; }
            set
            {
                if (value<1 || value>50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public Topping(string type, decimal weight)
        {
            this.Type = type;
            this.Weight = weight;

            decimal typeModifier = 0M;

            switch (type.ToLower())
            {
                case "meat":
                    typeModifier = 1.2M;
                    break;
                case "veggies":
                    typeModifier = 0.8M;
                    break;
                case "cheese":
                    typeModifier = 1.1M;
                    break;
                case "sauce":
                    typeModifier = 0.9M;
                    break;
                default:
                    break;
            }

            caloriesPerGram = typeModifier * 2;
        }
    }
}
