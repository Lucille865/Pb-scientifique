using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb_scientifique
{
    public class Lien
    {
        public Noeud Noeud1
        {
            get;
        }
        public Noeud Noeud2
        {
            get;
        }

        public Lien (Noeud noeud1, Noeud noeud2)
        {
            Noeud1 = noeud1;
            Noeud2 = noeud2;

            Noeud1.AjouterVoisins(Noeud2);
        }
        public string toString()
        {
            return "Relation " + this;
        }

    }
}
