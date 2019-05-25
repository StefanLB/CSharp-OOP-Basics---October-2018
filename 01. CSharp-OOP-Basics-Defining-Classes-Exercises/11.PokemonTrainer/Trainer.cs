using System;
using System.Collections.Generic;
using System.Text;

namespace _11.PokemonTrainer
{
    public class Trainer
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int badges = 0;

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }

        private List<Pokemon> pokemons = new List<Pokemon>();

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        public Trainer(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
