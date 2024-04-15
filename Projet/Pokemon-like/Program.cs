using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_like
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO Pokecenter (soigner les pokemons, on peut acheter des objets)
            // TODO Class Player, Enemy qui hérite dresseur
            // TODO Dresseur: money, son équipe de pokemons, inventeur de type item
            // TODO Retravailler la class Pokemon pour que chaque pokemon est au moins deux types d'attaques
            // TODO Laisser le choix au joueur de choisir quel attaque faire


            // S'il vous reste du temps
            // TODO Pokeball, Hyperball, SuperBall qui hérite de item
            // TODO Pouvoir capturer des pokemons durant le combat lorsqu'ils au moins de 50% de leur vie
            // TODO Faire une map ou vous pouvez vous baladez et donc 30% de tomber sur un pokemon
            // TODO Vous pouvez faire une arene
            // TODO Vous pouvez faire les évolutions des pokemons

            int money = 10;

            Console.WriteLine("Hello user, welcome to the pokemon-like");
            Console.WriteLine("Enter your username before the game starts");

            string username = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Welcome back " + username);

            // Exemple d'instanciation pokemon
            Pokemon carapuce = new Pokemon(5, "Carapuce", 20);
            Pokemon ratata = new Pokemon(2, "Ratata", 10);
            

            while (true)
            {
                
                //Console.Clear();
                Console.WriteLine("What do you want to do " + username + " ?");
                Console.WriteLine("You have " + money + " money left.");
                Console.WriteLine("1. Battle with a random pokemon");
                Console.WriteLine("2. Go to the pokestore");
                Console.WriteLine("3. Leave the game");

                string value = Console.ReadLine();
                switch (value)
                {
                    case "1":
                        Console.WriteLine("Battle"); // TODO
                        Battle(carapuce, ratata, money);
                        // Si vos pokemons ont 0 vie impossible
                        break;
                    case "2":
                        Console.WriteLine("In the pokestore"); // TODO
                        // toujours check si on l'argent
                        break;
                    case "3":
                        Console.WriteLine("Go to the center pokemon"); // TODO
                        // toujours check si on l'argent
                        break;
                    case "4":
                        Console.WriteLine("Leave the game"); // TODO
                        break;
                    default:
                        break;
                }
                Console.WriteLine("---- END OF LOOP DECISION ----");
            }
        }

        public static void Battle(Pokemon playerPokemon, Pokemon encounteredPokemon, int money)
        {
            
            bool isInCombat = true;
            encounteredPokemon.currentHealth = encounteredPokemon.maxHealth;
            while(isInCombat)
            {
                Console.WriteLine(isInCombat);
                Console.WriteLine("My pokemon is " + playerPokemon.name + " and it has " + playerPokemon.currentHealth + " health left.");
                Console.WriteLine("The pokemon encountered is " + encounteredPokemon.name + " and it has " + encounteredPokemon.currentHealth + " health left.");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Flee");
                string value = Console.ReadLine();
                switch (value)
                {
                    case "1":
                        Console.WriteLine("Attack");
                        isInCombat = Attack(playerPokemon, encounteredPokemon, money);
                       
                        break;
                    case "2":
                        Console.WriteLine("Flee");
                        isInCombat = TryToFlee();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("*** END OF YOUR TURN ***");
                if (isInCombat)
                {
                    isInCombat = EnemyTurn(playerPokemon, encounteredPokemon);
                }
                Console.WriteLine("*** END OF ENEMY TURN ***");
            }
            

        }

        public static bool EnemyTurn(Pokemon playerPokemon, Pokemon encounteredPokemon)
        {
            if (playerPokemon.RemoveHealth(encounteredPokemon.damage))
            {
                Console.WriteLine("You lost the fight");
                return false;
            }
            return true;
        }

        public static bool Attack(Pokemon playerPokemon, Pokemon encounteredPokemon,int money)
        {
      
            if (encounteredPokemon.RemoveHealth(playerPokemon.damage))
            {
                Console.WriteLine("You won the fight and you gain 5 money.");
                money += 5;
                return false;
            }
            return true;
        }

        public static bool TryToFlee()
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
        

        public static void PokemonCenter() 
        {
            // On rentre dans le pokemon center et ca soigne les pokemons
            // en dépensant de l'argent si possible
        }

        public static void PokeStore() 
        {
           // On lui présente ce qu'il peut acheter
           // vous lui donnez le choix
           // vous vérifiez s'il a l'argent
           // Si oui, vous l'ajoutez dans son inventaire
           // et il sort
           // sinon vous lui dites que c'est impossible et il resort
        }

        public class Pokemon
        {
            public int damage;
            public string name;
            public int currentHealth;
            public int maxHealth;
            public Pokemon(int m_damage, string m_name, int m_maxHealth) 
            {
                this.damage = m_damage;
                this.name = m_name;
                this.maxHealth = m_maxHealth;
                this.currentHealth = m_maxHealth;
            }

            public bool RemoveHealth(int m_damage)
            {
                
                currentHealth -= m_damage;
                if (currentHealth <= 0)
                {
                    return true;
                }
                return false;
                
            }

            public void Display()
            {
                Console.WriteLine(name + " Health: " + currentHealth);
            }
        }
    }
}
