using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.Google
{
    public class Person
    {
        /*  •	“<Name> company <companyName> <department> <salary>”  
            •	“<Name> pokemon <pokemonName> <pokemonType>”
            •	“<Name> parents <parentName> <parentBirthday>”
            •	“<Name> children <childName> <childBirthday>”
            •	“<Name> car <carModel> <carSpeed>”
            */

        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private Company company;

        public Company Company
        {
            get { return this.company; }
            set { this.company = value; }
        }

        private List<Pokemon> pokemons = new List<Pokemon>();

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        private List<Parent> parents = new List<Parent>();

        public List<Parent> Parents
        {
            get { return this.parents; }
            set { this.parents = value; }
        }

        private List<Child> children = new List<Child>();

        public List<Child> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        private Car car;

        public Car Car
        {
            get { return this.car; }
            set { this.car = value; }
        }

        public Person(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return  $"{this.Name}" +
                    $"\nCompany: {this.Company}" +
                    $"\nCar:{this.Car}" +
                    $"\nPokemon:{string.Join("", this.Pokemons.Select(p => "\n" + p.Name + " " + p.Type))}" +
                    $"\nParents:{string.Join("", this.Parents.Select(p => "\n" + p.Name + " " + p.Birthday))}" +
                    $"\nChildren:{string.Join("", this.Children.Select(p => "\n" + p.Name + " " + p.Birthday))}";
        }
    }
}
