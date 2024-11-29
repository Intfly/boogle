

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