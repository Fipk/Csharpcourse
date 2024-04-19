using Newtonsoft.Json;
using Pokemon_like.Assets.Building;
using Pokemon_like.Assets.Items.Consumables.Potions;
using Pokemon_like.Core;
using Pokemon_like.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pokemon_like.Program;

namespace Pokemon_like
{
    public class GameInstance
    {

        #region Attributes

        private Player player = new Player("calvin", 500);
        private PokemonCenter pokemonCenter = new PokemonCenter();
        private ToolsPokemon tools = new ToolsPokemon();
        public bool isInCombat;
        public Pokemon encounteredPokemon;

        #endregion

        #region Singleton

        private static GameInstance instance;
        private GameInstance()
        {
            GameLoop();
        }

        public static GameInstance GetInstance()
        {
            if (instance == null)
            {
                return new GameInstance();
            }
            return instance;
        }
        #endregion

        public Player GetPlayer() { return player; }
        public void GameLoop()
        {
            Start();
            List<string> types = new List<string>();
            types.Add("Normal");

            player.AddPokemonInTeam(new Pokemon(50000, "Ronflex", 10000, 100, 120, types));
            player.AddPokemonInTeam(new Pokemon(50, "Ronflex2", 5000, 100, 120, types));
            player.AddPokemonInTeam(new Pokemon(50, "Ronflex3", 0, 100, 120, types));
            player.AddPokemonInTeam(new Pokemon(50, "Ronflex4", 300, 100, 120, types));

            Console.WriteLine("Welcome back " + player.GetName());
            /*while (true)
            {
                switch ("")
                {
                    case "1":
                        Battle();
                        // Si vos pokemons ont 0 vie impossible
                        break;
                    case "2":
                        MeetATrainer();

                        // Si vos pokemons ont 0 vie impossible
                        break;
                    case "3":
                        pokemonCenter.EnterPokemonCenter(ref player);

                        break;
                    case "4":
                        tools.ShowItems(ref player);

                        break;
                    case "5":
                        tools.ShowAllPokemons(ref player);

                        break;
                    case "6":
                        Console.WriteLine("Leave the game"); // TODO

                        break;
                    default:
                        Console.WriteLine("Leave the game");

                        break;
                }

                Console.WriteLine("---- END OF LOOP DECISION ----");
            }*/
        }

        public void MeetATrainer()
        {
            Enemy enemy = new Enemy("Rocket");
            Random random = new Random();
            int rnd = random.Next(0, 10);

            enemy.AddPokemonInTeam(tools.GenerateAPokemon(rnd));
            int rnd2 = random.Next(0, 10);
            enemy.AddPokemonInTeam(tools.GenerateAPokemon(rnd2));
            int rnd3 = random.Next(0, 10);
            enemy.AddPokemonInTeam(tools.GenerateAPokemon(rnd3));
            int rnd4 = random.Next(0, 10);
            enemy.AddPokemonInTeam(tools.GenerateAPokemon(rnd4));

            Pokemon pokemonEnemy = enemy.GetTeam()[0];
            Console.WriteLine("Vous avez rencontre " + enemy.GetName());
            Console.WriteLine("Le combat commence son " + pokemonEnemy.GetName() + " rentre en combat");

            // Revoir la methode battle
            
        }

        public void Start()
        {
            Console.WriteLine("Hello user, welcome to the pokemon-like");
            Console.WriteLine("Enter your username before the game starts");

            string username = "";
            player.SetName(username);
            //Console.Clear();
            StarterChoice();
        }

        public void StarterChoice()
        {
            Console.WriteLine("What do you want to choose has a starter ?");
            Console.Write("1. ");
            tools.GenerateAPokemon(0).Display();
            Console.Write("2. ");
            tools.GenerateAPokemon(3).Display();
            Console.Write("3. ");
            tools.GenerateAPokemon(6).Display();

            string value = "";
            switch (value)
            {
                case "1":
                    player.AddPokemonInTeam(tools.GenerateAPokemon(0));
                    break;
                case "2":
                    player.AddPokemonInTeam(tools.GenerateAPokemon(3));
                    break;
                case "3":
                    player.AddPokemonInTeam(tools.GenerateAPokemon(6));
                    break;
                default:
                    player.AddPokemonInTeam(tools.GenerateAPokemon(0));
                    break;
            }
        }

        public Pokemon GenerateRandomPokemon()
        {
            Random random = new Random();
            int rnd = random.Next(0, 10);
            Pokemon encounteredPokemon = tools.GenerateAPokemon(rnd);
            encounteredPokemon.SetCurrentHealth();
            return encounteredPokemon;
        }

        public void Battle()
        {
            Console.Clear();
            isInCombat = true;
            Pokemon pokemonPlayer = player.GetTeam()[0];
            /*while (isInCombat)
            {
                Console.WriteLine("My pokemon is " + pokemonPlayer.GetName() + " and it has " + pokemonPlayer.GetCurrentHealth() + " health left.");
                Console.WriteLine("The pokemon encountered is " + encounteredPokemon.GetName() + " and it has " + encounteredPokemon.GetCurrentHealth() + " health left.");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Flee");
                Console.WriteLine("3. Catch");
                Console.WriteLine("4. Use a Potion of Healing");
                Console.WriteLine("5. Use a Potion of Damage");
                Console.WriteLine("6. Exchange a pokemon");
                string value = Console.ReadLine();
                switch (value)
                {
                    case "1":
                        Console.WriteLine("Attack");
                        isInCombat = Attack(ref pokemonPlayer, ref encounteredPokemon, player.GetMoney());
                        break;
                    case "2":
                        Console.WriteLine("Flee");
                        isInCombat = player.TryToFlee();
                        break;
                    case "3":
                        
                        if (player.CheckIfHasItem("PokeBall"))
                        {
                            PokeBall ball = new PokeBall(10, "PokeBall");
                            isInCombat = !ball.Catch(encounteredPokemon, ref player);
                            player.RemoveItemInBag("PokeBall");
                        }
                        
                        break;
                    case "4":
                        if (player.CheckIfHasItem("Healing Potion"))
                        {
                            HealingPotion potion = new HealingPotion(10, "Healing Potion", 40);
                            potion.Use(ref pokemonPlayer);
                            player.RemoveItemInBag("Healing Potion");
                        }
                        break;
                    case "5":
                        if (player.CheckIfHasItem("Damage Potion"))
                        {
                            DamagePotion potion = new DamagePotion(10, "Damage Potion", 20);
                            potion.Use(ref encounteredPokemon);
                            player.RemoveItemInBag("Damage Potion");
                        }
                        break;
                    case "6":
                        for (int i = 0; i < player.GetTeam().Count; i++)
                        {
                            if (player.GetTeam()[i].GetName() == pokemonPlayer.GetName() || player.GetTeam()[i].GetCurrentHealth() <= 0)
                            {
                                continue;
                            }
                           
                            
                            Console.WriteLine(i + ". " + player.GetTeam()[i].GetName() + ". He has " + player.GetTeam()[i].GetCurrentHealth() + " left.");
                        }
                        string choice = Console.ReadLine();
                        pokemonPlayer = player.GetTeam()[int.Parse(choice)];
                        break;
                    default:
                        break;
                }
                Console.WriteLine("*** END OF YOUR TURN ***");
                if (isInCombat)
                {
                    Console.WriteLine(encounteredPokemon.GetName() + " has attack.");
                    isInCombat = EnemyTurn(ref pokemonPlayer, ref encounteredPokemon);
                }
                Console.WriteLine("*** END OF ENEMY TURN ***");
            }*/


        }

        public bool EnemyTurn(ref Pokemon playerPokemon, ref Pokemon encounteredPokemon)
        {
            if (playerPokemon.RemoveHealth(encounteredPokemon.GetDamage()))
            {
                Console.WriteLine("You lost the fight");
                return false;
            }
            return true;
        }

        public bool Attack(ref Pokemon playerPokemon, ref Pokemon encounteredPokemon, int money)
        {

            if (encounteredPokemon.RemoveHealth(playerPokemon.GetDamage()))
            {
                Console.WriteLine("You won the fight and you gain 5 money.");
                money += 5;
                
                return false;
            }
            
            return EnemyTurn(ref playerPokemon, ref encounteredPokemon);
        }

    }
}
