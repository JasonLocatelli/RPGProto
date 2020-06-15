using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGProto
{
    public class Heros : Personnage
    {
        public Heros()
        {
            TypePersonnage = "heros";
        }

        public Heros(string nomSprite, int width, int height, int x, int y, string path) : base(nomSprite, width, height, x, y, path)
        {
            TypePersonnage = "heros";
        }
    }
}
