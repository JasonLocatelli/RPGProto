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

        // Liste de l'équipe du joueur
        List<Personnage> listeEquipe = new List<Personnage>();
        
        // Liste de l'équipe adverse
        List<Monstre> listeMonstres = new List<Monstre>();
       
        List<Label> listeLabelMonstre = new List<Label>();
        List<string> listeNomMonstres = new List<string>();
        List<PictureBox> listePictureBoxMonstre = new List<PictureBox>();
        List<Panel> listePanelEquipe = new List<Panel>();
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
        public Combat(int zone,Joueur joueur, List<Personnage> listeEquipe, List<Monstre> listeMonstres)
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
            this.listeEquipe = listeEquipe;
            this.listeMonstres = listeMonstres;
            str_directory = Environment.CurrentDirectory.ToString();
            parent = System.IO.Directory.GetParent(str_directory).FullName;
            this.axWindowsMediaPlayerCombat.settings.playCount = 1000;
            this.axWindowsMediaPlayerCombat.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayerCombat_PlayStateChange);
            axWindowsMediaPlayerCombat.URL = parent + @"\Musics\battle.wav";

            listePanelEquipe.Add(pnHeros2);
            listePanelEquipe.Add(pnHeros3);
            listePanelEquipe.Add(pnHeros4);

            listePictureBoxMonstre.Add(pbMonstre1);
            listePictureBoxMonstre.Add(pbMonstre2);
            listePictureBoxMonstre.Add(pbMonstre3);
            listePictureBoxMonstre.Add(pbMonstre4);
            listePictureBoxMonstre.Add(pbMonstre5);
            listePictureBoxMonstre.Add(pbMonstre6);
            listePictureBoxMonstre.Add(pbMonstre7);

            lbMonstre1.Text = "";
            lbMonstre2.Text = "";
            lbMonstre3.Text = "";
            lbMonstre4.Text = "";
            lbMonstre5.Text = "";
            lbMonstre6.Text = "";
            lbMonstre7.Text = "";

            listeLabelMonstre.Add(lbMonstre1);
            listeLabelMonstre.Add(lbMonstre2);
            listeLabelMonstre.Add(lbMonstre3);
            listeLabelMonstre.Add(lbMonstre4);
            listeLabelMonstre.Add(lbMonstre5);
            listeLabelMonstre.Add(lbMonstre6);
            listeLabelMonstre.Add(lbMonstre7);

            // Mise en place des lettres si il y a plusieurs Monstres
            listeLettres = new List<char>() {'A','B','C','D','E','F','G'};
            int nbMonstresTrouvee = 0;
            string nomInitial = "";
            
            for (int i = 0; i < listeMonstres.Count; i++)
            {
                nomInitial = listeMonstres[i].Nom;
                for(int y = 0; y < listeMonstres.Count; y++)
                {
                    if(nomInitial == listeMonstres[y].Nom)
                    {
                        nbMonstresTrouvee++;
                    }
                }
                Console.WriteLine("Il y a : " + nbMonstresTrouvee + " " + nomInitial);
                int compteur = 0;
                for(int y=0; y < listeMonstres.Count; y++)
                {
                    if (nomInitial == listeMonstres[y].Nom && nbMonstresTrouvee > 1)
                    {
                        listeMonstres[y].Nom += " " + listeLettres[compteur];
                        compteur++;
                    }
                }
                nbMonstresTrouvee = 0;
            }


            // Arrière plan combat
            this.BackgroundImage = Image.FromFile(parent + @"\Sprites\Combat\foret1.png");

            for(int i=0; i < listeMonstres.Count; i++) {
                listePictureBoxMonstre[i].Visible = true;
            }

            foreach (Personnage unHero in listeEquipe)
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
            //listeEquipe[0].SonTour = true;
            joueur.SonTour = true;
            
           
            //tlpMonstres.Controls.Add(pbMonstre1, rnd.Next(tlpMonstres.ColumnCount), 0);

            if (listeEquipe.Count == 1)
            {
                pnHeros2.Visible = false;
                pnHeros3.Visible = false;
                pnHeros4.Visible = false;
            }
            if (listeEquipe.Count == 2)
            {
                pnHeros3.Visible = false;
                pnHeros4.Visible = false;
            }

            if (listeEquipe.Count == 3)
            {
                pnHeros4.Visible = false;
            }
            
            foreach (Monstre unMonstre in listeMonstres)
            {
                
                tlpMonstres.Controls.Add(pbMonstre1, rnd.Next(tlpMonstres.ColumnCount), 0);
                foreach (Label unLabelMonstre in listeLabelMonstre)
                {
                    unLabelMonstre.Text = unMonstre.Nom;
                }
                postText += unMonstre.Nom + " apparaît ! \n";
                //lbTxtCombat.Text += unMonstre.Nom+" apparaît ! \n";
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
                    int selectIntMenuMax = listeMonstres.Count;

                    for(int i=1; i <= selectIntMenuMax; i++)
                    {
                        if(selectIntMenu == i)
                        {
                            selectMenuActions3 = listeMonstres[i - 1].Nom;
                        }
                    }
                    /*
                    if (selectIntMenu == 1)
                    {
                        selectMenuActions3 = listeMonstres[0].Nom;
                    }
                    else if (selectIntMenu == 2)
                    {
                        selectMenuActions3 = listeMonstres[1].Nom;
                    }
                    else if (selectIntMenu == 3)
                    {
                        selectMenuActions3 = listeMonstres[2].Nom;
                    }
                    else if (selectIntMenu == 4)
                    {
                        selectMenuActions3 = listeMonstres[3].Nom;
                    }
                    else if (selectIntMenu == 5)
                    {
                        selectMenuActions3 = listeMonstres[4].Nom;
                    }
                    else if (selectIntMenu == 6)
                    {
                        selectMenuActions3 = listeMonstres[5].Nom;
                    }
                    else if (selectIntMenu == 7)
                    {
                        selectMenuActions3 = listeMonstres[6].Nom;
                    }
                    */


                    for(int i=0; i< selectIntMenuMax; i++)
                    {
                        if (selectMenuActions3 == listeMonstres[i].Nom)
                        {

                            listePictureBoxMonstre[i].BackColor = Color.DimGray;
                            listeLabelMonstre[i].Text = "> " + listeMonstres[i].Nom;
                        }
                        else
                        {
                            listePictureBoxMonstre[i].BackColor = Color.Transparent;
                            listeLabelMonstre[i].Text = listeMonstres[i].Nom;
                        }
                    }

                    for(int j= listeMonstres.Count; j<listeLabelMonstre.Count; j++)
                    {
                        listeLabelMonstre[j].Text = "";
                    }

                    /*
                    if (selectMenuActions3 == listeMonstres[0].Nom)
                    {

                        listeLabelMonstre[0].Text = "> " + listeMonstres[0].Nom;
                    }
                    else
                    {
                        listeLabelMonstre[0].Text = listeMonstres[0].Nom;
                    }

                    if (selectMenuActions3 == listeMonstres[1].Nom)
                    {

                        listeLabelMonstre[1].Text = "> " + listeMonstres[1].Nom;
                    }
                    else
                    {
                        listeLabelMonstre[1].Text = listeMonstres[1].Nom;
                    }

                    */
                    if (selectIntMenu <= 0)
                    {
                        selectIntMenu = listeMonstres.Count;
                    }
                    else if (selectIntMenu >= listeMonstres.Count+1)
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

                        foreach (Personnage unHero in listeEquipe)
                        {
                            foreach (Panel unPanelHero in listePanelEquipe)
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
                            pnMonstre.Visible = true;
                            tpnMonstre.Visible = true;
                            activeSelectMenu2 = false;
                            activeSelectMenu3 = true;

                        }
                    }

                    if (activeSelectMenu3 == true)
                    {
                        // Parcours des Monstres
                        for (int i = 0; i < listeMonstres.Count; i++)
                        {
                            if (selectMenuActions3 == listeMonstres[i].Nom)
                            {
                                if (joueur.SonTour == true)
                                {
                                   // joueur.AttaquePhysique(listeMonstres[i]);

                                   // Memorise l'action du joueur
                                    joueur.ListeActions.Add("attaqueP", listeMonstres[i].Nom);
                                    Console.WriteLine("Le joueur "+joueur.Nom+" prévoit une attaque physique");
                                   
                                    // Passe son tour
                                    if(listeEquipe.Count > 0)
                                    {
                                        listeEquipe[0].SonTour = true;
                                    }
                                    joueur.SonTour = false;

                                    // controle menu attaquer
                                    activeSelectMenu1 = true;
                                    activeSelectMenu2 = false;
                                    activeSelectMenu3 = false;

                                    pnCombattre.Visible = false;
                                    pnMonstre.Visible = false;
                                    tpnMonstre.Visible = false;
                                    selectMenuActions2 = "";
                                    selectMenuActions1 = "";
                                    selectMenuActions3 = "";

                                }
                                else
                                {

                                    for(int y=0; y < listeEquipe.Count;y++){
                                        if(listeEquipe[y].SonTour == true)
                                        {
                                            // listeEquipe[y].AttaquePhysique(listeMonstres[i]);
                                            // mémorise l'action du héros
                                            listeEquipe[y].ListeActions.Add("attaque", listeMonstres[i].Nom);
                                            Console.WriteLine("Le joueur " + listeEquipe[y].Nom + " prévoit une attaque physique");

                                            // Passe son tour
                                            // avec 1 heros
                                            if (listeEquipe.Count == 1)
                                            {
                                                // passe le tour aux Monstres
                                                Console.WriteLine("Passe tour aux Monstres");
                                            }
                                            // avec 2 heros
                                            else if (listeEquipe.Count == 2)
                                            {
                                                if(y == 0)
                                                {
                                                    // passe le tour au heros suivant
                                                    listeEquipe[1].SonTour = true;
                                                }
                                                else if(y == 1)
                                                {
                                                    // passe le tour aux Monstres
                                                    Console.WriteLine("Passe tour aux Monstres");
                                                }
                                            }

                                            // avec 3 heros
                                            else if (listeEquipe.Count == 3)
                                            {
                                                if (y == 0)
                                                {
                                                    // passe le tour au heros suivant
                                                    listeEquipe[1].SonTour = true;
                                                }
                                                else if (y == 1)
                                                {
                                                    // passe le tour au heros suivant
                                                    listeEquipe[2].SonTour = true;

                                                }
                                                else if(y == 2)
                                                {
                                                    // passe le tour aux Monstres
                                                    Console.WriteLine("Passe tour aux Monstres");
                                                }
                                            }
                                            listeEquipe[y].SonTour = false;
                                        }
                                    }
                                
                                    // controle menu attaquer
                                    activeSelectMenu1 = false;
                                    activeSelectMenu2 = false;
                                    activeSelectMenu3 = false;

                                    pnActions.Visible = false;
                                    pnCombattre.Visible = false;
                                    pnMonstre.Visible = false;
                                    tpnMonstre.Visible = false;
                                    selectMenuActions2 = "";
                                    selectMenuActions3 = "";
                                    selectMenuActions1 = "";
                                }
                            }
                           
                        }
                    }
                }

            }

            // Controle de l'interface
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

        // Mise en place de l'IA
        void MemoriseActionIA()
        {
            Random rnd = new Random();
            foreach (Monstre unMonstre in listeMonstres)
            {
               // unMonstre.ListeActions.Add("attaque")
            }
        }
    }
}
