using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb_scientifique
{
    internal class Graphe
    {
        private List<int> noeuds;
        private List<Lien> liens;
        private Dictionary<int, List<int>> listeAdjacence;
        private int[,] matriceAdjacence;

        public Graphe(int nbSommets)
        {
            noeuds = new List<int>();
            liens = new List<Lien>();
            listeAdjacence = new Dictionary<int, List<int>>();
            matriceAdjacence = new int[nbSommets, nbSommets];

            // Création des sommets
            for (int i = 1; i <= nbSommets; i++)
            {
                noeuds.Add(i);
                listeAdjacence[i] = new List<int>(); // Chaque sommet a une liste de voisins
            }
        }

        public void AjouterLien(int num1, int num2)
        {
            if (listeAdjacence.ContainsKey(num1) && listeAdjacence.ContainsKey(num2))
            {
                listeAdjacence[num1].Add(num2);
                listeAdjacence[num2].Add(num1);

                matriceAdjacence[num1 - 1, num2 - 1] = 1;
                matriceAdjacence[num2 - 1, num1 - 1] = 1;
            }
        }

        public void AfficherListeAdjacence()
        {
            Console.WriteLine("Liste d'adjacence :");
            foreach (var entry in listeAdjacence)
            {
                Console.Write(entry.Key + " -> ");
                foreach (var voisin in entry.Value) // Utilisation directe de la liste d'adjacence
                {
                    Console.Write(voisin + " ");
                }
                Console.WriteLine();
            }
        }

        public void AfficherMatriceAdjacence()
        {
            Console.WriteLine("\nMatrice d'adjacence :");
            for (int i = 0; i < matriceAdjacence.GetLength(0); i++)
            {
                for (int j = 0; j < matriceAdjacence.GetLength(1); j++)
                {
                    Console.Write(matriceAdjacence[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
