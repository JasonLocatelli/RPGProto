using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RPGProto
{
    public class Monstre : Sprite
    {
        private string nom;
        private string villeNatale;
        private DateTime dateNaissance;

        private PictureBox spriteCombat;

        private string race;
        private string classe;
        private bool sonTour;
        private Dictionary<string, string> listeActions;
        private int niveau;
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

        public Monstre(string nomSprite, int width, int height, int x, int y, string path) : base(nomSprite, width, height, x, y, path)
        {
            equipements = new List<Objet>();
            listeActions = new Dictionary<string, string>();

        }



        public bool SonTour { get => sonTour; set => sonTour = value; }
        public string Nom { get => nom; set => nom = value; }
        public string VilleNatale { get => villeNatale; set => villeNatale = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public int Niveau { get => niveau; set => niveau = value; }
        public int Vie { get => vie; set => vie = value; }
        public int Defense { get => defense; set => defense = value; }
        public List<Objet> Equipements { get => equipements; set => equipements = value; }
        public int Force { get => force; set => force = value; }
        public int Agilite { get => agilite; set => agilite = value; }
        public int Dexterite { get => dexterite; set => dexterite = value; }
        public int PointSort { get => pointSort; set => pointSort = value; }
        public int MaxVie { get => maxVie; set => maxVie = value; }
        public int MaxMP { get => maxMP; set => maxMP = value; }
        public Dictionary<string, string> ListeActions { get => listeActions; set => listeActions = value; }
        internal List<Objet> Inventaire { get => inventaire; set => inventaire = value; }
    }
  
}
