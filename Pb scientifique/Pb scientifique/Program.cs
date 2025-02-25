namespace Pb_scientifique
{
    public class Program
    {
        static void Main(string[] args)
        {

            string cheminFichier = "soc-karate.mtx";
            Graphe graphe = new Graphe();
            LireRelationsDepuisFichier(cheminFichier, graphe);
            graphe.AfficherListeAdjacence();
            Console.WriteLine("Le graphe est-il connexe ? " + (graphe.EstConnexe() ? "Oui" : "Non"));
            Console.WriteLine("Le graphe contient-il des cycles ? " + (graphe.ContientCycle() ? "Oui" : "Non"));
        }

        static void LireRelationsDepuisFichier(string cheminFichier, Graphe graphe)
        {
            if (!File.Exists(cheminFichier))
            {
                Console.WriteLine("Fichier introuvable !");
                return;
            }

            string[] lignes = File.ReadAllLines(cheminFichier);

            foreach (string ligne in lignes)
            {
                string[] elements = ligne.Split(' ');
                if (elements.Length == 2 && int.TryParse(elements[0], out int num1) && int.TryParse(elements[1], out int num2))
                {
                    graphe.AjouterLien(num1, num2);
                }
            }
            Graphe graphe1 = new Graphe();
            // Ajouter des nœuds et des relations
            graphe1.AjouterLien(1, 2);
            graphe1.AjouterLien(2, 3);
            graphe1.AjouterLien(3, 1);

            GrapheVisualisation visualisation = new GrapheVisualisation(graphe);
            visualisation.DessinerGraphe("graphe.png");

        }
    }
}
