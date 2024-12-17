<<<<<<< HEAD
﻿

using ConsoleApp1;

class Program
{

    static void Main()
    {
        Jeu jeu = new Jeu();
        string langue = jeu.definirLangueJeu();

        Dictionnaire dictionnaire = new Dictionnaire(langue);
        dictionnaire.trierDictionnaire();


        
        Plateau plateau = new Plateau();
        plateau.definirTaillePlateau();



    }
}
=======

// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
Dictionnaire dico = new Dictionnaire("..\\net6.O\\MotsPossiblesFR.txt");
Console.WriteLine(dico.toString);

>>>>>>> arthur
