using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace RPGProto
{
    public partial class Combat : Form
    {
        // Nombre aléatoire
        Random rnd = new Random();

        // Chemin dossier
        string str_directory;
        string parent;

        Joueur joueur;
        string postText;
        private System.Windows.Forms.Timer timer1;
        private int counter = 1;
        int compteurCara;

        List<Heros> listeHeros = new List<Heros>();
        List<Ennemi> listeEnnemis = new List<Ennemi>();
        List<Label> listeLabelEnnemi = new List<Label>();
        List<string> listeNomEnnemis = new List<string>();
        List<PictureBox> listePictureBoxEnnemi = new List<PictureBox>();
        List<Panel> listePanelHeros = new List<Panel>();
        List<char> listeLettres = new List<char>();
        List<char> cara = new List<char>();

        private bool passeDialogue;
        private bool combat;
        private bool dialogue;
        private bool actionsJoueur;

        private string selectMenuActions1 = "";
        private int selectIntMenu = 1;
        private bool activeSelectMenu1 = true;

        private string selectMenuActions2 = "";
        private bool activeSelectMenu2 = false;

        private string selectMenuActions3 = "";
        private bool activeSelectMenu3 = false;

        private bool selectionner = false;
        int compteur;
        public Combat(int zone,Joueur joueur, List<Heros> listeHeros, List<Ennemi> listeEnnemis)
        {
            InitializeComponent();

            combat = false;
            dialogue = true;
            actionsJoueur = false;

            // TIMER
            timerCombat = new System.Windows.Forms.Timer();
            timerCombat.Tick += new EventHandler(timerCombat_Tick);
            timerCombat.Interval = 50; // 1 second
            timerCombat.Start();
            
            this.joueur = joueur;
            this.listeHeros = listeHeros;
            this.listeEnnemis = listeEnnemis;
            str_directory = Environment.CurrentDirectory.ToString();
            parent = System.IO.Directory.GetParent(str_directory).FullName;
            this.axWindowsMediaPlayerCombat.settings.playCount = 1000;
            this.axWindowsMediaPlayerCombat.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayerCombat_PlayStateChange);
            axWindowsMediaPlayerCombat.URL = parent + @"\Musics\battle.wav";

            listePanelHeros.Add(pnHeros2);
            listePanelHeros.Add(pnHeros3);
            listePanelHeros.Add(pnHeros4);

            listePictureBoxEnnemi.Add(pbEnnemi1);
            listePictureBoxEnnemi.Add(pbEnnemi2);
            listePictureBoxEnnemi.Add(pbEnnemi3);
            listePictureBoxEnnemi.Add(pbEnnemi4);
            listePictureBoxEnnemi.Add(pbEnnemi5);
            listePictureBoxEnnemi.Add(pbEnnemi6);
            listePictureBoxEnnemi.Add(pbEnnemi7);

            lbEnnemi1.Text = "";
            lbEnnemi2.Text = "";
            lbEnnemi3.Text = "";
            lbEnnemi4.Text = "";
            lbEnnemi5.Text = "";
            lbEnnemi6.Text = "";
            lbEnnemi7.Text = "";

            listeLabelEnnemi.Add(lbEnnemi1);
            listeLabelEnnemi.Add(lbEnnemi2);
            listeLabelEnnemi.Add(lbEnnemi3);
            listeLabelEnnemi.Add(lbEnnemi4);
            listeLabelEnnemi.Add(lbEnnemi5);
            listeLabelEnnemi.Add(lbEnnemi6);
            listeLabelEnnemi.Add(lbEnnemi7);

            // Mise en place des lettres si il y a plusieurs ennemis
            listeLettres = new List<char>() {'A','B','C','D','E','F','G'};
            int nbEnnemisTrouvee = 0;
            string nomInitial = "";
            
            for (int i = 0; i < listeEnnemis.Count; i++)
            {
                nomInitial = listeEnnemis[i].Nom;
                for(int y = 0; y < listeEnnemis.Count; y++)
                {
                    if(nomInitial == listeEnnemis[y].Nom)
                    {
                        nbEnnemisTrouvee++;
                    }
                }
                Console.WriteLine("Il y a : " + nbEnnemisTrouvee + " " + nomInitial);
                int compteur = 0;
                for(int y=0; y < listeEnnemis.Count; y++)
                {
                    if (nomInitial == listeEnnemis[y].Nom && nbEnnemisTrouvee > 1)
                    {
                        listeEnnemis[y].Nom += " " + listeLettres[compteur];
                        compteur++;
                    }
                }
                nbEnnemisTrouvee = 0;
            }


            // Arrière plan combat
            this.BackgroundImage = Image.FromFile(parent + @"\Sprites\Combat\foret1.png");

            for(int i=0; i < listeEnnemis.Count; i++) {
                listePictureBoxEnnemi[i].Visible = true;
            }

            foreach (Heros unHero in listeHeros)
            {
                Console.WriteLine(unHero.Nom+" vous aide dans le combat");
                lbHerosName2.Text = unHero.Nom;
                pbHeros2.Image = RPGProto.Properties.Resources.archer;
                lbAfficheHPheros2.Text = Convert.ToString(unHero.Vie) + " / " + Convert.ToString(unHero.MaxVie);
                lbAfficheMPheros2.Text = Convert.ToString(unHero.PointSort) + " / " + Convert.ToString(unHero.MaxMP);
                lbAfficheLVLheros2.Text = Convert.ToString(unHero.Niveau);
            }
        }

        private void axWindowsMediaPlayerCombat_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

        }

        private void Combat_Load(object sender, EventArgs e)
        {
            Control grillLayout = tlpHeros.GetControlFromPosition(5, 0);
            lbHerosName1.Text = joueur.Nom;
            pbHeros1.Image = RPGProto.Properties.Resources.knight1;
            Console.WriteLine(pbHeros1.ImageLocation);
            lbAfficheHPheros1.Text = Convert.ToString(joueur.Vie)+" / "+Convert.ToString(joueur.MaxVie);
            lbAfficheMPheros1.Text = Convert.ToString(joueur.PointSort) + " / " + Convert.ToString(joueur.MaxMP);
            lbAfficheLVLheros1.Text = Convert.ToString(joueur.Niveau);
            //listeHeros[0].SonTour = true;
            joueur.SonTour = true;
            
           
            //tlpEnnemis.Controls.Add(pbEnnemi1, rnd.Next(tlpEnnemis.ColumnCount), 0);

            if (listeHeros.Count == 0)
            {
                pnHeros2.Visible = false;
                pnHeros3.Visible = false;
                pnHeros4.Visible = false;
            }
            if (listeHeros.Count == 1)
            {
                pnHeros3.Visible = false;
                pnHeros4.Visible = false;
            }

            if (listeHeros.Count == 2)
            {
                pnHeros4.Visible = false;
            }
            
            foreach (Ennemi unEnnemi in listeEnnemis)
            {
                
                tlpEnnemis.Controls.Add(pbEnnemi1, rnd.Next(tlpEnnemis.ColumnCount), 0);
                foreach (Label unLabelEnnemi in listeLabelEnnemi)
                {
                    unLabelEnnemi.Text = unEnnemi.Nom;
                }
                postText += unEnnemi.Nom + " apparaît ! \n";
                //lbTxtCombat.Text += unEnnemi.Nom+" apparaît ! \n";
            }
            compteurCara = 0;
            cara = new List<char>(postText.ToCharArray());
        }

        private void timerCombat_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                if (lbTxtDialogue.Visible == true)
                {
                    
                    //defilement du dialogue a partir de post Text
                    if (lbTxtDialogue.Text != postText)
                    {
                        lbTxtDialogue.Text += cara[compteurCara];
                        compteurCara++;
                        counter = 1;
                    }
                    /////////////////////////////////////////////
                }
            }

            // Si le joueur peut passer le dialogue ou pas
            if (lbTxtDialogue.Text == postText)
            {
                passeDialogue = true;
            }
            else
            {
                passeDialogue = false;
            }
            /////////////////////////////////////////////

            // Affichage du dialogue et des actions
            // Dialogue qui s'affiche
            if(dialogue == true && combat == false)
            {
                lbTxtDialogue.Visible = true;
                dialogueFleche.Visible = true;

                pnActions.Visible = false;
                tpnActions.Visible = false;
            }
            // Combat 
            else
            {
                lbTxtDialogue.Visible = false;
                dialogueFleche.Visible = false;
                pnActions.Visible = true;
                tpnActions.Visible = true;

                // Menu1 selection
                if (activeSelectMenu1 == true)
                {
                    if (selectIntMenu == 1)
                    {
                        selectMenuActions1 = "combattre";
                    }
                    else if (selectIntMenu == 2)
                    {
                        selectMenuActions1 = "fuir";
                    }
                    else if (selectIntMenu == 3)
                    {
                        selectMenuActions1 = "intimider";
                    }
                    else if (selectIntMenu == 4)
                    {
                        selectMenuActions1 = "tactique";
                    }

                    if (selectMenuActions1 == "combattre")
                    {
                        lbCombattre.Text = "> Combattre";
                        lbFuir.Text = "Fuir";
                        lbIntimider.Text = "Intimider";
                        lbTactique.Text = "Tactique";

                    }
                    else if (selectMenuActions1 == "fuir")
                    {
                        lbCombattre.Text = "Combattre";
                        lbFuir.Text = "> Fuir";
                        lbIntimider.Text = "Intimider";
                        lbTactique.Text = "Tactique";
                    }
                    else if (selectMenuActions1 == "intimider")
                    {
                        lbCombattre.Text = "Combattre";
                        lbFuir.Text = "Fuir";
                        lbIntimider.Text = "> Intimider";
                        lbTactique.Text = "Tactique";
                    }
                    else if (selectMenuActions1 == "tactique")
                    {
                        lbCombattre.Text = "Combattre";
                        lbFuir.Text = "Fuir";
                        lbIntimider.Text = "Intimider";
                        lbTactique.Text = "> Tactique";
                    }

                    if (selectIntMenu <= 0)
                    {
                        selectIntMenu = 4;
                    }
                    else if (selectIntMenu >= 5)
                    {
                        selectIntMenu = 1;
                    }
                }

                // Menu Actions
                if (activeSelectMenu2 == true)
                {
                    if (selectIntMenu == 1)
                    {
                        selectMenuActions2 = "attaquer";
                    }
                    else if (selectIntMenu == 2)
                    {
                        selectMenuActions2 = "sorts";
                    }
                    else if (selectIntMenu == 3)
                    {
                        selectMenuActions2 = "defense";
                    }
                    else if (selectIntMenu == 4)
                    {
                        selectMenuActions2 = "aptitudes";
                    }
                    else if (selectIntMenu == 5)
                    {
                        selectMenuActions2 = "objets";
                    }
                    else if (selectIntMenu == 6)
                    {
                        selectMenuActions2 = "tension";
                    }

                    if (selectMenuActions2 == "attaquer")
                    {
                        lbAttaquer.Text = "> Attaquer";
                        lbSorts.Text = "Sorts";
                        lbDefense.Text = "Défense";
                        lbAptitudes.Text = "Aptitudes";
                        lbObjets.Text = "Objets";
                        lbTension.Text = "Tension";
                    }
                    else if (selectMenuActions2 == "sorts")
                    {
                        lbAttaquer.Text = "Attaquer";
                        lbSorts.Text = "> Sorts";
                        lbDefense.Text = "Défense";
                        lbAptitudes.Text = "Aptitudes";
                        lbObjets.Text = "Objets";
                        lbTension.Text = "Tension";
                    }
                    else if (selectMenuActions2 == "defense")
                    {
                        lbAttaquer.Text = "Attaquer";
                        lbSorts.Text = "Sorts";
                        lbDefense.Text = "> Défense";
                        lbAptitudes.Text = "Aptitudes";
                        lbObjets.Text = "Objets";
                        lbTension.Text = "Tension";
                    }
                    else if (selectMenuActions2 == "aptitudes")
                    {
                        lbAttaquer.Text = "Attaquer";
                        lbSorts.Text = "Sorts";
                        lbDefense.Text = "Défense";
                        lbAptitudes.Text = "> Aptitudes";
                        lbObjets.Text = "Objets";
                        lbTension.Text = "Tension";
                    }
                    else if (selectMenuActions2 == "objets")
                    {
                        lbAttaquer.Text = "Attaquer";
                        lbSorts.Text = "Sorts";
                        lbDefense.Text = "Défense";
                        lbAptitudes.Text = "Aptitudes";
                        lbObjets.Text = "> Objets";
                        lbTension.Text = "Tension";
                    }
                    else if (selectMenuActions2 == "tension")
                    {
                        lbAttaquer.Text = "Attaquer";
                        lbSorts.Text = "Sorts";
                        lbDefense.Text = "Défense";
                        lbAptitudes.Text = "Aptitudes";
                        lbObjets.Text = "Objets";
                        lbTension.Text = "> Tension";
                    }

                    if (selectIntMenu <= 0)
                    {
                        selectIntMenu = 3;
                    }
                    else if (selectIntMenu >= 7)
                    {
                        selectIntMenu = 4;
                    }
                }

                // Menu1 selection
                if (activeSelectMenu3 == true)
                {
                    int selectIntMenuMax = listeEnnemis.Count;

                    for(int i=1; i <= selectIntMenuMax; i++)
                    {
                        if(selectIntMenu == i)
                        {
                            selectMenuActions3 = listeEnnemis[i - 1].Nom;
                        }
                    }
                    /*
                    if (selectIntMenu == 1)
                    {
                        selectMenuActions3 = listeEnnemis[0].Nom;
                    }
                    else if (selectIntMenu == 2)
                    {
                        selectMenuActions3 = listeEnnemis[1].Nom;
                    }
                    else if (selectIntMenu == 3)
                    {
                        selectMenuActions3 = listeEnnemis[2].Nom;
                    }
                    else if (selectIntMenu == 4)
                    {
                        selectMenuActions3 = listeEnnemis[3].Nom;
                    }
                    else if (selectIntMenu == 5)
                    {
                        selectMenuActions3 = listeEnnemis[4].Nom;
                    }
                    else if (selectIntMenu == 6)
                    {
                        selectMenuActions3 = listeEnnemis[5].Nom;
                    }
                    else if (selectIntMenu == 7)
                    {
                        selectMenuActions3 = listeEnnemis[6].Nom;
                    }
                    */


                    for(int i=0; i< selectIntMenuMax; i++)
                    {
                        if (selectMenuActions3 == listeEnnemis[i].Nom)
                        {

                            listePictureBoxEnnemi[i].BackColor = Color.DimGray;
                            listeLabelEnnemi[i].Text = "> " + listeEnnemis[i].Nom;
                        }
                        else
                        {
                            listePictureBoxEnnemi[i].BackColor = Color.Transparent;
                            listeLabelEnnemi[i].Text = listeEnnemis[i].Nom;
                        }
                    }

                    for(int j= listeEnnemis.Count; j<listeLabelEnnemi.Count; j++)
                    {
                        listeLabelEnnemi[j].Text = "";
                    }

                    /*
                    if (selectMenuActions3 == listeEnnemis[0].Nom)
                    {

                        listeLabelEnnemi[0].Text = "> " + listeEnnemis[0].Nom;
                    }
                    else
                    {
                        listeLabelEnnemi[0].Text = listeEnnemis[0].Nom;
                    }

                    if (selectMenuActions3 == listeEnnemis[1].Nom)
                    {

                        listeLabelEnnemi[1].Text = "> " + listeEnnemis[1].Nom;
                    }
                    else
                    {
                        listeLabelEnnemi[1].Text = listeEnnemis[1].Nom;
                    }

                    */
                    if (selectIntMenu <= 0)
                    {
                        selectIntMenu = listeEnnemis.Count;
                    }
                    else if (selectIntMenu >= listeEnnemis.Count+1)
                    {
                        selectIntMenu = 1;
                    }
                }

                if (selectionner == true)
                {
                    if (joueur.SonTour)
                    {
                        pnHeros1.BackColor = Color.DimGray;
                    }
                    else
                    {
                        pnHeros1.BackColor = Color.Black;

                        foreach (Heros unHero in listeHeros)
                        {
                            foreach (Panel unPanelHero in listePanelHeros)
                            {
                                if (unHero.SonTour)
                                {
                                    unPanelHero.BackColor = Color.DimGray;
                                }
                                else
                                {
                                    unPanelHero.BackColor = Color.Black;
                                }
                            }
                        }

                    }
                }
            }
            /////////////////////////////////////////////
            
                
        }

        private void Combat_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (passeDialogue == true)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
                    player.Play();
                    dialogue = false;
                    combat = true;
                    passeDialogue = false;
                }

                if (combat == true)
                {
                    if (activeSelectMenu1 == true)
                    {
                        if (selectMenuActions1 == "fuir")
                        {
                            Form jeu = new Jeu(joueur.Nom, joueur.Race, joueur.Classe, joueur.X, joueur.Y);
                            Form.ActiveForm.Close();
                            jeu.Show();

                        }
                        else if (selectMenuActions1 == "combattre")
                        {
                            pnCombattre.Visible = true;
                            lbheroSelect.Text = joueur.Nom;
                            selectionner = true;
                            activeSelectMenu1 = false;
                            activeSelectMenu2 = true;
                            activeSelectMenu3 = false;
                        }
                    }

                    if (activeSelectMenu2 == true)
                    {
                        if (selectMenuActions2 == "")
                        {
                            

                        }
                        else if (selectMenuActions2 == "attaquer")
                        {
                            pnEnnemi.Visible = true;
                            tpnEnnemi.Visible = true;
                            activeSelectMenu2 = false;
                            activeSelectMenu3 = true;

                        }
                    }

                    if (activeSelectMenu3 == true)
                    {
                        for (int i = 0; i < listeEnnemis.Count; i++)
                        {
                            if (selectMenuActions3 == listeEnnemis[i].Nom)
                            {
                                if (joueur.SonTour == true)
                                {
                                   // joueur.AttaquePhysique(listeEnnemis[i]);

                                   // memorise l'action du joueur
                                    joueur.ListeActions.Add("attaque", listeEnnemis[i].Nom);

                                    // Passe son tour
                                    if(listeHeros.Count > 0)
                                    {
                                        listeHeros[0].SonTour = true;
                                    }
                                    joueur.SonTour = false;

                                    // controle menu attaquer
                                    activeSelectMenu1 = true;
                                    activeSelectMenu2 = false;
                                    activeSelectMenu3 = false;

                                    pnCombattre.Visible = false;
                                    pnEnnemi.Visible = false;
                                    tpnEnnemi.Visible = false;
                                    selectMenuActions2 = "";
                                    selectMenuActions1 = "";
                                    selectMenuActions3 = "";

                                }
                                else
                                {

                                    for(int y=0; y < listeHeros.Count;y++){
                                        if(listeHeros[y].SonTour == true)
                                        {
                                            // listeHeros[y].AttaquePhysique(listeEnnemis[i]);
                                            // mémorise l'action du héros
                                            listeHeros[y].ListeActions.Add("attaque", listeEnnemis[i].Nom);

                                            // Passe son tour
                                            // avec 1 heros
                                            if(listeHeros.Count == 1)
                                            {
                                                // passe le tour aux ennemis
                                                Console.WriteLine("Passe tour aux ennemis");
                                            }
                                            // avec 2 heros
                                            else if (listeHeros.Count == 2)
                                            {
                                                if(y == 0)
                                                {
                                                    // passe le tour au heros suivant
                                                    listeHeros[1].SonTour = true;
                                                }
                                                else if(y == 1)
                                                {
                                                    // passe le tour aux ennemis
                                                    Console.WriteLine("Passe tour aux ennemis");
                                                }
                                            }

                                            // avec 3 heros
                                            else if (listeHeros.Count == 3)
                                            {
                                                if (y == 0)
                                                {
                                                    // passe le tour au heros suivant
                                                    listeHeros[1].SonTour = true;
                                                }
                                                else if (y == 1)
                                                {
                                                    // passe le tour au heros suivant
                                                    listeHeros[2].SonTour = true;

                                                }
                                                else if(y == 2)
                                                {
                                                    // passe le tour aux ennemis
                                                    Console.WriteLine("Passe tour aux ennemis");
                                                }
                                            }
                                            listeHeros[y].SonTour = false;
                                        }
                                    }
                                
                                    // controle menu attaquer
                                    activeSelectMenu1 = true;
                                    activeSelectMenu2 = false;
                                    activeSelectMenu3 = false;

                                    pnCombattre.Visible = false;
                                    pnEnnemi.Visible = false;
                                    tpnEnnemi.Visible = false;
                                    selectMenuActions2 = "";
                                    selectMenuActions3 = "";
                                    selectMenuActions1 = "";
                                }
                            }
                           
                        }
                    }
                }

            }

            if (combat == true || actionsJoueur == true)
            {
                if (e.KeyCode == Keys.Down)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                    player.Play();
                    selectIntMenu += 1;
          
                }

                if (e.KeyCode == Keys.Right)
                {
                    if (activeSelectMenu2 == true)
                    {
                        if (selectIntMenu == 1)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 4;
                        }
                        else if (selectIntMenu == 2)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 5;
                        }
                        else if (selectIntMenu == 3)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 6;
                        }
                    }
                }

                if(e.KeyCode == Keys.Left)
                {
                    if (activeSelectMenu2 == true)
                    {
                        if (selectIntMenu == 4)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 1;
                        }
                        else if (selectIntMenu == 5)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 2;
                        }
                        else if (selectIntMenu == 6)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 3;
                        }
                    }
                }


                if (e.KeyCode == Keys.Up)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                    player.Play();
                    selectIntMenu -= 1;
                    
                }
            }

        }
    }
}
