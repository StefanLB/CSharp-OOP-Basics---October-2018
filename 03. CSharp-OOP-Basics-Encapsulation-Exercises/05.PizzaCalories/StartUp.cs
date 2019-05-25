using System;
using System.Collections.Generic;

namespace _05.PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];
                string[] doughInfo = Console.ReadLine().Split();
                string doughType = doughInfo[1];
                string doughTechnique = doughInfo[2];
                decimal doughWeight = decimal.Parse(doughInfo[3]);

                Pizza pizza = new Pizza(pizzaName,new Dough(doughType, doughTechnique, doughWeight));

                string toppingInfo = Console.ReadLine();

                while (toppingInfo != "END")
                {
                    string[] toppingInfoTokens = toppingInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string type = toppingInfoTokens[1];
                    decimal weight = decimal.Parse(toppingInfoTokens[2]);
                    Topping topping = new Topping(type, weight);

                    pizza.AddTopping(topping);
                    toppingInfo = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
