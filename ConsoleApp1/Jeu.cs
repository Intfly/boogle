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

        public string definirLangueJeu()
        {
            this.langue = "FR";
            return "FR";
            //permet de définir la langue du jeu
            //renvoi la langue du jeu
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
    }
}
