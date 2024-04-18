using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pokemon_like.Program;

namespace Pokemon_like
{
    public class Player : Dresseur
    {
        private List<Pokemon> pokemonStock = new List<Pokemon>();
        public Player(string name, int money) : base(name)
        {
            this.money = money;
        }

        public void AddMoney(int moneyToAdd) { this.money += moneyToAdd; }
        public void RemoveMoney(int moneyToRemove) { this.money -= moneyToRemove; }

        public List<Pokemon> GetPokemonStock() { return pokemonStock; }
        public void SetPokemonStock(List<Pokemon> m_pokemonStock) { this.pokemonStock = m_pokemonStock; }

        public void AddPokemonInStock(Pokemon pokemon)
        {
            pokemonStock.Add(pokemon);
        }

        public bool CheckIfHasItem(string itemToCheck)
        {
            foreach (var item in bag)
            {
                if (item.Key == itemToCheck && item.Value > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryToFlee()
        {
            Random random = new Random();
            int rnd = random.Next(1, 3);
            if (rnd == 1)
            {
                Console.WriteLine("You succeeded to flee");
                return true;
            }
            return false;
        }
    }
}
