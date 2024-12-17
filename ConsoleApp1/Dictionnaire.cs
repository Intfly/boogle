using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Dictionnaire
    {
        public string file;
        public string[] mots;
        public string language;

        public Dictionnaire(string language)
        {
            this.language = language;
            string file = "";
            if(language == "français")
            {
                file = "..\\net6.0\\MotsPossiblesFR.txt";
            }
            else if(language == "english")
            {
                file = "..\\net6.0\\MotsPossiblesEN.txt";
            }
            List<string> strings = new List<string>();
            string[] strings2;
            try
            {
                StreamReader sr = new StreamReader(file);
                string ligne = sr.ReadToEnd();
                string mot = "";
                for(int i = 0; i < ligne.Length; i++)
                {
                    if (ligne[i] == ' ' && mot.Length != 0)
                    {
                        strings.Add(mot);
                        mot = "";
                    }
                    else
                    {
                        mot += ligne[i];
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                Console.WriteLine("Le fichier n'est pas lisible.");
            }
            strings2 = new string[strings.Count];
            for(int i = 0; i < strings.Count; i++)
            {
                strings2[i] = strings[i];
            }
            this.strings = strings2;
        }
        public string toString()
        {
            IDictionary<int, int> lengths = new Dictionary<int, int>();
            IDictionary<char, int> lettres = new Dictionary<char, int>();
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for(int i = 0; i < alphabet.Length; i++)
            {
                lettres.Add(alphabet[i], 0);
            }
            IDictionary<char, int> lettres2 = new Dictionary<char, int>();
            foreach(char c in lettres.Keys)
            {
                lettres2.Add(c, lettres[c]);
            }
            for(int i = 0; i < this.mots.Length; i++)
            {
                if (lengths.ContainsKey(strings[i].Length))
                {
                    lengths[mots[i].Length]++;
                }
                else
                {
                    lengths.Add(strings[i].Length, 1);
                }
                foreach(char j in lettres.Keys)
                {
                    if (strings[i].Length != 0 && strings[i][0] == j)
                    {
                        lettres2[j]++;
                    }
                }
                foreach(char j in lettres.Keys)
                {
                    lettres[j] = lettres2[j];
                }
            }
            string tostring = "Nombre de mots par longueur :";
            foreach(int key in lengths.Keys)
            {
                tostring += "\n" + lengths[key] + " mots de longeur " + key + ".";
            }
            foreach(char key in lettres.Keys)
            {
                tostring += "\n" + lettres[key] + " mots commençant par " + key + ".";
            }
            tostring += "\nLangue : " + this.language;
            return tostring;
        }
        
    }
}
