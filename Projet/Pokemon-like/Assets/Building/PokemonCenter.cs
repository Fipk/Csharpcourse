using Pokemon_like.Assets.Items.Consumables.Potions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_like.Assets.Building
{
    public class PokemonCenter
    {
        public PokemonCenter() { }

        public void EnterPokemonCenter(ref Player player)
        {
            bool isInPokeCenter = true;
            while (isInPokeCenter)
            {
                Console.WriteLine("Welcome to the pokecenter");
                Console.WriteLine("1. Heal your pokemons. It will cost 50 money");
                Console.WriteLine("2. Buy 1 potion. It will cost 10 money");
                Console.WriteLine("3. Buy pokeballs");
                Console.WriteLine("4. Leave Poke Center");
                string value = Console.ReadLine();
                switch (value)
                {
                    case "1":
                        HealAllPokemons(ref player);
                        break;
                    case "2":
                        BuyPotion(ref player);
                        break;
                    case "3":
                        BuyPokeballs(ref player);
                        break;
                    case "4":
                        isInPokeCenter = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void BuyPotion(ref Player player)
        {
            if(!player.GetBag().ContainsKey("Healing Potion") && player.GetMoney() >= 10)
            {
                player.GetBag()["Healing Potion"] = 0;
                player.AddItemInBag(new HealingPotion(10, "Healing Potion",40));
            } else if (player.GetMoney() >= 10)
            {
                player.AddItemInBag(new HealingPotion(10, "Healing Potion",40));
            }


        }

        public void BuyPokeballs(ref Player player)
        {
            Console.WriteLine("1.Buy 1 Pokeball. It will cost 10 money.");
            Console.WriteLine("2.Buy 1 Superball. It will cost 50 money");
            string value = Console.ReadLine();
            switch (value)
            {
                case "1":
                    if (player.GetMoney() >= 10)
                    {
                        if (!player.GetBag().ContainsKey("PokeBall") && player.GetMoney() >= 10)
                        {
                            player.GetBag()["PokeBall"] = 0;
                            player.AddItemInBag(new HealingPotion(10, "PokeBall",40));
                        }
                        else if (player.GetMoney() >= 10)
                        {
                            player.AddItemInBag(new HealingPotion(10, "PokeBall",40));
                        }
                    }
                    else
                    {
                        Console.WriteLine("You didn't have enough money.");
                    }
                    break;
                case "2":
                    if (player.GetMoney() >= 50)
                    {
                        Console.WriteLine("A pokeball has been bought.");
                        player.AddItemInBag(new SuperBall(50, "SuperBall"));
                    }
                    else
                    {
                        Console.WriteLine("You didn't have enough money.");
                    }
                    break;
                default:
                    Console.WriteLine("We didn't understand what you want.");
                    break;
            }
            Console.WriteLine("---- END OF BUY POKEBALLS ----");
        }

        public void HealAllPokemons(ref Player player)
        {
            if (player.GetMoney() >= 50)
            {
                Console.WriteLine("Your team has been healed.");
                foreach (Pokemon pokemon in player.GetTeam())
                {
                    pokemon.SetCurrentHealth();
                }
            }
            else
            {
                Console.WriteLine("You didn't have enough money.");
            }
        }
    }
}
