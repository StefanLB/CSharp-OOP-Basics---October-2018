using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private const int MAX_CAPACITY = 10;
        private IDictionary<string, IAnimal> animals;

        public int Capacity => MAX_CAPACITY;

        public IReadOnlyDictionary<string,IAnimal> Animals
        {
            get { return (IReadOnlyDictionary<string,IAnimal>)animals; }
        }

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public void Accommodate(IAnimal animal)
        {
            int occupiedCapacity = animals.Count;
            if (occupiedCapacity>=Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            bool animalAlreadyInHotel = animals.Any(y => y.Key == animal.Name);

            if (animalAlreadyInHotel)
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            bool animalInHotel = animals.Any(y => y.Key == animalName);

            if (!animalInHotel)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = animals.FirstOrDefault(x => x.Key == animalName).Value;

            animal.IsAdopt = true;
            animal.Owner = owner;

            animals.Remove(animal.Name);
        }


    }
}
