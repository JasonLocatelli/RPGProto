using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace RPGProto
{
    class Map : Form
    {
        private string nomMap;
        private int[][] map;
        private List<string> imgDecor;
        private int tileWidth;
        private int tileHeight;
        private int nbTile;
        private List<PictureBox> listesTiles;

        public Map(string nomMap, int[][] map, List<string> imgDecor, int tileWidth, int tileHeight)
        {
            this.nomMap = nomMap;
            this.map = map;
            this.imgDecor = imgDecor;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            listesTiles = new List<PictureBox>();
   
        }

        public string NomMap { get => nomMap; set => nomMap = value; }
        public int[][] MapTiles { get => map; set => map = value; }
        public List<string> ImgDecor { get => imgDecor; set => imgDecor = value; }
        public int TileWidth { get => tileWidth; set => tileWidth = value; }
        public int TileHeight { get => tileHeight; set => tileHeight = value; }
        public int NbTile { get => nbTile; set => nbTile = value; }
        public List<PictureBox> ListesTiles { get => listesTiles; set => listesTiles = value; }

        PictureBox tilesMap;
        public void Draw(int nbLignes, int nbColonnes)
        {
          
            for (int x = 0; x < nbColonnes; x++)
            {
                for (int y = 0; y < nbLignes; y++)
                {
                    tilesMap = new PictureBox
                    {
                        Name = nomMap,
                        Size = new Size(tileWidth, tileHeight),
                        Location = new Point(x * tileWidth, y * tileHeight),
                        Image = Image.FromFile(imgDecor[map[y][x]]),
                    };
                    listesTiles.Add(tilesMap);
                }
            }
        }

        public PictureBox[] addControl(PictureBox[] tilesMap)
        {
            return tilesMap;
        }
    }
}
