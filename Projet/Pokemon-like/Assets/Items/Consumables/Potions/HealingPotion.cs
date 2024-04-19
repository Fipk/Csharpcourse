using Pokemon_like.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_like.Assets.Items.Consumables.Potions
{
    public class HealingPotion : Item
    {
        private int healthToHeal;
        public HealingPotion(int m_price, string m_name, int healthToHeal) : base(m_price, m_name)
        {
            this.healthToHeal = healthToHeal;
        }

        public override void Use(ref Pokemon pokemon)
        {
            pokemon.AddCurrentHealth(healthToHeal);
        }

        public int GetHealthToHeal() { return healthToHeal; }
    }
}
