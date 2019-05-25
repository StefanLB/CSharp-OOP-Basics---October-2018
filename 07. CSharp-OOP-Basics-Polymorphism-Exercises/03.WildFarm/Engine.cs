using _03.WildFarm.Models;
using _03.WildFarm.Models.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Engine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string[] animalTokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                if (animalTokens[0] == "End")
                {
                    break;
                }

                string[] foodTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


                Animal animal = GetAnimal(animalTokens);
                Food food = GetFood(foodTokens);

                animal.AskForFood();

                try
                {
                animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            animals.ForEach(a => Console.WriteLine(a.ToString()));
        }

        private Animal GetAnimal(string[] animalTokens)
        {
            string animalType = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]);

            switch (animalType)
            {
                case "Hen":
                    return new Hen(name, weight, double.Parse(animalTokens[3]));
                case "Owl":
                    return new Owl(name, weight, double.Parse(animalTokens[3]));
                case "Mouse":
                    return new Mouse(name, weight, animalTokens[3]);
                case "Dog":
                    return new Dog(name, weight, animalTokens[3]);
                case "Cat":
                    return new Cat(name, weight, animalTokens[3], animalTokens[4]);
                case "Tiger":
                    return new Tiger(name, weight, animalTokens[3], animalTokens[4]);
                default:
                    throw new ArgumentException("Damn son, what kind of animal is this?");
            }
        }

        private Food GetFood(string[] foodTokens)
        {
            string foodType = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            switch (foodType)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    throw new ArgumentException("Damn son, what kind of food is this?");
            }
        }
    }
}
