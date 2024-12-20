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
        public string Nom { get { return nom; } }
        public int Score { get { return score; } set { score = value; } }
        public string[] MotsTrouves { get { return motsTrouves; } set { motsTrouves = value; } }


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
                if(mot == this.motsTrouves[i])
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
            string s = "Nom : " + this.nom + "\nScore : " + this.score + "\nMots trouvés : ";
            for( int i = 0;i <this.motsTrouves.Length;i++)
            {
                s += "\n" + this.motsTrouves[i];
            }
            return s;
        }
    }
}
