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
            ///Définit quel fichier accéder en fonction de la langue
            string file = "";
            if (language == "français")
            {
                file = "..\\net6.0\\MotsPossiblesFR.txt";
            }
            else if (language == "anglais")
            {
                file = "..\\net6.0\\MotsPossiblesEN.txt";
            }
            ///Initialisation du dictionnaire
            List<string> strings = new List<string>();
            string[] strings2;
            try
            {
                ///lit le fichier selon la langue et crée une liste de tous les mots selon les " "
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
            ///Création d'un tableau copie de la liste
            strings2 = new string[strings.Count];
            for (int i = 0; i < strings.Count; i++)
            {
                strings2[i] = strings[i];
            }
            ///Tri du tableau (ici tri par tas)
            mots = (strings2);
            triParTas(strings2, mots.Length);
        }
        public string toString()
        {
            ///Création de dictionnaires qui associent respectivement une longueur de mots au nombre de mots avec cette longueur
            ///et une lettre de l'alphabet au nombre de mots commençant par cette lettre
            IDictionary<int, int> lengths = new Dictionary<int, int>();
            IDictionary<char, int> lettres = new Dictionary<char, int>();
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            ///Initialisation de lettres avec chaque lettre ayant 0 mots commençant par elle
            for (int i = 0; i < alphabet.Length; i++)
            {
                lettres.Add(alphabet[i], 0);
            }
            ///Création d'une copie de lettres
            IDictionary<char, int> lettres2 = new Dictionary<char, int>();
            foreach (char c in lettres.Keys)
            {
                lettres2.Add(c, lettres[c]);
            }
            ///Attribution des longueurs de mots : 
            ///Pour chaque mot, regarder si sa longueur est déja renseignée dans lengths, si c'est le cas incrémenter le nombre de mots avec la longueur.
            ///Si ce n'est pas le cas, ajouter cette longueur qui n'est présente que une fois vu que c'est la première fois que l'on la rencontre.
            ///Attribution des lettres débutant un mot :
            ///Pour chaque lettre de l'alphabet, vérifier si le mot n'est pas nul et s'il commence par cette lettre.
            ///Puis copier les valeurs de lettres2 dans lettres.
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
            ///Pour l'affichage, on fait 
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
        public static int partition(string[] dico, int g, int d, int pivot)
        {
            string pivotValue = dico[pivot]; 
            string temp = dico[pivot];
            dico[pivot] = dico[d];
            dico[d] = temp;
            int storeIndex = g;
            for (int i = g; i < d; i++)
            {
                if (dico[i].CompareTo(pivotValue) < 0) 
                {
                    temp = dico[i];
                    dico[i] = dico[storeIndex];
                    dico[storeIndex] = temp;
                    storeIndex++;
                }
            }
            temp = dico[storeIndex];
            dico[storeIndex] = dico[d];
            dico[d] = temp;

            return storeIndex;
        } 
        public static void triRapide(string[] dico, int g, int d)
        {
            if (g < d)
            {
                int pivot = g + (d - g) / 2;
                pivot = partition(dico, g, d, pivot);
                triRapide(dico, g, pivot - 1);
                triRapide(dico, pivot + 1, d);
            }
        }
        public static void tamis(string[] dico, int noeud, int n)
        {
            int k = noeud;
            int max = k;
            int gauche = 2 * k + 1;
            int droite = 2 * k + 2;
            if(gauche < n && dico[gauche].CompareTo(dico[max]) > 0)
            {
                max = gauche;
            }
            if(droite < n && dico[droite].CompareTo(dico[max]) > 0)
            {
                max = droite;
            }
            if(max != k)
            {
                string temp = dico[k];
                dico[k] = dico[max];
                dico[max] = temp;
                tamis(dico, max, n);
            }
        }
        public static void triParTas(string[] dico, int longueur)
        {
            for(int i = longueur / 2 - 1; i >= 0; i--)
            {
                tamis(dico, i, longueur);
            }
            for(int i = longueur - 1; i >=1; i--)
            {
                string temp = dico[i];
                dico[i] = dico[0];
                dico[0] = temp;
                tamis(dico, 0, i);
            }
        }
        public bool RechDichoRecursif(string mot, string[] dico =null)
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
                if (this.mots[i - 1].CompareTo(this.mots[i])>0) return false;
            }

            return true;
        }

    }
}

