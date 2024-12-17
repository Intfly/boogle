
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

        Dictionnaire dico = new Dictionnaire("..\\net6.O\\MotsPossiblesFR.txt");
        Console.WriteLine(dico.toString);


    }
}

