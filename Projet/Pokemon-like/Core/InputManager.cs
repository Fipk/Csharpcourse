using Pokemon_like.Assets.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_like.Core
{
    public class InputManager
    {
        public InputManager() { }

        public void InputHandle(ref Player player) 
        {
            if (!(player.GetChoice() == 0))
            {
                player.SetChoice(InputChoice());
            }
        }

        public int InputChoice()
        {
            string value = Console.ReadLine();
            return int.Parse(value);
        }
    }
}
