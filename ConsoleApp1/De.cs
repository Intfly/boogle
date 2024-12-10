using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class De
    {
        char[] lettres;
        char lettre;

        public De(char[] lettres, char lettre)
        {
            if(lettres.Length == 6)
            {
                this.lettres = lettres;
            }
            this.lettre = lettre;
        }
        public char[] Lettres { get { return lettres; } set { lettres = value; } }
        public char Lettre {  get { return lettre; } set { lettre = value; } }
        public void Lance(Random r)
        {
            lettre = lettres[r.Next(0, 5)];
        }
        public string toString()
        {
            string s = "Dé : \n";
            for(int i = 0; i < lettres.Length; i++)
            {
                s += lettres[i].ToString() + " ; ";
            }
            s += "\nLettre lancée : " + lettre;
            return s;
        }
    }
}
