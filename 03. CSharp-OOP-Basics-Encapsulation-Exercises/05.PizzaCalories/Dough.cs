using System;
using System.Collections.Generic;
using System.Text;

namespace _05.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private decimal weight;
        private decimal caloriesPerGram;

        public Dough(string flourType, string bakingTechnique, decimal weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;

            decimal typeModifier = 0;
            decimal techniqueModifier = 0;

            switch (FlourType.ToLower())
            {
                case "white":
                    typeModifier = 1.5M;
                    break;
                case "wholegrain":
                    typeModifier = 1.0M;
                    break;
                default:
                    break;
            }

            switch (BakingTechnique.ToLower())
            {
                case "crispy":
                    techniqueModifier = 0.9M;
                    break;
                case "chewy":
                    techniqueModifier = 1.1M;
                    break;
                case "homemade":
                    techniqueModifier = 1.0M;
                    break;
                default:
                    break;
            }

            this.caloriesPerGram = 2 * typeModifier * techniqueModifier;
        }

        public decimal CaloriesPerGram
        {
            get { return caloriesPerGram; }
        }

        public decimal TotalCalories()
        {
            return CaloriesPerGram * Weight;
        }

        private decimal Weight
        {
            get { return weight; }
            set
            {
                if (value<1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
    }
}
