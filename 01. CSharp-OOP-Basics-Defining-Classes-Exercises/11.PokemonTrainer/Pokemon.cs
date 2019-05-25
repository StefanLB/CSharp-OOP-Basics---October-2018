using System;
using System.Collections.Generic;
using System.Text;

namespace _11.PokemonTrainer
{
    public class Pokemon
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private string element;

        public string Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        private double health;

        public double Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public Pokemon(string name, string element, double health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
    }
}
