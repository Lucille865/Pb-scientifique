using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb_scientifique
{
    public class Noeud
    {
        public int numero;
        public List<Noeud> voisins;

        public Noeud(int numero)
        {
            this.numero = numero;
            this.voisins = new List<Noeud>();
        }

        public int Numero
        {get { return numero; }}

        public List<Noeud> Voisins 
        { get { return voisins; } }

        public void AjouterVoisins(Noeud voisin)
        {
            if (!Voisins.Contains(voisin)){
                Voisins.Add(voisin);
            }
        }

        public string toString()
        {
            return "Membre "+this.numero;
        }
    }
}
