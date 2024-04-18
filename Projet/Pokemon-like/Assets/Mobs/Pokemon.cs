using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_like
{
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
        public Pokemon(int m_damage, string m_name, int m_maxHealth, int m_defense, int m_speed, List<string> m_type)
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
            }
            else
            {
                currentHealth--;
            }
            if (currentHealth <= 0)
            {
                return true;
            }
            return false;

        }

        public void AddCurrentHealth(int healthToAdd)
        {
            if (healthToAdd + currentHealth > maxHealth) 
            {
                Console.WriteLine(currentHealth + " / " + maxHealth);
                currentHealth = maxHealth;
                Console.WriteLine(currentHealth + " / "+ maxHealth);
            } else
            {
                Console.WriteLine(healthToAdd + " has been healed.");
                currentHealth += healthToAdd;
            }
        }



        public void Display()
        {
            Console.Write("The pokemon is " + Name + ". It has " + damage + " attack, " + defense + " defense, " + speed + " speed " + "and he has ");
            foreach (var item in Type)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }

        public void SetCurrentHealth() { this.currentHealth = this.maxHealth; }

        public string GetName() { return Name; }
        public int GetCurrentHealth() { return currentHealth; }
        public int GetMaxHealth() { return maxHealth; }

        public int GetDamage() { return damage; }

      

    }
}
