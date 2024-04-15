using System;
using System.Runtime.CompilerServices;


namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World !");

            Monster ogre = new Monster(25, "Mok", "Normal","Other");
            Monster loup = new Monster(5, "Ahouu", "Normal", "Female");
            Witch sorciere = new Witch(1, "Hehiy", "Rare", "Female", 5);

            //ogre.DisplayInfo();
            //loup.DisplayInfo();
            //sorciere.DisplayInfo();

            //ogre.DisplayPrivate(); inutilisable car private
            //ogre.DisplayProtected(); inutilisable car protected

            // List
            List<Monster> monsters = new List<Monster>
            {
                new Monster(6,"Mak","Normal","Other")
            };

            monsters.Add(ogre);
            monsters.Add(loup);
            monsters.Add(sorciere);

            // Afficher les infos de la liste
            foreach (Monster monster in monsters)
            {
                Console.WriteLine("The monster name is " + monster.name);
            }

            // array
            int[] ints = new int[5];

            ints[0] = 40;
            ints[1] = 15;
            ints[2] = 2;

            // afficher les infos du tableau
            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }

            // Dictionnaire
            Dictionary<string, int> stock = new Dictionary<string, int>();

            stock["Pommes"] = 50;
            stock["Ananas"] = 25;
            stock["Poires"] = 5;

            // Afficher les infos du dictionnaire
            foreach (var kvp in stock)
            {
                Console.WriteLine($"clé {kvp.Key}, valeur {kvp.Value}");
            }


            stock["Pommes"] = 30;
            stock["Tomates"] = 10;

            foreach (var kvp in stock)
            {
                Console.WriteLine($"clé {kvp.Key}, valeur {kvp.Value}");
            }



        }
    }
   
        

    interface IDescription
    {
        void DisplayInfo();  
    }

    class Monster : IDescription
    {
        // Propriétés de la class
        public int damage;
        public string name;
        public string rarity;
        public string genre;

        //public // accessible par nimporte qui
        //private // accessible que dans la classe a qui il appartient
        //protected // rend les méthodes des enfants public

        //Constructeur
        public Monster(int m_damage, string m_name, string m_rarity, string m_genre)
        {
            this.damage = m_damage;
            this.name = m_name;
            this.rarity = m_rarity;
            this.genre = m_genre;
        }

        // Methodes
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Monster name is " + name + ". Its rarity is " + rarity + " and it has " + damage + " damage.");
            Console.WriteLine("***********************************");
        }

        private void DisplayPrivate()
        {
            Console.WriteLine("I am private.");
        }

        protected void DisplayProtected()
        {
            Console.WriteLine("I am protected.");
        }
        
        public void Add<T, t2,t3,t4>(T item1, T item2) 
        {
            //return item2 + item1;
        }
    }

    class Witch : Monster
    {
        private int potions;

        public Witch(int m_damage, string m_name, string m_rarity, string m_genre,int m_potions) : base(m_damage, m_name, m_rarity, m_genre)
        {
            this.potions = m_potions;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("And she has " + potions + " potions left.");
            DisplayProtected();
        }

        public void SetPotions(int potions)
        {
            this.potions = potions;
        }

        public int GetPotions() 
        {
            return potions;
        }
    }

    class Pig : Monster
    {
        public string color;

        public Pig(int m_damage, string m_name, string m_rarity, string m_genre, string m_color) : base(m_damage, m_name, m_rarity, m_genre)
        {
            this.color = m_color;
        }
    }
}
