using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Dictionnaire
    {
        string langue;
        string[] mots;

        public Dictionnaire(string langue)
        {
            this.langue = langue;

            //permet d'obtenir le path du fichier de mots de la langue choisie depuis le profil de debug
            string path_mots = "../../../../fichiersAnnexe/MotsPossibles" + langue + ".txt";

            using (StreamReader listeMotsRaw = new StreamReader(path_mots))
            {
                string listeMotsString = listeMotsRaw.ReadLine();
                //On créé une array de mots à partir de la string de mots séparés par un espace
                this.mots = listeMotsString.Split(" ");
            }
        }


        public void afficherDictionnaire()
        {
            foreach(string mot in this.mots)
            {
                Console.WriteLine(mot);
            }
        }
        public void trierDictionnaire()
        {
            //tri par sélection pour ordonner dans l'ordre alphabétique les mots du dicitonnaire
            for (int i = 0; i < this.mots.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < this.mots.Length; j++)
                {
                    int indice_lettre = 0;
                    while (indice_lettre < this.mots[j].Length && indice_lettre < this.mots[min].Length)
                    {
                        if (this.mots[j][indice_lettre] < this.mots[min][indice_lettre])
                        {
                            min = j;
                            break;
                        }
                        if(this.mots[j][indice_lettre] > this.mots[min][indice_lettre])
                        {
                            break;
                        }
                        indice_lettre++;
                    }
                    
                }

                string temp = this.mots[min];
                this.mots [min] = this.mots[i];
                this.mots[i] = temp;
            }
        }
    }
}
