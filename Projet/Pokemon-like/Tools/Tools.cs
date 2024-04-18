using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pokemon_like.Program;

namespace Pokemon_like.Tools
{
    public class ToolsPokemon
    {
        public ToolsPokemon() { }


        // servir à manipuler vos données
        // manipuler vos objets

        public List<Pokemon> ReadJsonPokemons()
        {
            string json = File.ReadAllText("pokemon.json");

            List<Pokemon> pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(json);
            return pokemons;
        }

        public Pokemon GenerateAPokemon(int index)
        {
            List<Pokemon> pokemons = ReadJsonPokemons();
            return new Pokemon(pokemons[index].Stats.Attack, pokemons[index].Name, pokemons[index].Stats.HP, pokemons[index].Stats.Defense, pokemons[index].Stats.Speed, pokemons[index].Type);
        }

        public void ShowItems(ref Player player)
        {
            foreach (var item in player.GetBag())
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
        public void ShowAllPokemons(ref Player player)
        {
            foreach (var pokemon in player.GetPokemonStock())
            {
                Console.WriteLine(pokemon.GetName());
            }
        }
    }
}
