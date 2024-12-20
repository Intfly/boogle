using System;
using System.Collections.Generic;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.Fonts;
using SixLabors.ImageSharp.Processing;


namespace ConsoleApp1
{
    public class Nuage
    {
        // Méthode générant un nuage de mots avec la liste de mots et le nom du joueur
        public static void GenerateWordCloud(List<string> list_words, string playerName)
        {
            string[] words = list_words.ToArray();
            // Dimensions de l'image (largeur x hauteur)
            int width = 800;
            int height = 600;

            // Créer une image avec un fond blanc
            using var image = new Image<Rgba32>(width, height);
            image.Mutate(ctx => ctx.Fill(Color.White));  // Remplir l'image avec un fond blanc

            // Charger une police système pour dessiner les mots
            var fontCollection = new FontCollection();
            var font = SystemFonts.CreateFont("Arial", 20, FontStyle.Bold);  // Choisir la police Arial, taille 20 et en gras

            // Liste des zones occupées pour éviter les chevauchements
            List<RectangleF> occupiedAreas = new List<RectangleF>();
            Random random = new Random();  // Générateur de nombres aléatoires

            // Définir le centre de l'image pour y positionner les mots autour
            PointF center = new PointF(width / 2, height / 2);

            // Paramètres pour l'espacement entre les mots et le nombre maximal de tentatives pour placer un mot
            const float spacing = 30f;  // Espacement entre les mots
            const int maxAttempts = 100; // Nombre d'essais avant d'abandonner un mot

            // Pour chaque mot dans la liste, le placer sur l'image
            foreach (string word in words.OrderBy(_ => random.Next()))  // On mélange les mots pour ajouter de la variété
            {
                // Taille aléatoire pour chaque mot
                int fontSize = random.Next(20, 50);  // Taille de la police aléatoire entre 20 et 50
                var scaledFont = new Font(font, fontSize);  // Appliquer la police avec la taille aléatoire

                // Calculer la largeur et la hauteur approximative du mot en fonction de la taille de la police
                float wordWidth = word.Length * fontSize * 0.5f;  // Estimation de la largeur en fonction du nombre de caractères
                float wordHeight = fontSize;  // Hauteur approximative (taille de la police)

                // Générer une couleur bleue aléatoire pour chaque mot
                var color = GenerateBlueColor(random);

                // Trouver une position où placer le mot sans chevaucher d'autres mots
                PointF wordPosition = FindPosition(center, wordWidth, wordHeight, occupiedAreas, maxAttempts, spacing);

                // Dessiner le mot sur l'image à la position trouvée
                image.Mutate(ctx => ctx.DrawText(word, scaledFont, color, wordPosition));

                // Ajouter la zone occupée par le mot pour éviter les chevauchements futurs
                var occupiedArea = new RectangleF(wordPosition, new SizeF(wordWidth, wordHeight));
                occupiedAreas.Add(occupiedArea);  // Ajouter cette zone à la liste des zones occupées
            }

            // Générer un nom de fichier unique avec le nom du joueur
            string fileName = $"Nuage_{playerName}.png";

            // Sauvegarder l'image générée sous le nom du fichier
            image.Save(fileName);

            Console.WriteLine($"\nNuage de mots généré pour {playerName} : {fileName}");
        }

        // Fonction pour vérifier si deux zones se chevauchent
        static bool IsOverlap(RectangleF a, RectangleF b)
        {
            return a.IntersectsWith(b);  // Renvoie true si les deux rectangles se chevauchent
        }

        // Trouver une position libre pour un mot sans chevauchement
        static PointF FindPosition(PointF center, float wordWidth, float wordHeight, List<RectangleF> occupiedAreas, int maxAttempts, float spacing)
        {
            Random random = new Random();  // Générateur de nombres aléatoires
            int attempts = 0;

            while (attempts < maxAttempts)  // Essayer un nombre maximal de fois pour placer le mot
            {
                // Essayer une nouvelle position aléatoire autour du centre
                float x = center.X + random.Next(-200, 200) - wordWidth / 2;  // Décalage autour du centre, en x
                float y = center.Y + random.Next(-200, 200) - wordHeight / 2; // Décalage autour du centre, en y

                PointF wordPosition = new PointF(x, y);  // Nouvelle position du mot

                // Vérifier si le mot chevauche une autre zone déjà occupée
                bool overlap = false;
                foreach (var area in occupiedAreas)
                {
                    if (IsOverlap(area, new RectangleF(wordPosition, new SizeF(wordWidth, wordHeight))))  // Vérification du chevauchement
                    {
                        overlap = true;
                        break;  // Si chevauchement, arrêter la boucle
                    }
                }

                // Si pas de chevauchement, retourner la position du mot
                if (!overlap)
                {
                    return wordPosition;
                }

                // Si chevauchement, essayer une nouvelle position
                attempts++;
            }

            // Si aucun espace n'est trouvé après plusieurs essais, on renvoie une position par défaut au centre de l'image
            return new PointF(center.X - wordWidth / 2, center.Y - wordHeight / 2);
        }

        // Générer une couleur bleue aléatoire pour chaque mot
        static Color GenerateBlueColor(Random random)
        {
            int r = random.Next(0, 50);    // Rouge faible
            int g = random.Next(0, 50);    // Vert faible
            int b = random.Next(150, 255); // Bleu élevé
            return Color.FromRgb((byte)r, (byte)g, (byte)b);  // Retourner la couleur bleue générée
        }
    }

}