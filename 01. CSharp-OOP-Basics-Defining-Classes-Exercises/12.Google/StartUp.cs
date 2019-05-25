using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Google
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();

            string command = string.Empty;

            while ((command = Console.ReadLine())!="End")
            {
                CheckIfPersonAdded(command, people);
                AddInfo(command, people);
            }

            command = Console.ReadLine();

            Console.WriteLine(people.Find(x=>x.Name==command).ToString());
        }

        private static void CheckIfPersonAdded(string command, List<Person> people)
        {
            string name = command.Split()[0];
            if (!people.Any(x=>x.Name==name))
            {
                people.Add(new Person(name));
            }
        }

        static void AddInfo(string command, List<Person> people)
        {
            string name = command.Split()[0];
            string action = command.Split()[1];
            switch (action)
            {
                case "company": UpdateCompany(command, people.Find(x=>x.Name==name)); break;
                case "pokemon": UpdatePokemon(command, people.Find(x => x.Name == name)); break;
                case "parents": UpdateParents(command, people.Find(x => x.Name == name)); break;
                case "children": UpdateChildren(command, people.Find(x => x.Name == name)); break;
                case "car": UpdateCar(command, people.Find(x => x.Name == name)); break;
                default: break;
            }
        }

        static void UpdateCar(string command, Person person)
        {
            //•	“<Name> car <carModel> <carSpeed>”
            string[] tokens = command.Split();
            string model = tokens[2];
            int speed = int.Parse(tokens[3]);
            Car car = new Car(model, speed);
            person.Car = car;
        }

        static void UpdateChildren(string command, Person person)
        {
            //•	“< Name > children<childName> < childBirthday >”
            string[] tokens = command.Split();
            string name = tokens[2];
            string birthday = tokens[3];
            Child child = new Child(name, birthday);
            person.Children.Add(child);
        }

        static void UpdateParents(string command, Person person)
        {
            //•	“<Name> parents <parentName> <parentBirthday>”
            string[] tokens = command.Split();
            string name = tokens[2];
            string birthday = tokens[3];
            Parent parent = new Parent(name, birthday);
            person.Parents.Add(parent);
        }

        static void UpdatePokemon(string command, Person person)
        {
            //•	“<Name> pokemon <pokemonName> <pokemonType>”
            string[] tokens = command.Split();
            string name = tokens[2];
            string type = tokens[3];
            Pokemon pokemon = new Pokemon(name, type);
            person.Pokemons.Add(pokemon);
        }

        static void UpdateCompany(string command, Person person)
        {
            //•	“<Name> company <companyName> <department> <salary>”
            string[] tokens = command.Split();
            string name = tokens[2];
            string department = tokens[3];
            decimal salary = decimal.Parse(tokens[4]);
            Company company = new Company(name, department, salary);
            person.Company = company;
        }
    }
}
