using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace RPGProto
{
    public class Joueur : Sprite
    {

        private string nom;
        private string villeNatale;
        private DateTime dateNaissance;
        private string iconeCombat;

        private string race;
        private string classe;
        private bool sonTour;
        private Dictionary<string, string> listeActions;

        private int niveau;
        private int experience;

        private int vie;
        private int pointSort;
        private int defense;

        private int maxVie;
        private int maxMP;

        private List<Objet> equipements;

        private int force;
        private int agilite;
        private int dexterite;

        private List<Objet> inventaire;

        public Joueur(string nomSprite, int width, int height, int x, int y, string path) : base(nomSprite, width, height, x, y, path)
        {
            equipements = new List<Objet>();
            listeActions = new Dictionary<string, string>();


        }

        public bool SonTour { get => sonTour; set => sonTour = value; }
        public string Nom { get => nom; set => nom = value; }
        public string VilleNatale { get => villeNatale; set => villeNatale = value; }
        public string Race { get => race; set => race = value; }
        public string Classe { get => classe; set => classe = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public int Niveau { get => niveau; set => niveau = value; }
        public int Vie { get => vie; set => vie = value; }
        public int Defense { get => defense; set => defense = value; }
        public List<Objet> Equipements { get => equipements; set => equipements = value; }
        public int Force { get => force; set => force = value; }
        public int Agilite { get => agilite; set => agilite = value; }
        public int Dexterite { get => dexterite; set => dexterite = value; }
        public List<Objet> Inventaire { get => inventaire; set => inventaire = value; }
        public string IconeCombat { get => iconeCombat; set => iconeCombat = value; }
        public int PointSort { get => pointSort; set => pointSort = value; }
        public int MaxVie { get => maxVie; set => maxVie = value; }
        public int MaxMP { get => maxMP; set => maxMP = value; }
        public int Experience { get => experience; set => experience = value; }
        public Dictionary<string, string> ListeActions { get => listeActions; set => listeActions = value; }

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
        public void AttaquePhysique(Ennemi unEnnemi)
        {
            int pointAttaque = force - unEnnemi.Defense;
            unEnnemi.Vie -= pointAttaque;
            Console.WriteLine("L'ennemi "+unEnnemi.Nom+" perd "+pointAttaque+" de damage.");
        }
    }
}
