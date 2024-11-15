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
            this.motsTrouves = new int[motsTrouves.Length + 1];
            for(int i = 0; i < this.motsTrouves.Length; i++)
            {

            }
        }
    }
}
