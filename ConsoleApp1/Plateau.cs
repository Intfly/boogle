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

        public Plateau()
        {
            this.definirTaillePlateau();
            this.des = new De[this.taille, this.taille];
            this.definirDesPlateau();
        }


        public void definirTaillePlateau()
        {
            Console.WriteLine("Donnez la taille du tableau (défaut et min = 4): ");
            string tailleTemp = "0";
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

            for (int i = 0; i < 4*this.taille +1; i++)
            {
                plateau += "-";
            }
            plateau += "\n";
            for (int i = 0; i < this.taille; i++)
            {
                plateau += "|";
                for (int j = 0; j < this.taille; j++)
                {

                    plateau += " "+this.des[i, j].Lettre+" ";
                    plateau +=  "|" ;
                }
                plateau += "\n";
                for (int j = 0; j < 4*this.taille+1; j++)
                {
                    plateau += "-";
                }
                plateau += "\n";
            }

            return plateau;
        }


        public bool Test_Plateau(string mot, Dictionnaire dico, int indice = 0, bool[,] desUtilises = null, int[] coordonnees = null)
        {

            bool mot_trouve = false;
            if (desUtilises == null)//uniquement lors du premier appel de la fonction
            {

                if (mot.Length < 2) return false;
                mot = mot.ToUpper();

                desUtilises = new bool[this.taille, this.taille];
                coordonnees = new int[2];
                for(int i=0; i < this.taille; i++)
                {
                    for(int j=0; j < this.taille; j++)
                    {
                        desUtilises[i, j] = false;
                    }
                }

                for (int i = 0; i < this.taille; i++)///on trouve la position de la première lettre
                {
                    for (int j = 0; j < this.taille; j++)
                    {
                        if (this.des[i, j].Lettre == mot[indice])
                        {
                            coordonnees[0] = i;
                            coordonnees[1] = j;
                            desUtilises[i,j] = true;
                            mot_trouve |=  Test_Plateau(mot, dico, indice + 1, desUtilises, coordonnees);
                        }
                    }
                }
                return mot_trouve;
            }


            if (indice == mot.Length && (dico == null || dico.RechDichoRecursif(mot)))// && mot appartient au dictionnaire si le dico est précisé
            {
                return true;
            }
            else
            {
                ///on trouve les coordonnées des lettres
                ///on évite les erreurs de dépassement avec les Min et Max
                for (int i = Math.Max(0,coordonnees[0]-1); i <= Math.Min(this.taille-1, coordonnees[0]+1); i++)
                {
                    for (int j = Math.Max(0, coordonnees[1] - 1); j <= Math.Min(this.taille-1, coordonnees[1] + 1); j++)
                    {
                        if (this.des[i, j].Lettre == mot[indice])
                        {
                            coordonnees[0] = i;
                            coordonnees[1] = j;
                            desUtilises[i, j] = true;
                            mot_trouve |=  Test_Plateau(mot, dico, indice + 1, desUtilises, coordonnees);
                        }
                    }
                }
            }
            return mot_trouve;
        }

        public bool testTestPlateau()
        {
            Console.WriteLine("Quelle langue voulez-vous tester ?");
            string langue =Console.ReadLine();
            Dictionnaire dico = new Dictionnaire(langue);
            
            Console.WriteLine("Quels mots voulez-vous tester dans le plateau ? (appuyez sur entrée pour arrêter le programme)\n" + this.toString());
            string sequence =" ";
            
            while (true)
            {
                sequence = Console.ReadLine();
                if (sequence == "") break;
                if(this.Test_Plateau(sequence, dico))
                {
                    Console.WriteLine("Le mot se trouve dans le plateau et est "+langue);

                }
                else
                {
                    Console.WriteLine("Le mot ne se trouve pas de le plateau ou n'est pas "+langue);
                }
            }

            return true;
        }
    }



}
