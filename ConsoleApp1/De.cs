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
        Random r;

        public De()
        {
            lettres = new char[6];
            Random r = new Random();
            Lance();
            try
            {
                StreamReader sr = new StreamReader("..\\net6.0\\Lettres.txt");
                string line = "";
                line = sr.ReadToEnd();
                string[] lignes = line.Split('\n');
                string[][] lignesSeparees = new string[lignes.Length][];
                for(int  i = 0; i < lignes.Length; i++)
                {
                    lignesSeparees[i] = lignes[i].Split("; ");
                }
                int alphLength = 0;
                for(int i = 0; i < lignes.Length; i++)
                {
                    alphLength += Convert.ToInt32(lignesSeparees[i][1]);
                }
                char[] alphPondere = new char[alphLength];
                int k = 0;
                for(int i = 0; i < lignes.Length; i++)
                {
                    for(int j = 0;j < Convert.ToInt32(lignes[i][1]); j++)
                    {
                        alphPondere[k] = lignes[i][0];
                        k++;
                    }
                }

                for(int i = 0; i < lettres.Length; i++)
                {
                    lettres[i] = lignes[r.Next(lignes.Length)][0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public char[] Lettres { get { return lettres; } set { lettres = value; } }
        public char Lettre {  get { return lettre; } set { lettre = value; } }
        public void Lance()
        {
            
            lettre = lettres[this.r.Next(0, 5)];
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
