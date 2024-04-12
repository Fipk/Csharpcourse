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
            // systeme de sauvegarde JSON
            // systeme classique
            // Rajoutera la POO
            // rajoutera les Collections
            // rajoutera les design patterns

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
                
                Console.Clear();
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
                Console.ReadLine();
            }
        }

        public static void Battle() // TODO
        {
            // Afficher les points de vie de votre pokemon et de celui que vous rencontrez
            // Vous montrez les choix que le joueur a: Attaquer ou s'échapper
            // s'il choisit d'attaquer il va faire les dégàts du pokemon
            // ensuite c'est l'autre pokemon qui joue qu'il ne fera que attaquer
            // sinon il choisit de s'enfuir et il a 50% de chance de réussir 
            // s'il réussit vous lui mettez un message de réussite et le combat quitte
            // sinon il ne réussit et c'est à l'autre pokemon de jouer
            // quand le pokemon rencontrez vous gagnez de l'argent et le combat se termine
            // si par contre c'est vous qui mourrez le combat s'annule et votre ne peut plus se battre
        }

        public static void PokemonCenter() // NOT TODO comme vous voulez
        {
            // On rentre dans le pokemon center et ca soigne les pokemons
            // en dépensant de l'argent si possible
        }

        public static void PokeStore() // NOT TODO comme vous voulez
        {
           // On lui présente ce qu'il peut acheter
           // vous lui donnez le choix
           // vous vérifiez s'il a l'argent
           // Si oui, vous l'ajoutez dans son inventaire
           // et il sort
           // sinon vous lui dites que c'est impossible et il resort
        }

        class Pokemon
        {
            public int damage;
            public string name;
            public int health;
            public Pokemon(int m_damage, string m_name, int m_health) 
            {
                this.damage = m_damage;
                this.name = m_name;
                this.health = m_health;
            }

            public void RemoveHealth(int m_damage)
            {
                // check si le pokemon est mort
                // si oui le combat va s'annuler
                // sinon ca continue
                health -= m_damage;
                health = health - m_damage;
                
            }
        }
    }
}
