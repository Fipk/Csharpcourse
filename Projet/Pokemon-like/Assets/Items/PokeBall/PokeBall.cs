using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static Pokemon_like.Program;

namespace Pokemon_like
{
    public class PokeBall : Item, IBall
    {
        public PokeBall(int m_price, string m_name) : base(m_price, m_name)
        {
        }

        public bool Catch(Pokemon pokemon, ref Player player)
        {
            Random random = new Random();
            int rnd = random.Next(1, 3);
            if (pokemon.GetCurrentHealth() < pokemon.GetMaxHealth()/2 )
            {
                if (rnd == 1)
                {
                    Console.WriteLine("You succeeded to catch " + pokemon.GetName());
                    player.AddPokemonInStock(pokemon);
                    return true;
                }
                else
                {
                    Console.WriteLine("You failed.");
                }
            } else
            {
                Console.WriteLine("The pokemon can't be catch yet");
            }
            Console.WriteLine("---- END OF CATCH ----");
            return false;
            
        }
    }
    public class SuperBall : Item, IBall
    {
        public SuperBall(int m_price, string m_name) : base(m_price, m_name)
        {
        }

        public bool Catch(Pokemon pokemon, ref Player player)
        {
            Random random = new Random();
            int rnd = random.Next(1, 4);
            if (rnd == 1)
            {
                player.AddPokemonInStock(pokemon);
            }
            return false;
        }
    }
    public class HyperBall : Item, IBall
    {
        public HyperBall(int m_price, string m_name) : base(m_price, m_name)
        {
        }

        public bool Catch(Pokemon pokemon, ref Player player)
        {
            Random random = new Random();
            int rnd = random.Next(1, 3);
            if (rnd == 1)
            {
                player.AddPokemonInStock(pokemon);
            }
            return false;
        }
        
    }
}
