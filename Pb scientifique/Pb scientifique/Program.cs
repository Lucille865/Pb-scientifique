namespace Pb_scientifique
{
    internal class Program
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
        }
    }
}
