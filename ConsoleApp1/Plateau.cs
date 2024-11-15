using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Plateau
    {

        private int taille;
        private int[,] lettres;
        public void definirTaillePlateau()
        {
            Console.WriteLine("Donnez la taille du tableau (défaut et min = 4): ");
            string tailleTemp = "0";
            bool premierEssai = true;
            while (Convert.ToInt32(tailleTemp) < 4)
            {
                tailleTemp = Console.ReadLine();
                try
                {
                    if (tailleTemp == "")
                    {
                        tailleTemp = "4";
                    }
                    if(Convert.ToInt32(tailleTemp) < 4)
                    {
                        Console.WriteLine("La taille insérée n'est pas valide (min = 4)");
                    }
                }
                catch
                {
                    Console.WriteLine("la valeur insérée doit être un nombre (min = 4)");
                    tailleTemp = "0";
                }

            }

            this.taille = Convert.ToInt32(tailleTemp);
            Console.WriteLine("Le tableau est de taille " + this.taille + "x"+this.taille);
        }
    }

}
