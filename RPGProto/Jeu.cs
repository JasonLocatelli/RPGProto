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

        List<Personnage> listeEquipe = new List<Personnage>();
        List<Monstre> listeMonstres = new List<Monstre>();
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
                Console.WriteLine("Vous avez "+listeEquipe.Capacity+" heros à votre compagnie");
                Console.WriteLine("Vous avez " + listeMonstres.Capacity + " qui vous attaque");
                Console.WriteLine(joueur.Nom);
                Form combat = new Combat(1,joueur, listeEquipe,listeMonstres);
                
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
            joueur.IconeCombat = @"\Icons\knight.png";

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

            // Ajout d'Monstres
            Monstre Monstre = new Monstre("orc", 16, 16, 1, 2, @"Player\test.png");
            Monstre.Vie = 100;
            Monstre.MaxVie = 100;
            Monstre.Niveau = 100;
            Monstre.Defense = 30;
            Monstre.Force = 4;
            Monstre.Agilite = 2;
            Monstre.Dexterite = 6;
            Monstre.Nom = "Alferd";

            Monstre Monstre2 = new Monstre("poisson", 16, 16, 1, 2, @"Player\test.png");
            Monstre2.Vie = 100;
            Monstre2.MaxVie = 100;
            Monstre2.Niveau = 100;
            Monstre2.Nom = "Abrakadastrak";

            // Ajout d'Monstres
            Monstre Monstre3 = new Monstre("orc", 16, 16, 1, 2, @"Player\test.png");
            Monstre3.Vie = 100;
            Monstre3.MaxVie = 100;
            Monstre3.Niveau = 100;
            Monstre3.Nom = "Alferd";

            joueur.IconeCombat = @"\Icons\knight.png";

            // Ajout du joueur dans l'équipe
            listeEquipe.Add(joueur);
            Console.WriteLine("le joueur "+joueur.Nom+"a été ajouté");

            // Ajout de l'elfe dans l'équipe
            listeEquipe.Add(elfe);
            Console.WriteLine("Un "+elfe.Nom+"a été ajouté.");
            Console.WriteLine("Vous êtes "+listeEquipe.Count+"dans l'équipe.");
            listeMonstres.Add(Monstre);
            listeMonstres.Add(Monstre2);
            listeMonstres.Add(Monstre3);
            this.Controls.Add(joueur.SpriteBox);
            this.Controls.Add(Monstre.SpriteBox);
            
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
