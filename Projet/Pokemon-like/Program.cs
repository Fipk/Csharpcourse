using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_like
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Refacto
            // TODO Pokeball, Hyperball, SuperBall qui hérite de item
            // Potions pour soigner ses pokemons
            // TODO Pouvoir capturer des pokemons durant le combat lorsqu'ils au moins de 50% de leur vie
            // Possibilité de rencontrer un dresseur qui lui aussi a une équipe de pokemon
            // Quand vous êtes en combat pouvoir échanger de pokemon
            // Dans le menu pouvoir enlever et ajouter des pokemons dans son équipe

            // s'il vous reste du temps
            // TODO Faire une map ou vous pouvez vous baladez et donc 30% de tomber sur un pokemon
            // TODO Vous pouvez faire une arene
            // TODO Vous pouvez faire les évolutions des pokemons

            GameInstance gameInstance = new GameInstance();    
        }

        public class GameInstance
        {
            private Player player = new Player("calvin",10);
            public GameInstance ()
            {
                ReadJsonPokemons();
                GameLoop();  
            }

            public void GameLoop()
            {
                Start();
                Console.WriteLine("Welcome back " + player.GetName());

                while (true)
                {

                    //Console.Clear();
                    Console.WriteLine("What do you want to do " + player.GetName() + " ?");
                    //Console.WriteLine("You have " + money + " money left.");
                    Console.WriteLine("1. Battle with a random pokemon");
                    Console.WriteLine("2. Go to the pokestore");
                    Console.WriteLine("3. Show my items");
                    Console.WriteLine("4. Show all my pokemon");
                    Console.WriteLine("5. Leave the game");

                    string value = Console.ReadLine();
                    switch (value)
                    {
                        case "1":
                            Console.WriteLine("Battle"); 
                            Battle();
                            // Si vos pokemons ont 0 vie impossible
                            break;
                        case "2":
                            Console.WriteLine("In the pokecenter"); // TODO
                            PokemonCenter();
                            break;
                        case "3":
                            ShowItems();
                            break;
                        case "4":
                            ShowAllPokemons();
                            break;
                        case "5":
                            Console.WriteLine("Leave the game"); // TODO
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("---- END OF LOOP DECISION ----");
                }
            }
            public void ShowAllPokemons()
            {
                foreach(var pokemon in player.GetPokemonStock())
                {
                    Console.WriteLine(pokemon.GetName());
                }
            }

            public void Start()
            {
                Console.WriteLine("Hello user, welcome to the pokemon-like");
                Console.WriteLine("Enter your username before the game starts");

                string username = Console.ReadLine();
                player.SetName(username);
                Console.Clear();
                StarterChoice();
            }

            public void StarterChoice()
            {
                Console.WriteLine("What do you want to choose has a starter ?");
                Console.Write("1. ");
                GenerateAPokemon(0).Display();
                Console.Write("2. ");
                GenerateAPokemon(3).Display();
                Console.Write("3. ");
                GenerateAPokemon(6).Display();

                string value = Console.ReadLine();
                switch (value)
                {
                    case "1":
                        player.AddPokemonInTeam(GenerateAPokemon(0));
                        break;
                    case "2":
                        player.AddPokemonInTeam(GenerateAPokemon(3));
                        break;
                    case "3":
                        player.AddPokemonInTeam(GenerateAPokemon(6));
                        break;
                    default:
                        player.AddPokemonInTeam(GenerateAPokemon(0));
                        break;
                }
            }

            public void Battle()
            {

                bool isInCombat = true;
                Random random = new Random();
                int rnd = random.Next(0, 10);
                Pokemon encounteredPokemon = GenerateAPokemon(rnd);
                encounteredPokemon.SetCurrentHealth();
                while (isInCombat)
                {
                    Console.WriteLine(isInCombat);
                    Console.WriteLine("My pokemon is " + player.GetTeam()[0].GetName() + " and it has " + player.GetTeam()[0].GetCurrentHealth() + " health left.");
                    Console.WriteLine("The pokemon encountered is " + encounteredPokemon.GetName() + " and it has " + encounteredPokemon.GetCurrentHealth() + " health left.");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Flee");
                    Console.WriteLine("3. Catch");
                    string value = Console.ReadLine();
                    switch (value)
                    {
                        case "1":
                            Console.WriteLine("Attack");
                            isInCombat = Attack(player.GetTeam()[0], encounteredPokemon, player.GetMoney());
                            break;
                        case "2":
                            Console.WriteLine("Flee");
                            isInCombat = TryToFlee();
                            break;
                        case "3":
                            if (player.CheckIfHasPokeball()) 
                            { 
                                for (int i = 0; i < player.GetBag().Count; i++)
                                {
                                    if (player.GetBag()[i].GetName() == "PokeBall")
                                    {
                                        PokeBall ball = (PokeBall)player.GetBag()[i];
                                        ball.Catch(encounteredPokemon,ref player);
                                        player.RemoveItemInBag();
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("*** END OF YOUR TURN ***");
                    if (isInCombat)
                    {
                        isInCombat = EnemyTurn(player.GetTeam()[0], encounteredPokemon);
                    }
                    Console.WriteLine("*** END OF ENEMY TURN ***");
                }


            }

            public bool EnemyTurn(Pokemon playerPokemon, Pokemon encounteredPokemon)
            {
                if (playerPokemon.RemoveHealth(encounteredPokemon.GetDamage()))
                {
                    Console.WriteLine("You lost the fight");
                    return false;
                }
                return true;
            }

            public bool Attack(Pokemon playerPokemon, Pokemon encounteredPokemon, int money)
            {

                if (encounteredPokemon.RemoveHealth(playerPokemon.GetDamage()))
                {
                    Console.WriteLine("You won the fight and you gain 5 money.");
                    money += 5;
                    return false;
                }
                return true;
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

            public void ShowItems()
            {
                foreach(var item in player.GetBag())
                {
                    Console.WriteLine(item.GetName());
                }
            }


            public void PokemonCenter()
            {
                bool isInPokeCenter = true;
                while (isInPokeCenter)
                {
                    Console.WriteLine("Welcome to the pokecenter");
                    Console.WriteLine("1. Heal your pokemons. It will cost 50 money");
                    Console.WriteLine("2. Buy pokeballs");
                    Console.WriteLine("3. Leave Poke Center");
                    string value = Console.ReadLine();
                    switch (value)
                    {
                        case "1":
                            HealAllPokemons();
                            break;
                        case "2":
                            BuyPokeballs();
                            break;
                        case "3":
                            isInPokeCenter = false; 
                            break;
                        default:
                            break;
                    }
                }
            }

            public void BuyPokeballs() 
            {
                Console.WriteLine("1.Buy 1 Pokeball. It will cost 10 money.");
                Console.WriteLine("2.Buy 1 Superball. It will cost 50 money");
                string value = Console.ReadLine();
                switch (value)
                {
                    case "1":
                        if (player.GetMoney() >= 10)
                        {
                            Console.WriteLine("A pokeball has been bought.");
                            player.AddItemInBag(new PokeBall(10, "PokeBall"));
                        } else
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

            public void HealAllPokemons()
            {
                if (player.GetMoney() >= 50)
                {
                    Console.WriteLine("Your team has been healed.");
                    foreach (Pokemon pokemon in player.GetTeam())
                    {
                        pokemon.SetCurrentHealth();
                    }
                } else
                {
                    Console.WriteLine("You didn't have enough money.");
                }
            }

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
           
        }

        public class Dresseur
        {
            protected List<Pokemon> team = new List<Pokemon>();
            protected List<Item> bag = new List<Item>();

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
            public List<Pokemon> GetTeam() { return team; }

            public void SetBag(List<Item> m_bag) { this.bag = m_bag; }
            public List<Item> GetBag() { return bag; }

            public void AddPokemonInTeam(Pokemon pokemonToAdd)
            {
                if (team.Count > 4)
                {
                    Console.WriteLine("Impossible to add to the team.");
                } else
                {
                    Console.WriteLine("Your pokemon " + pokemonToAdd.GetName() + " is added in your team.");
                    team.Add(pokemonToAdd);
                }
            }

            public void RemovePokemonInTeam() { }

            public void AddItemInBag(Item itemToAdd)
            {
                Console.WriteLine("Your item " + itemToAdd.GetName() + " is added in your bag.");
                bag.Add(itemToAdd);
            }

            public void RemoveItemInBag() 
            {
                Console.WriteLine("Remove item in bag");
            }
        }

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

            public bool CheckIfHasPokeball()
            {
                foreach(var item in bag)
                {
                    if (item.GetName() == "PokeBall")
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public class Enemy : Dresseur
        {
            public Enemy(string name) : base(name)
            {
            }
        }

        public class Item
        {
            private string name;
            private int price;
            public Item(int m_price, string m_name)
            {
                this.price = m_price;
                this.name = m_name;
            }
            
            public string GetName() { return name; }
            public int GetPrice() { return price; }

            public void SetName(string m_name) { this.name = m_name; }
            public void SetPrice(int m_price) {  this.price = m_price; }
        }

        interface IBall
        {
            void Catch(Pokemon pokemon, ref Player player);
        }

        public class PokeBall : Item, IBall
        {
            public PokeBall(int m_price, string m_name) : base(m_price, m_name)
            {
            }

            public void Catch(Pokemon pokemon, ref Player player)
            {
                Random random = new Random();
                int rnd = random.Next(1, 6);
                if (rnd == 1)
                {
                    Console.WriteLine("You succeeded to catch " + pokemon.GetName());
                    player.AddPokemonInStock(pokemon);
                } else
                {
                    Console.WriteLine("You failed.");
                }
                Console.WriteLine("---- END OF CATCH ----");
            }
        }
        public class SuperBall : Item, IBall
        {
            public SuperBall(int m_price, string m_name) : base(m_price, m_name)
            {
            }

            public void Catch(Pokemon pokemon, ref Player player)
            {
                Random random = new Random();
                int rnd = random.Next(1, 4);
                if (rnd == 1)
                {
                    player.AddPokemonInStock(pokemon);
                }
            }
        }


        public class Stats
        {
            public int HP;
            public int Attack;
            public int Defense;
            public int Speed;
        }

        public class Pokemon
        {
            private int damage;
            private int currentHealth;
            private int maxHealth;
            private int speed;
            private int defense;

            // Lecture JSON
            public string Name;
            public List<string> Type;
            public Stats Stats;
            public Pokemon(int m_damage, string m_name, int m_maxHealth, int m_defense, int m_speed,List<string> m_type) 
            {
                this.damage = m_damage;
                this.Name = m_name;
                this.maxHealth = m_maxHealth;
                this.currentHealth = m_maxHealth;
                this.defense = m_defense;
                this.speed = m_speed;
                this.Type = m_type;
            }

            public bool RemoveHealth(int m_damage)
            {
                if (m_damage > defense)
                {
                    currentHealth = currentHealth - (m_damage - defense);
                }else
                {
                    currentHealth--;
                }
                if (currentHealth <= 0)
                {
                    return true;
                }
                return false;
                
            }

            

            public void Display()
            {
                Console.Write("The pokemon is " + Name + ". It has " + damage + " attack, " + defense + " defense, "+ speed + " speed " + "and he has ");
                foreach(var item in Type)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }

            public void SetCurrentHealth() { this.currentHealth = this.maxHealth; }

            public string GetName() {  return Name; }
            public int GetCurrentHealth() { return currentHealth; }
            public int GetMaxHealth() {  return maxHealth; }

            public int GetDamage() { return damage; }

        }
    }
}
