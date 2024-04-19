using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_like
{
    public class Program
    {
        static void Main(string[] args)
        {

            // s'il vous reste du temps
            // TODO Faire une map ou vous pouvez vous baladez et donc 30% de tomber sur un pokemon
            // TODO Vous pouvez faire une arene
            // TODO Vous pouvez faire les évolutions des pokemons

            // Dans le menu pouvoir enlever et ajouter des pokemons dans son équipe
            int x = 10;
            int y = 20;
            Console.WriteLine($"La somme de {x} et {y} est {x + y}");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainWindow());
        }
    }
}
