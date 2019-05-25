using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,Trainer> trainers = new Dictionary<string,Trainer>();

            string command = Console.ReadLine();

            while (command != "Tournament")
            {
                //“<TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>
                string[] tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string element = tokens[2];
                double health = double.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                List<Pokemon> pokemons = trainers[trainerName].Pokemons;
                pokemons.Add(pokemon);
                trainers[trainerName].Pokemons = pokemons;

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command!="End")
            {
                string chosenElement = command;

                foreach (var trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Any(x=>x.Element==chosenElement))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        if (trainer.Pokemons.Count>0)
                        {
                            foreach (var pokemon in trainer.Pokemons)
                            {
                                pokemon.Health -= 10;
                            }
                        }
                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x=>x.Value.Badges))
            {
                Console.WriteLine(trainer.Value.ToString());
            }
        }
    }
}
