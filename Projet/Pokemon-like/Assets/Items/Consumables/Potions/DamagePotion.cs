using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_like.Assets.Items.Consumables.Potions
{
    public class DamagePotion : Item
    {
        private int healthToRemove;
        public DamagePotion(int m_price, string m_name, int healthToRemove) : base(m_price, m_name)
        {
            this.healthToRemove = healthToRemove;
        }

        public override void Use(ref Pokemon pokemon)
        {
            pokemon.RemoveHealth(healthToRemove);
        }

        public int GetHealthToHeal() { return healthToRemove; }
    }
}
