using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Jeu
    {
        string langue;
        Joueur[] joueurs;
        Plateau plateau;
        Dictionnaire dictionnaire;

        public void lancer()
        {
            ///on définit la langue du jeu puis on créé les joueurs et le plateau   
            definirLangueJeu();
            string[] nomJoueurs = this.nommerJoueurs();
            creerJoueurs(nomJoueurs);

            this.plateau = new Plateau();
            this.dictionnaire = new Dictionnaire(this.langue);

            bool fini = false;
            while(fini == false)
            {
                fini = this.tourSuivant();
            }


        }

        public void menuTest()
        {
            int numero = -1;
            string param = "";
            int nombreTest = 0;
            bool retour = false;
            Dictionnaire dictionnaire = new Dictionnaire(param);

            string[] tests = { "appartenance du mot dans le dictionnaire (RechDichoRecursif())", "tri du dictionnaire(triDictionnaire())" };
            Console.WriteLine("Quel test unitaire voulez-vous lancer ?");

            for(int i=0;i< tests.Length; i++)
            {
                Console.WriteLine("test " + (i+1)+ ": " + tests[i]);
            }
            numero = Convert.ToInt32(Console.ReadLine());

            switch (numero)
            {
                case 1:
                    Console.WriteLine("Quelle langue voulez-vous tester ?");
                    param = Console.ReadLine();
                    Console.WriteLine("Combien de tests automatisés voulez-vous faire ?");
                    nombreTest = Convert.ToInt32(Console.ReadLine());

                    retour = dictionnaire.testRecherche(nombreTest);
                    break;

                case 2:

                    Console.WriteLine("Combien de tests automatisés voulez-vous faire ?");
                    nombreTest = Convert.ToInt32(Console.ReadLine());
                    retour = dictionnaire.testTri(nombreTest);
                    break;
            }

            if (retour)
            {
                Console.WriteLine("La fonction marche");
            }
            else
            {
                Console.WriteLine("La fonction ne marche pas");
            }
        }

        public string definirLangueJeu()
        {
            ///permet de définir la langue du jeu
            ///renvoi la langue du jeu
            string langueTemp = "";
            while(langueTemp != "français" && langueTemp != "anglais")
            {
                Console.WriteLine("veuillez choisir la langue du jeu (anglais ou français)");
                langueTemp = Console.ReadLine();
                langueTemp = langueTemp.ToLower();
            }
            this.langue = langueTemp;
            return this.langue;
        }

        public string[] nommerJoueurs()
        {
            int nombreJoueurs = 0;
            while(nombreJoueurs < 2)
            {
                Console.WriteLine("Combien de joueurs participeront au jeu ?");
                nombreJoueurs = Convert.ToInt32(Console.ReadLine());
            }

            string[] nomJoueurs = new string[nombreJoueurs];
            string nomTemp = "";
            for(int i=0; i<nombreJoueurs; i++)///on fait en sorte que l'utilisateur ne puisse pas ne pas avoir de nom
            {
                
                while(nomTemp == "" || nomTemp == " ")
                {
                    Console.WriteLine("Nom du joueur " + (i + 1)+":");
                    nomTemp = Console.ReadLine();
                }
                nomJoueurs[i] = nomTemp;
                nomTemp = "";
            }
            return nomJoueurs;
        }
        public void creerJoueurs(string[] nomJoueurs)
        {
            this.joueurs = new Joueur[nomJoueurs.Length];
            for(int i=0;i<nomJoueurs.Length;i++)
            {
                this.joueurs[i] = new Joueur(nomJoueurs[i]);
            }
        }

        public int calculScore(string mot)
        {
            return 0;
        }

        public bool tourSuivant()
        {

            string motTemp ="";
            int scoreTemp;
            for(int i=0; i<this.joueurs.Length; i++)/// on fait un passage de boucle par joueur
            {
                ///on randomize le plateau et on l'affiche
                this.plateau.lancerDesPlateau();
                Console.WriteLine(this.plateau.toString());

                ///le joueur trouve ensuite des mots
                int compteur = 0;
                List<string> motsTrouves = new List<string> { };
                Console.WriteLine("Au tour de: " + this.joueurs[i].Nom+"!");
                Console.WriteLine("Quels mots avez-vous trouvés ? (si vous n'en trouvez plus, appuyez sur entrée)");
                while (true)
                {
                    Console.Write("Mot "+(compteur+1)+" : ");
                    motTemp = Console.ReadLine();
                    if (motTemp == "" || plateau.Test_Plateau(motTemp, this.dictionnaire)== false) break;
                    motsTrouves.Add(motTemp);
                    compteur++;
                    
                }
                ///prise en compte des mots trouvés cette manche et calcul du score 
                scoreTemp = 0;
                Console.Write("\nMots trouvés ("+motsTrouves.Count+"): ");
                foreach(string mot in motsTrouves)
                {
                    Console.Write(mot + " ");
                    scoreTemp += calculScore(mot)+mot.Length;
                    this.joueurs[i].Add_Mot(mot); 
                }
                this.joueurs[i].Score += scoreTemp;

                ///Récapitulatif
                Console.WriteLine("\nScore gagné cette manche: "+scoreTemp);
                Console.WriteLine("Le joueur " + this.joueurs[i].Nom + " a un score total de " + this.joueurs[i].Score + " points");
                Console.WriteLine("\n");

            }

            return false ;
        }
    }
}
