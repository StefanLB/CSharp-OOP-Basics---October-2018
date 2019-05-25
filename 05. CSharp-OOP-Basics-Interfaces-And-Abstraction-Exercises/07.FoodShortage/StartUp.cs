using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            AddPeople(numberOfPeople, citizens,rebels);

            string command = string.Empty;

            while ((command = Console.ReadLine())!= "End")
            {
                BuyFood(citizens, rebels, command);
            }

            int totalFoodBought = citizens.Sum(x => x.Food) + rebels.Sum(x=>x.Food);
            Console.WriteLine(totalFoodBought);
        }

        private static void BuyFood(List<Citizen> citizens, List<Rebel> rebels, string command)
        {
            string buyer = command;

            if (citizens.Any(x => x.Name == buyer))
            {
                citizens.Where(x => x.Name == buyer).FirstOrDefault().BuyFood();
            }
            else if (rebels.Any(x => x.Name == buyer))
            {
                rebels.Where(x => x.Name == buyer).FirstOrDefault().BuyFood();
            }
        }

        private static void AddPeople(int numberOfPeople, List<Citizen> citizens,List<Rebel> rebels)
        {
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    citizens.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
                else if (tokens.Length == 3)
                {
                    rebels.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
            }
        }
    }
}
