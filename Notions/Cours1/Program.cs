using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cours1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            /*int entier = 5;
            float flottant = 1f;
            string chaine = "Hello";
            bool isOk = true;
            Console.WriteLine(entier);
            Console.WriteLine(flottant);
            Console.WriteLine(chaine);
            Console.WriteLine(isOk);

            for (int i = 0; i < entier; i++)
            {
                Console.WriteLine(i);
            }
            int incr = 0;
            while (isOk)
            {
                Console.WriteLine("value: " + incr);
                incr++;
                if (incr == entier)
                {
                    isOk = false;
                } else if (incr == entier && isOk){
                    Console.WriteLine("False");
                } else
                {
                    Console.WriteLine("True");
                }
            }
            Console.WriteLine("Taper quelque chose"); // texte pour afficher
            string input = Console.ReadLine(); // Récuper input l'utilisateur écrit
            Console.WriteLine(input); // afficher l'input de l'utilisateur*/

            Personne calvin = new Personne();
            calvin.Display();
            Console.WriteLine(calvin.Id);
        }
      
        
    }

    class Personne
    {
        public int Id { get; set; }
        public void Display()
        {
            Console.WriteLine("Je suis une personne");
        }

        public string DisplayReturn()
        {
            return "Je suis une personne retourner.";
        }

    }
    
    
}

