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
        private De[,] des;



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
                    if (Convert.ToInt32(tailleTemp) < 4)
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
            Console.WriteLine("Le tableau est de taille " + this.taille + "x" + this.taille);
        }


        public void definirDesPlateau()
        {
            for (int i = 0; i < this.taille; i++)
            {
                for (int j = 0; j < this.taille; j++)
                {
                    this.des[i, j] = new De();
                }
            }
        }

        public void lancerDesPlateau()
        {
            for (int i = 0; i < this.taille; i++)
            {
                for (int j = 0; j < this.taille; j++)
                {
                    this.des[i, j].Lance();
                }
            }
        }


        public string toString()
        {
            string plateau = "";

            for (int i = 0; i < this.taille; i++)
            {
                plateau += "-";
            }

            for (int i = 0; i < this.taille; i++)
            {
                plateau += "|";
                for (int j = 0; j < this.taille; j++)
                {

                    plateau += des[i, j];
                    plateau += (i < this.taille - 1) ? "|" : "";
                }
                plateau += "\n";
                for (int j = 0; j < this.taille; j++)
                {
                    plateau += "-";
                }
                plateau += "\n";
            }

            return plateau;
        }


        public bool Test_Plateau(string mot, int indice = 0, bool[,] desUtilises = null, int[] coordonnees = null)
        {

            bool mot_trouve = false;
            if (desUtilises == null)//uniquement lors du premier appel de la fonction
            {

                if (mot.Length < 2) return false;

                desUtilises = new bool[this.taille, this.taille];
                for(int i=0; i < this.taille; i++)
                {
                    for(int j=0; j < this.taille; j++)
                    {
                        desUtilises[i, j] = false;
                    }
                }

                for (int i = 0; i < this.taille; i++)//on trouve la position de la première lettre
                {
                    for (int j = 0; j < this.taille; j++)
                    {
                        if (this.des[i, j].Lettre == mot[indice])
                        {
                            coordonnees[0] = i;
                            coordonnees[1] = j;
                            desUtilises[i,j] = true;
                            mot_trouve |=  Test_Plateau(mot, indice + 1, desUtilises, coordonnees);
                        }
                    }
                }
                return mot_trouve;
            }


            if (indice == mot.Length && true)// && mot appartient au dictionnaire
            {
                return true;
            }
            else
            {
                //on trouve les coordonnées des lettres
                //on évite les erreurs de dépassement avec les Min et Max
                for (int i = Math.Max(0,coordonnees[0]-1); i < Math.Min(this.taille, coordonnees[0]+1); i++)
                {
                    for (int j = Math.Max(0, coordonnees[1] - 1); j < Math.Min(this.taille, coordonnees[1] + 1); j++)
                    {
                        if (this.des[i, j].Lettre == mot[indice])
                        {
                            coordonnees[0] = i;
                            coordonnees[1] = j;
                            desUtilises[i, j] = true;
                            mot_trouve |=  Test_Plateau(mot, indice + 1, desUtilises, coordonnees);
                        }
                    }
                }
            }
            return mot_trouve;
        }
    }



}
