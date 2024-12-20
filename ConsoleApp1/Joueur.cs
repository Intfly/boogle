using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Joueur
    {
        string nom;
        int score;
        string[] motsTrouves;

        public Joueur(string nom)
        {
            this.nom = nom;
            this.score = 0;
            this.motsTrouves = new string[0];
        }

        public bool Contain(string mot)
        {
            bool b = false;
            for(int i = 0;i < this.motsTrouves.Length;i++)
            {
                if(mot == motsTrouves[i])
                {
                    b = true;
                }
            }
            return b;
        }
        public void Add_Mot(string mot)
        {
            if (!Contain(mot))
            {
                string[] mots = new string[motsTrouves.Length + 1];
                for (int i = 0; i < this.motsTrouves.Length; i++)
                {
                    mots[i] = motsTrouves[i];
                }
                mots[motsTrouves.Length] = mot;
                motsTrouves = mots;
            }
            
        }
        public string toString()
        {
            string s = "Nom : " + nom + "\nScore : " + score + "\nMots trouvés : ";
            for( int i = 0;i <motsTrouves.Length;i++)
            {
                s += "\n" + motsTrouves[i];
            }
            return s;
        }
    }
}
