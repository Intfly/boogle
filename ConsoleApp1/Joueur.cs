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
            string[] mots = new string[this.motsTrouves.Length + 1];
            for(int i = 0; i < this.motsTrouves.Length; i++)
            {
                mots[i] = this.motsTrouves[i];
            }
            mots[this.motsTrouves.Length] = mot;
            this.motsTrouves = mots;
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

        public bool testAddMot(Dictionnaire dictionnaire, int nombreTest)
        {
            Random r = new Random();
            for(int i=0; i<nombreTest; i++)
            {
                this.Add_Mot(dictionnaire.mots[r.Next(dictionnaire.mots.Length - 1)]);
            }

            if (this.motsTrouves.Length == nombreTest) return true;
            return false;

        }
    }
}
