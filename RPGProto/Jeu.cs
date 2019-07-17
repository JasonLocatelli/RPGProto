using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGProto
{
    public partial class Jeu : Form
    {
        string str_directory;
        string parent;
 
        int[][] objet;
        int[][] mapTiles;
        int nbLanceCombat;

        Joueur joueur;
        string nomJoueur;
        string raceJoueur;
        string classeJoueur;
        int joueurX;
        int joueurY;

        bool pause;

        List<Heros> listeHeros = new List<Heros>();
        List<Ennemi> listeEnnemis = new List<Ennemi>();
        PictureBox spriteJoueur;
        Map map;

        public Joueur JoueurObjet { get => joueur; set => joueur = value; }

        public Jeu(string nomJoueur, string raceJoueur, string classeJoueur, int joueurX, int joueurY)
        {
            InitializeComponent();


            // Données joueur
            this.nomJoueur = nomJoueur;
            this.raceJoueur = raceJoueur;
            this.classeJoueur = classeJoueur;
            this.joueurX = joueurX;
            this.joueurY = joueurY;

            // chemin dossier
            str_directory = Environment.CurrentDirectory.ToString();
            parent = System.IO.Directory.GetParent(str_directory).FullName;

            // Réglages musiques
            this.axWindowsMediaPlayerJeu.settings.playCount = 1000;
            this.axWindowsMediaPlayerJeu.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayerJeu_PlayStateChange);
            axWindowsMediaPlayerJeu.URL = parent + @"\Musics\forest.wav";
            axWindowsMediaPlayerJeu.Ctlcontrols.play();
            objet = new int[][] {
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 1, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }
            };
           
        }

        private void Jeu_KeyDown(object sender, KeyEventArgs e)
        {
            nbLanceCombat = genereNblanceCombat(5);
            if (nbLanceCombat == 5)
            {
                axWindowsMediaPlayerJeu.Ctlcontrols.pause();
                Console.WriteLine("Vous avez "+listeHeros.Capacity+" heros à votre compagnie");
                Console.WriteLine("Vous avez " + listeEnnemis.Capacity + " qui vous attaque");
                Console.WriteLine(joueur.Nom);
                Form combat = new Combat(1,joueur, listeHeros,listeEnnemis);
                
                joueur.SonTour = true;
                this.Hide();
                combat.Show();
                Console.WriteLine("Lancement du combat");
            }
            Console.WriteLine(nbLanceCombat);
            joueur.Deplacement(map.MapTiles, sender, e);
            joueur.ObjetCollision(objet, sender, e);

        }

        private void Jeu_Load(object sender, EventArgs e)
        {
            str_directory = Environment.CurrentDirectory.ToString();
            parent = System.IO.Directory.GetParent(str_directory).FullName;
            // Map
            List<string> imgDecor = new List<string>();
            imgDecor.Add(parent + @"\Sprites\sol.png");
            imgDecor.Add(parent + @"\Sprites\mur.png");

            map = new Map("ville", new int[][] {
                new int[] { 0, 0, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 0, 0, 0, 1, 1, 1, 1 },
                new int[] { 1, 0, 1, 0, 0, 0, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }
            }, imgDecor, 32, 32);

            // Génération du joueur
            joueur = new Joueur("Joueur", 32, 32, joueurX, joueurY, @"Player\test.png");
            joueur.Nom = nomJoueur;
            joueur.Race = raceJoueur;
            joueur.Classe = classeJoueur;
            joueur.Vie = 100;
            joueur.MaxVie = 100;
            joueur.Niveau = 100;
            joueur.Force = 50;
            joueur.Agilite = 50;
            joueur.Dexterite = 50;
            
            // Ajout d'un hero
            Elfe elfe = new Elfe("elfe", 16, 16, 1, 1, @"Player\test.png");
            elfe.Vie = 70;
            elfe.MaxVie = 70;
            elfe.Niveau = 100;
            elfe.Defense = 10;
            elfe.Force = 20;
            elfe.Agilite = 70;
            elfe.Dexterite = 40;
            elfe.Nom = "Alferd";
            elfe.IconeCombat = @"\Icons\archer.png";

            // Ajout d'ennemis
            Ennemi ennemi = new Ennemi("orc", 16, 16, 1, 2, @"Player\test.png");
            ennemi.Vie = 100;
            ennemi.MaxVie = 100;
            ennemi.Niveau = 100;
            ennemi.Defense = 30;
            ennemi.Force = 4;
            ennemi.Agilite = 2;
            ennemi.Dexterite = 6;
            ennemi.Nom = "Alferd";

            Ennemi ennemi2 = new Ennemi("poisson", 16, 16, 1, 2, @"Player\test.png");
            ennemi2.Vie = 100;
            ennemi2.MaxVie = 100;
            ennemi2.Niveau = 100;
            ennemi2.Nom = "Abrakadastrak";

            // Ajout d'ennemis
            Ennemi ennemi3 = new Ennemi("orc", 16, 16, 1, 2, @"Player\test.png");
            ennemi3.Vie = 100;
            ennemi3.MaxVie = 100;
            ennemi3.Niveau = 100;
            ennemi3.Nom = "Alferd";

            joueur.IconeCombat = @"\Icons\knight.png";
      
            listeHeros.Add(elfe);
            Console.WriteLine("Un "+elfe.Nom+"a été ajouté");
            Console.WriteLine("Maintenant"+listeHeros.Count);
            listeEnnemis.Add(ennemi);
            listeEnnemis.Add(ennemi2);
            listeEnnemis.Add(ennemi3);
            this.Controls.Add(joueur.SpriteBox);
            this.Controls.Add(ennemi.SpriteBox);
            
            //this.Controls.Add(spriteJoueur);

            map.Draw(4,8);
            foreach(PictureBox unTile in map.ListesTiles)
            {
                this.Controls.Add(unTile);
            }
        }

        private void axWindowsMediaPlayerJeu_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
                this.axWindowsMediaPlayerJeu.Ctlcontrols.play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            map.Draw(4, 8);
            Console.WriteLine("test");
            
        }

        public int genereNblanceCombat(int zone)
        {
            Random rnd = new Random();
            return rnd.Next(10);
        }

        private void axWindowsMediaPlayerJeu_Enter(object sender, EventArgs e)
        {

        }
    }
}
