using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace RPGProto
{
    public class Sprite
    {
        string str_directory;
        string parent;

        private PictureBox sprite;
        private int height;
        private int width;
        private int x;
        private int y;


        public Sprite(string nomSprite,  int width, int height, int x, int y, string path)
        {
            str_directory = Environment.CurrentDirectory.ToString();
            parent = System.IO.Directory.GetParent(str_directory).FullName;
            this.height = height;
            this.width = width;
            this.x = x;
            this.y = y;

            sprite = new PictureBox
            {
                Name = nomSprite,
                Size = new Size(width, height),
                Location = new Point((x) * width, (y) * height),
                Image = Image.FromFile(parent + @"\Sprites\"+path),

            };

        }


        public int Height { get => height; set => height = value; }
        public int Weight { get => width; set => width = value; }
        public PictureBox SpriteBox { get => sprite; set => sprite = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Str_directory { get => str_directory; set => str_directory = value; }
        public string Parent { get => parent; set => parent = value; }
    }
}
