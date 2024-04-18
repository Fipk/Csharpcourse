using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pokemon_like.Program;

namespace Pokemon_like
{
    public class Dresseur
    {
        protected List<Pokemon> team = new List<Pokemon>();
        protected Dictionary<string, int> bag = new Dictionary<string, int>();

        protected int moneyDrop;
        protected int money;
        protected string name;

        public Dresseur(string name)
        {
            this.name = name;
        }

        public void SetMoneyDrop(int m_moneyChange)
        {
            this.moneyDrop = m_moneyChange;
        }
        public int MoneyDrop()
        {
            return moneyDrop;
        }
        public void SetMoney(int m_money)
        {
            this.money = m_money;
        }
        public int GetMoney()
        {
            return money;
        }
        public void SetName(string m_name)
        {
            this.name = m_name;
        }
        public string GetName() { return name; }

        public void SetTeam(List<Pokemon> m_team) { this.team = m_team; }
        public ref List<Pokemon> GetTeam() { return ref team; }

        public void SetBag(Dictionary<string, int> m_bag) { this.bag = m_bag; }
        public Dictionary<string, int> GetBag() { return bag; }
        public int GetIndexOfBag(string key) { return bag[key]; }

        public void AddPokemonInTeam(Pokemon pokemonToAdd)
        {
            if (team.Count > 4)
            {
                Console.WriteLine("Impossible to add to the team.");
            }
            else
            {
                Console.WriteLine("Your pokemon " + pokemonToAdd.GetName() + " is added in your team.");
                team.Add(pokemonToAdd);
            }
        }

        public void RemovePokemonInTeam() { }

        public void AddItemInBag(Item itemToAdd)
        {
            Console.WriteLine("Your item " + itemToAdd.GetName() + " is added in your bag.");
           
            bag[itemToAdd.GetName()] += 1;
            
        }

        public void RemoveItemInBag(string itemToRemove)
        {
            Console.WriteLine("Remove item in bag");
            bag[itemToRemove] -= 1;
        }
    }
}
