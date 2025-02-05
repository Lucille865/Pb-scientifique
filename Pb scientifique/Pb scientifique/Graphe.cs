using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb_scientifique
{
        public class Graphe
        {
            private List<Noeud> noeuds;
            private List<Lien> liens;

            public Graphe()
            {
                noeuds = new List<Noeud>();
                liens = new List<Lien>();
            }

            public void AjouterNoeud(int numero)
            {
                Noeud nouveauNoeud = new Noeud(numero);
                noeuds.Add(nouveauNoeud);
            }

            public void AjouterLien(int num1, int num2)
            {
                Noeud noeud1 = null;
                Noeud noeud2 = null;

                foreach (var noeud in noeuds)
                {
                    if (noeud.Numero == num1)
                    {
                        noeud1 = noeud;
                    }
                    if (noeud.Numero == num2)
                    {
                        noeud2 = noeud;
                    }
                }

                if (noeud1 != null && noeud2 != null)
                {
                    Lien lien = new Lien(noeud1, noeud2);
                    liens.Add(lien);
                }
            }

            public void AfficherListeAdjacence()
            {
                Console.WriteLine("Liste d'adjacence :");
                foreach (var noeud in noeuds)
                {
                    Console.Write(noeud.Numero + " -> ");
                    foreach (var voisin in noeud.Voisins)
                    {
                        Console.Write(voisin.Numero + " ");
                    }
                    Console.WriteLine();
                }
            }

            public void AfficherMatriceAdjacence()
            {
                int n = noeuds.Count;
                int[,] matrice = new int[n, n];

                foreach (var lien in liens)
                {
                    int i = lien.Noeud1.Numero - 1;
                    int j = lien.Noeud2.Numero - 1;
                    matrice[i, j] = 1;
                    matrice[j, i] = 1;
                }

                Console.WriteLine("\nMatrice d'adjacence :");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(matrice[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            public void ParcoursEnLargeur(int debut)
            {
                Noeud startNode = null;

                foreach (var noeud in noeuds)
                {
                    if (noeud.Numero == debut)
                    {
                        startNode = noeud;
                        break;
                    }
                }

                if (startNode == null)
                {
                    Console.WriteLine("Le nœud de départ n'existe pas.");
                    return;
                }

                bool[] visite = new bool[noeuds.Count];
                Queue<Noeud> file = new Queue<Noeud>();
                file.Enqueue(startNode);
                visite[startNode.Numero - 1] = true;

                Console.WriteLine("\nParcours en largeur à partir du sommet " + debut + " :");
                while (file.Count > 0)
                {
                    Noeud courant = file.Dequeue();
                    Console.Write(courant.Numero + " ");

                    foreach (var voisin in courant.Voisins)
                    {
                        if (!visite[voisin.Numero - 1])
                        {
                            file.Enqueue(voisin);
                            visite[voisin.Numero - 1] = true;
                        }
                    }
                }
            }

            public void ParcoursEnProfondeur(int debut)
            {
                Noeud startNode = null;

                foreach (var noeud in noeuds)
                {
                    if (noeud.Numero == debut)
                    {
                        startNode = noeud;
                        break;
                    }
                }

                if (startNode == null)
                {
                    Console.WriteLine("Le nœud de départ n'existe pas.");
                    return;
                }

                bool[] visite = new bool[noeuds.Count];
                Stack<Noeud> pile = new Stack<Noeud>();
                pile.Push(startNode);

                Console.WriteLine("\nParcours en profondeur à partir du sommet " + debut + " :");
                while (pile.Count > 0)
                {
                    Noeud courant = pile.Pop();

                    if (!visite[courant.Numero - 1])
                    {
                        Console.Write(courant.Numero + " ");
                        visite[courant.Numero - 1] = true;
                    }

                    foreach (var voisin in courant.Voisins)
                    {
                        if (!visite[voisin.Numero - 1])
                        {
                            pile.Push(voisin);
                        }
                    }
                }
            }
        }
}
