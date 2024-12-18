
﻿
using ConsoleApp1;

class Program
{

    static void Main()
    {
        Jeu jeu = new Jeu();
        string langue = jeu.definirLangueJeu();

        
        Plateau plateau = new Plateau();
        plateau.definirTaillePlateau();
        plateau.definirDesPlateau();
        plateau.toString();

        
        //Dictionnaire dico = new Dictionnaire("français");
        //Console.WriteLine(dico.toString);


    }
}

