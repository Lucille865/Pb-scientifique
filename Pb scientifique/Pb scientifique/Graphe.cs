using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb_scientifique
{
    public class Graphe
    {
        private Dictionary<int, List<int>> listeAdjacence; // Stocke les relations entre les membres

        public Graphe()
        {
            listeAdjacence = new Dictionary<int, List<int>>();
        }

        // Ajouter une relation entre deux membres
        public void AjouterLien(int num1, int num2)
        {
            if (!listeAdjacence.ContainsKey(num1))
                listeAdjacence[num1] = new List<int>();

            if (!listeAdjacence.ContainsKey(num2))
                listeAdjacence[num2] = new List<int>();

            // Ajouter la relation (dans les deux sens car c’est réciproque)
            listeAdjacence[num1].Add(num2);
            listeAdjacence[num2].Add(num1);
        }

        // Afficher la liste d'adjacence
        public void AfficherListeAdjacence()
        {
            Console.WriteLine("Liste d'adjacence du graphe :");
            foreach (var noeud in listeAdjacence)
            {
                Console.Write(noeud.Key + " -> ");
                Console.WriteLine(string.Join(", ", noeud.Value));
            }
        }

        // Vérifier si le graphe est connexe
        public bool EstConnexe()
        {
            if (listeAdjacence.Count == 0) return false;

            HashSet<int> visites = new HashSet<int>();
            int premierNoeud = new List<int>(listeAdjacence.Keys)[0];

            ExplorerEnProfondeur(premierNoeud, visites);

            return visites.Count == listeAdjacence.Count;
        }

        // Vérifier si le graphe contient un cycle
        public bool ContientCycle()
        {
            HashSet<int> visites = new HashSet<int>();
            foreach (var noeud in listeAdjacence.Keys)
            {
                if (!visites.Contains(noeud))
                {
                    if (ExplorerCycle(noeud, -1, visites)) return true;
                }
            }
            return false;
        }

        // Parcours en profondeur pour vérifier la connexité
        private void ExplorerEnProfondeur(int noeud, HashSet<int> visites)
        {
            visites.Add(noeud);
            foreach (var voisin in listeAdjacence[noeud])
            {
                if (!visites.Contains(voisin))
                    ExplorerEnProfondeur(voisin, visites);
            }
        }
        // Parcours en largeur
        public void ParcoursLargeur(int sommetDepart)
        {
            HashSet<int> visites = new HashSet<int>(); // Pour garder une trace des sommets visités
            Queue<int> file = new Queue<int>(); // File pour gérer l'ordre des visites

            file.Enqueue(sommetDepart);
            visites.Add(sommetDepart);

            Console.Write("Parcours en largeur : ");

            while (file.Count > 0)
            {
                int noeud = file.Dequeue(); // On sort le premier élément de la file
                Console.Write(noeud + " "); // Affichage immédiat

                // Ajouter les voisins non encore visités
                foreach (var voisin in listeAdjacence[noeud])
                {
                    if (!visites.Contains(voisin))
                    {
                        file.Enqueue(voisin);
                        visites.Add(voisin);
                    }
                }
            }
            Console.WriteLine();
        }
    
        // Parcours pour détecter un cycle
        private bool ExplorerCycle(int noeud, int parent, HashSet<int> visites)
        {
            visites.Add(noeud);
            foreach (var voisin in listeAdjacence[noeud])
            {
                if (!visites.Contains(voisin))
                {
                    if (ExplorerCycle(voisin, noeud, visites)) return true;
                }
                else if (voisin != parent)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Noeud> GetNoeuds()
        {
            List<Noeud> noeuds = new List<Noeud>();

            foreach (var key in listeAdjacence.Keys)
            {
                noeuds.Add(new Noeud(key)); // Crée un Noeud pour chaque clé du dictionnaire
            }

            return noeuds;
        }

    }
}