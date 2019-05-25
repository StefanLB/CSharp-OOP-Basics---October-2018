using System;
using System.Collections.Generic;
using System.Text;

namespace _05.PizzaCalories
{
    public class Pizza
    {
        private const int minNameLength = 1;
        private const int maxNameLength = 15;

        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > maxNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between 1 and {maxNameLength} symbols.");
                }
                name = value;
            }
        }

        public int NumberOfToppings()
        {
            return toppings.Count;
        }

        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings() >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public decimal TotalCalories()
        {
            decimal totalCalories = 0M;

            totalCalories += dough.TotalCalories();

            foreach (Topping topp in toppings)
            {
                totalCalories += topp.TotalCalories();
            }
            return totalCalories;
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories():f2} Calories.";
        }
    }
}
