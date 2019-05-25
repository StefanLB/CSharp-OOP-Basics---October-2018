using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private Chip chip;
        private DentalCare dentalCare;
        private Fitness fitness;
        private NailTrim nailTrim;
        private Play play;
        private Vaccinate vaccinate;
        public Dictionary<string,List<IAnimal>> adoptedAnimals;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.chip = new Chip();
            this.dentalCare = new DentalCare();
            this.fitness = new Fitness();
            this.nailTrim = new NailTrim();
            this.play = new Play();
            this.vaccinate = new Vaccinate();
            this.adoptedAnimals = new Dictionary<string, List<IAnimal>>();

        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Animal animal;

            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    hotel.Accommodate(animal);
                    return $"Animal {name} registered successfully";
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    hotel.Accommodate(animal);
                    return $"Animal {name} registered successfully";
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    hotel.Accommodate(animal);
                    return $"Animal {name} registered successfully";
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    hotel.Accommodate(animal);
                    return $"Animal {name} registered successfully";
                default:
                    throw new InvalidOperationException();
            }
        }

        public string Chip(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal currentAnimal = hotel.Animals[name];
            chip.DoService(currentAnimal, procedureTime);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal currentAnimal = hotel.Animals[name];
            vaccinate.DoService(currentAnimal, procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal currentAnimal = hotel.Animals[name];
            fitness.DoService(currentAnimal, procedureTime);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal currentAnimal = hotel.Animals[name];
            play.DoService(currentAnimal, procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal currentAnimal = hotel.Animals[name];
            dentalCare.DoService(currentAnimal, procedureTime);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal currentAnimal = hotel.Animals[name];
            nailTrim.DoService(currentAnimal, procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!AnimalExists(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal currentAnimal = hotel.Animals[animalName];
            if (!adoptedAnimals.ContainsKey(owner))
            {
                adoptedAnimals.Add(owner, new List<IAnimal>());
            }
            adoptedAnimals[owner].Add(currentAnimal);  // If this doesnt work, try to only use one list, filtered by "ISADOPTED", ***will have to configure the AnimalExists method

            hotel.Adopt(animalName, owner);

            if (currentAnimal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            string result;

            switch (type)
            {
                case "Chip":
                    result = chip.History();
                    break;
                case "DentalCare":
                    result = dentalCare.History();
                    break;
                case "Fitness":
                    result = fitness.History();
                    break;
                case "NailTrim":
                    result = nailTrim.History();
                    break;
                case "Play":
                    result = play.History();
                    break;
                case "Vaccinate":
                    result = vaccinate.History();
                    break;
                default:
                    throw new InvalidOperationException();
                    //result = null;
                    //break;
            }

            return result;
        }

        private bool AnimalExists(string animalName)
        {
            if (hotel.Animals.ContainsKey(animalName))
            {
                return true;
            }
            return false;
        }
    }
}
