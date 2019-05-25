using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private bool isRunning;
        private AnimalCentre animalCentre;

        public Engine()
        {
            this.isRunning = true;
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string command;

            while ((command=Console.ReadLine())!="End")
            {
                string commandType = command.Split()[0];
                string[] commandArgs = command.Split().Skip(1).ToArray();

                try
                {
                    string result;

                    switch (commandType)
                    {
                        case "RegisterAnimal":
                            result = animalCentre.RegisterAnimal(commandArgs[0], commandArgs[1], 
                                int.Parse(commandArgs[2]), int.Parse(commandArgs[3]), int.Parse(commandArgs[4]));
                            break;
                        case "Chip":
                            result = animalCentre.Chip(commandArgs[0], int.Parse(commandArgs[1]));
                            break;
                        case "Vaccinate":
                            result = animalCentre.Vaccinate(commandArgs[0], int.Parse(commandArgs[1]));
                            break;
                        case "Fitness":
                            result = animalCentre.Fitness(commandArgs[0], int.Parse(commandArgs[1]));
                            break;
                        case "Play":
                            result = animalCentre.Play(commandArgs[0], int.Parse(commandArgs[1]));
                            break;
                        case "DentalCare":
                            result = animalCentre.DentalCare(commandArgs[0], int.Parse(commandArgs[1]));
                            break;
                        case "NailTrim":
                            result = animalCentre.NailTrim(commandArgs[0], int.Parse(commandArgs[1]));
                            break;
                        case "Adopt":
                            result = animalCentre.Adopt(commandArgs[0], commandArgs[1]);
                            break;
                        case "History":
                            result = animalCentre.History(commandArgs[0]);
                            break;
                        default:
                            result = null;
                            break;
                    }

                    Print(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"InvalidOperationException: {ex.Message}");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine($"ArgumentException: {ex.Message}");
                }
            }

            this.isRunning = false;

            StringBuilder sb = new StringBuilder();

            foreach (var kvp in animalCentre.adoptedAnimals.OrderBy(x=>x.Key))
            {
                sb.AppendLine($"--Owner: {kvp.Key}");

                List<string> animalNames = new List<string>();

                foreach (var animal in kvp.Value)
                {
                    animalNames.Add(animal.Name);
                }
                sb.AppendLine($"    - Adopted animals: {string.Join(" ", animalNames)}");
            }

            string finalResult = sb.ToString();
            Console.WriteLine(finalResult);
        }

        private void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
