using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGProto
{
    public class Heros : Personnage
    {


        public Heros(string nomSprite, int width, int height, int x, int y, string path) : base(nomSprite, width, height, x, y, path)
        {
            
        }
        public void AttaquePhysique(Monstre unMonstre)
        {
            int pointAttaque = this.Force - unMonstre.Defense;
            unMonstre.Vie -= pointAttaque;
            Console.WriteLine("L'Monstre " + unMonstre.Nom + " perd " + pointAttaque + " de damage.");
        }
    }
}
