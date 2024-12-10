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
        public string[] strings;
        public string language;

        public Dictionnaire(string file)
        {
            this.file = file;
            List<string> strings = new List<string>();
            string[] strings2;
            try
            {
                StreamReader sr = new StreamReader(file);
                string ligne = sr.ReadToEnd();
                string mot = "";
                for(int i = 0; i < ligne.Length; i++)
                {
                    if (ligne[i] == ' ')
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
            }
            if(file == "..\\net6.0\\MotsPossiblesEN")
            {
                this.language = "English";
            }
            else if(file == "..\\net6.0\\MotsPossiblesFR")
            {
                this.language = "Français";
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
            int nbLength = 0;
            int length = 0;
            for(int i = 0; i < this.strings.Length; i++)
            {
                if (lengths.ContainsKey(strings[i].Length))
                {
                    lengths[strings[i].Length]++;
                }
                else
                {
                    lengths.Add(strings[i].Length, 1);
                }
                for(int j = 0; j <alphabet.Length; j++)
                {
                    if (strings[i][0] == lettres[alphabet[j]])
                    {
                        lettres[alphabet[j]]++;
                    }
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
