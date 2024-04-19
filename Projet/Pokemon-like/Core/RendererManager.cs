using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_like.Core
{
    public class RendererManager
    {
        public RendererManager() { }

        public void Render(ref Player player) 
        {
            ChoiceMenu(ref player);
        }

        public void ChoiceMenu(ref Player player)
        {
            Console.WriteLine("What do you want to do " + player.GetName() + " ?");
            //Console.WriteLine("You have " + money + " money left.");
            Console.WriteLine("1. Battle with a random pokemon");
            Console.WriteLine("2. Meet a trainer.");
            Console.WriteLine("3. Go to the Pokemon center");
            Console.WriteLine("4. Show my items");
            Console.WriteLine("5. Show all my pokemon");
            Console.WriteLine("6. Leave the game");
        }
    }
}
