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
        public string[] Mots { get { return mots; } set { mots = value; } }
        public Dictionnaire(string language)
        {
            this.language = language;
            string file = "";
            if (language == "français")
            {
                file = "..\\net6.0\\MotsPossiblesFR.txt";
            }
            else if (language == "anglais")
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
                for (int i = 0; i < ligne.Length; i++)
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
            for (int i = 0; i < strings.Count; i++)
            {
                strings2[i] = strings[i];
            }
            mots = triDictionnaire(strings2);
        }
        public string toString()
        {
            IDictionary<int, int> lengths = new Dictionary<int, int>();
            IDictionary<char, int> lettres = new Dictionary<char, int>();
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for (int i = 0; i < alphabet.Length; i++)
            {
                lettres.Add(alphabet[i], 0);
            }
            IDictionary<char, int> lettres2 = new Dictionary<char, int>();
            foreach (char c in lettres.Keys)
            {
                lettres2.Add(c, lettres[c]);
            }
            for (int i = 0; i < this.mots.Length; i++)
            {
                if (lengths.ContainsKey(mots[i].Length))
                {
                    lengths[mots[i].Length]++;
                }
                else
                {
                    lengths.Add(mots[i].Length, 1);
                }
                foreach (char j in lettres.Keys)
                {
                    if (mots[i].Length != 0 && mots[i][0] == j)
                    {
                        lettres2[j]++;
                    }
                }
                foreach (char j in lettres.Keys)
                {
                    lettres[j] = lettres2[j];
                }
            }
            string tostring = "Nombre de mots par longueur :";
            foreach (int key in lengths.Keys)
            {
                tostring += "\n" + lengths[key] + " mots de longeur " + key + ".";
            }
            foreach (char key in lettres.Keys)
            {
                tostring += "\n" + lettres[key] + " mots commençant par " + key + ".";
            }
            tostring += "\nLangue : " + this.language;
            return tostring;
        }
        public static string[] triDictionnaire(string[] dico)
        {
            if (dico.Length <= 1)
            {
                return dico;
            }
            else
            {
                int mid = dico.Length / 2;
                string[] mots1 = triDictionnaire(dico[0..mid]);
                string[] mots2 = triDictionnaire(dico[mid..]);

                return fusion(mots1, mots2);
            }
        }
        public static string[] fusion(string[] mots1, string[] mots2)
        {
            int i = 0, j = 0, k = 0;
            string[] result = new string[mots1.Length + mots2.Length];

            while (i < mots1.Length && j < mots2.Length)
            {
                if (mots1[i].CompareTo(mots2[j]) <= 0)
                {
                    result[k++] = mots1[i++];
                }
                else
                {
                    result[k++] = mots2[j++];
                }
            }

            while (i < mots1.Length)
            {
                result[k++] = mots1[i++];
            }
            while (j < mots2.Length)
            {
                result[k++] = mots2[j++];
            }

            return result;
        }
        public bool RechDichoRecursif(string mot, string[] dico = null)
        {
            if (dico == null) dico = this.mots;
            int mil = dico.Length / 2;
            if (dico.Length == 0)
            {
                return false;
            }
            else if (dico[mil] == mot)
            {
                return true;
            }
            else if (dico[mil].CompareTo(mot) == 1)
            {
                string[] dico1 = new string[mil];
                Array.Copy(dico, 0, dico1, 0, mil);
                return RechDichoRecursif(mot, dico1);
            }
            else
            {
                string[] dico2 = new string[dico.Length - mil - 1];
                Array.Copy(dico, mil + 1, dico2, 0, dico2.Length);
                return RechDichoRecursif(mot, dico2);
            }
        }

        public bool testRecherche(int nombreTest)
        {
            ///return true si tous les test passent, false sinon
            
            Random random = new Random();
            int indice;
            for(int i=0; i < nombreTest; i++)
            {
                indice = random.Next(this.mots.Length-1);
                if (!RechDichoRecursif(this.mots[indice])) return false;
            }
            return true;
        }

        public bool testTri()
        {
            for(int i=1; i < this.mots.Length; i++)
            {
                ///on vérifie si les mots sont bien ordonnés
                for(int y=0; y < Math.Max(this.mots[i].Length, this.mots[i-1].Length); y++)
                {

                }
            }

            return true;
        }

    }
}

