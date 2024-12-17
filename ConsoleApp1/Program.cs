
﻿
using ConsoleApp1;

class Program
{

    static void Main()
    {
        /*Jeu jeu = new Jeu();
        string langue = jeu.definirLangueJeu();
        Plateau plateau = new Plateau();
        plateau.definirTaillePlateau();*/
        Dictionnaire dico = new Dictionnaire("français");
        //Console.WriteLine(dico.toString());
        string[] dicoDix = { "arbre", "biere", "manger", "courbe", "zigoto", "iel", "celleux", "toustes", "ielle", "internationalaux" };
        Console.WriteLine(dico.RechDichoRecursif("FUITE",dico.Mots ));
        De de = new De();
        Console.WriteLine(de.toString());
    }
}

