using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RPGProto
{

    public class Monstre : Personnage
    {

        int positionPb;
        public Monstre()
        {
            TypePersonnage = "monstre";
        }

        public Monstre(string nomSprite, int width, int height, int x, int y, string path) : base(nomSprite, width, height, x, y, path)
        {
            TypePersonnage = "monstre";

        }

        public int PositionPb { get => positionPb; set => positionPb = value; }
    }
  
}
