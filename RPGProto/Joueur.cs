using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace RPGProto
{
    public class Joueur : Personnage
    {

        public Joueur(string nomSprite, int width, int height, int x, int y, string path) : base(nomSprite, width, height, x, y, path)
        {


        }
        
        public void Deplacement(int[][] map, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (map[Y][X + 1] == 0)
                {
                    X += 1;
                    SpriteBox.Location = new Point((X) * Height, SpriteBox.Location.Y);

                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (map[Y][X - 1] == 0)
                {
                    X -= 1;
                    SpriteBox.Location = new Point((X) * Height, SpriteBox.Location.Y);
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (map[Y - 1][X] == 0)
                {
                    Y -= 1;
                    SpriteBox.Location = new Point(SpriteBox.Location.X, (Y) * Height);
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (map[Y + 1][X] == 0)
                {
                    Y += 1;
                    SpriteBox.Location = new Point(SpriteBox.Location.X, (Y) * Height);
                }
            }
        }

        public void ObjetCollision(int[][] mapObjet, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (mapObjet[Y][X + 1] == 1)
                {
                    Console.WriteLine("TELEPORTATIONNNNN");
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (mapObjet[Y][X - 1] == 1)
                {
                    Console.WriteLine("TELEPORTATIONNNNN");
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (mapObjet[Y - 1][X] == 1)
                {
                    Console.WriteLine("TELEPORTATIONNNNN");

                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (mapObjet[Y + 1][X] == 1)
                {
                    Console.WriteLine("TELEPORTATIONNNNN");
                }
            }
        }
    }
}
