using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<object>();

            while (true)
            {
                try
                {
                    string animalType = Console.ReadLine();
                    if (animalType == "Beast!")
                    {
                        break;
                    }

                    string[] animalParams = Console.ReadLine().Split();

                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new Dog(animalParams[0], animalParams[1], animalParams[2]);
                            animals.Add(dog);
                            break;
                        case "Cat":
                            Cat cat = new Cat(animalParams[0], animalParams[1], animalParams[2]);
                            animals.Add(cat);
                            break;
                        case "Frog":
                            Frog frog = new Frog(animalParams[0], animalParams[1], animalParams[2]);
                            animals.Add(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(animalParams[0], animalParams[1]);
                            animals.Add(kitten);
                            break;
                        case "Tomcat":

                            Tomcat tomcat = new Tomcat(animalParams[0], animalParams[1]);
                            animals.Add(tomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                    Console.WriteLine(animals.Last());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
