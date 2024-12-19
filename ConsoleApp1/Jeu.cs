using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Jeu
    {
        string langue;
        Joueur[] joueurs;

        public void lancer()
        {
            ///on définit la langue du jeu puis on créé les joueurs et le plateau   
            definirLangueJeu();
            string[] nomJoueurs = this.nommerJoueurs();
            creerJoueurs(nomJoueurs);

            Plateau plateau = new Plateau();

        }

        public string definirLangueJeu()
        {
            this.langue = "FR";
            return "FR";
            ///permet de définir la langue du jeu
            ///renvoi la langue du jeu
            string langueTemp = "";
            while(langueTemp != "français" && langueTemp != "anglais")
            {
                Console.WriteLine("veuillez choisir la langue du jeu (anglais ou français)");
                langueTemp = Console.ReadLine();
                langueTemp = langueTemp.ToLower();
            }
            switch (langueTemp)
            {
                case "français":
                    this.langue = "FR";
                    break;  
                case "anglais":
                    this.langue = "EN";
                    break;
            }
            return this.langue;
        }

        public string[] nommerJoueurs()
        {
            int nombreJoueurs = 0;
            while(nombreJoueurs < 1)
            {
                Console.WriteLine("Combien de joueurs participeront au jeu ?");
                nombreJoueurs = Convert.ToInt32(Console.ReadLine());
            }

            string[] nomJoueurs = new string[nombreJoueurs];
            for(int i=0; i<nombreJoueurs; i++)
            {
                nomJoueurs[i] = Console.ReadLine();
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
    }
}
