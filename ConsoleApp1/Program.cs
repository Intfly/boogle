

using ConsoleApp1;

class Program
{

    static void Main()
    {
        Jeu jeu = new Jeu();
        jeu.definirLangueJeu();
        
        Plateau plateau = new Plateau();
        plateau.definirTaillePlateau();


    }
}