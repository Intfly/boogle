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
        public char[] Lettres { get { return lettres; } set { lettres = value; } }
        public char Lettre { get { return lettre; } set { lettre = value; } }
        public De()
        {
            lettres = new char[6];
            this.r = new Random();
            
            
            try
            {
                StreamReader sr = new StreamReader("..\\net6.0\\Lettres.txt");
                string text = "";
                text = sr.ReadToEnd();
                string[] lignes = text.Split('\n');
                string[][] lignesSeparees = new string[lignes.Length][];
                for(int  i = 0; i < lignes.Length; i++)
                {
                    lignesSeparees[i] = lignes[i].Split(";");
                }
                int alphLength = 0;
                for(int i = 0; i < lignesSeparees.GetLength(0); i++)
                {
                    alphLength += Convert.ToInt32(lignesSeparees[i][2]);
                }
                char[] alphPondere = new char[alphLength];
                int k = 0;
                for(int i = 0; i < lignesSeparees.GetLength(0); i++)
                {
                    for(int j = 0;j < Convert.ToInt32(lignesSeparees[i][2]); j++)
                    {
                        alphPondere[k] = lignesSeparees[i][0][0];
                        k++;
                    }
                }
                for(int i = 0; i < lettres.Length; i++)
                {
                    lettres[i] = alphPondere[r.Next(alphPondere.Length)];
                }
                Lance();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        
        public void Lance()
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
