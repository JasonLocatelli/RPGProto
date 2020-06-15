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
        private System.Windows.Forms.Timer timerSound;
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
        List<PictureBox> listePictureBoxEquipe = new List<PictureBox>();
        List<Label> listeNameEquipe = new List<Label>();
        List<Label> listeHPEquipe = new List<Label>();
        List<Label> listeMPEquipe = new List<Label>();
        List<Label> listeLVLEquipe = new List<Label>();
        List<char> listeLettres = new List<char>();
        List<char> cara = new List<char>();

        List<Personnage> listePersonnagesCombat = new List<Personnage>();
        private bool passeDialogue;
        private bool combat;
        private bool dialogue;
        private bool actionsJoueur;

        private bool phaseAction = false;
        private string actionAffichage;
        private int nbPersonnageAction = -1;
        private int nbActions = -1;

        private string selectMenuActions1 = "";
        private int selectIntMenu = 1;
        private bool activeSelectMenu1 = true;

        private string selectMenuActions2 = "";
        private bool activeSelectMenu2 = false;

        private string selectMenuActions3 = "";
        private bool activeSelectMenu3 = false;

        private bool selectionner = false;
        int compteur;

        int selectIntMenuMax;

        int numeroHeros;
        public Combat(int zone,Joueur joueur, List<Personnage> listeEquipe, List<Monstre> listeMonstres)
        {
            InitializeComponent();

            combat = false;
            dialogue = true;
            actionsJoueur = false;

            // TIMER
            timerCombat = new System.Windows.Forms.Timer();
            timerCombat.Tick += new EventHandler(timerCombat_Tick);
            timerCombat.Interval = 20; // 1 second
            timerCombat.Start();

            // TIMER
            timerSonsCombat = new System.Windows.Forms.Timer();
            timerSonsCombat.Tick += new EventHandler(timerSonsCombat_Tick);
            timerSonsCombat.Interval = 800; // 1 second
            timerSonsCombat.Stop();
            numeroHeros = 0;


            nbPersonnageAction = -1;
            nbActions = -1;
            this.joueur = joueur;
            this.listeEquipe = listeEquipe;
            this.listeMonstres = listeMonstres;
            str_directory = Environment.CurrentDirectory.ToString();
            parent = System.IO.Directory.GetParent(str_directory).FullName;
            this.axWindowsMediaPlayerCombat.settings.playCount = 1000;
            this.axWindowsMediaPlayerCombat.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayerCombat_PlayStateChange);
            axWindowsMediaPlayerCombat.URL = parent + @"\Musics\battle.wav";

            listePanelEquipe.Add(pnHeros1);
            listePanelEquipe.Add(pnHeros2);
            listePanelEquipe.Add(pnHeros3);
            listePanelEquipe.Add(pnHeros4);

            listeNameEquipe.Add(lbHerosName1);
            listeNameEquipe.Add(lbHerosName2);
            listeNameEquipe.Add(lbHerosName3);
            listeNameEquipe.Add(lbHerosName4);

            listePictureBoxEquipe.Add(pbHeros1);
            listePictureBoxEquipe.Add(pbHeros2);
            listePictureBoxEquipe.Add(pbHeros3);
            listePictureBoxEquipe.Add(pbHeros4);

            listeHPEquipe.Add(lbAfficheHPheros1);
            listeHPEquipe.Add(lbAfficheHPheros2);
            listeHPEquipe.Add(lbAfficheHPheros3);
            listeHPEquipe.Add(lbAfficheHPheros4);

            listeMPEquipe.Add(lbAfficheMPheros1);
            listeMPEquipe.Add(lbAfficheMPheros2);
            listeMPEquipe.Add(lbAfficheMPheros3);
            listeMPEquipe.Add(lbAfficheMPheros4);

            listeLVLEquipe.Add(lbAfficheLVLheros1);
            listeLVLEquipe.Add(lbAfficheLVLheros2);
            listeLVLEquipe.Add(lbAfficheLVLheros3);
            listeLVLEquipe.Add(lbAfficheLVLheros4);

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


            foreach(Personnage unHeros in listeEquipe)
            {
                listePersonnagesCombat.Add(unHeros);
            }
            foreach (Monstre unMonstre in listeMonstres)
            {

                listePersonnagesCombat.Add(unMonstre);

            }
            foreach (Personnage unPersonnage in listePersonnagesCombat)
            {
                Console.WriteLine(unPersonnage.Dexterite + " " + unPersonnage.Nom);
            }
            
            listePersonnagesCombat.Sort(
                 delegate (Personnage p1, Personnage p2)
                 {
                     return p2.Dexterite.CompareTo(p1.Dexterite);

                 }
              );
              
            foreach (Personnage unPersonnage in listePersonnagesCombat)
            {
                Console.WriteLine(unPersonnage.Dexterite + " " + unPersonnage.Nom);
            }

            foreach (Personnage unPersonnage in listePersonnagesCombat)
            {
                Console.WriteLine(unPersonnage.Agilite);
            }

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
                selectIntMenuMax = listeMonstres.Count;
            }

            // Arrière plan combat
            this.BackgroundImage = Image.FromFile(parent + @"\Sprites\Combat\foret1.png");


            /*
            foreach (Personnage unHero in listeEquipe)
            {
                lbHerosName2.Text = unHero.Nom;
                pbHeros2.Image = Image.FromFile(parent+"\\Icons\\" + unHero.IconeCombat);
                lbAfficheHPheros2.Text = Convert.ToString(unHero.Vie) + " / " + Convert.ToString(unHero.MaxVie);
                lbAfficheMPheros2.Text = Convert.ToString(unHero.PointSort) + " / " + Convert.ToString(unHero.MaxMP);
                lbAfficheLVLheros2.Text = Convert.ToString(unHero.Niveau);
            }
            */
            Console.WriteLine("Votre équipe est consitué de " + listeEquipe.Count+" personnages.");
        }

        private void axWindowsMediaPlayerCombat_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

        }

        private void Combat_Load(object sender, EventArgs e)
        {
            Control grillLayout = tlpHeros.GetControlFromPosition(5, 0);
            //lbHerosName1.Text = joueur.Nom;
            //pbHeros1.Image = Image.FromFile(parent+"\\Icons\\"+joueur.IconeCombat);
           
            Console.WriteLine(pbHeros1.ImageLocation);
            //lbAfficheHPheros1.Text = Convert.ToString(joueur.Vie)+" / "+Convert.ToString(joueur.MaxVie);
            //lbAfficheMPheros1.Text = Convert.ToString(joueur.PointSort) + " / " + Convert.ToString(joueur.MaxMP);
            //lbAfficheLVLheros1.Text = Convert.ToString(joueur.Niveau);
            //listeEquipe[0].SonTour = true;
            listeEquipe[0].SonTour = true;

            foreach (Personnage unHeros in listeEquipe)
            {
                /*
                foreach(Label unNomHeros in listeNameEquipe)
                {
                    unNomHeros.Text = unHeros.Nom;
                    Console.WriteLine(unNomHeros.Text);
                }
                */
                for(int i =0; i < listeEquipe.Count; i++)
                {
                    listeNameEquipe[i].Text = listeEquipe[i].Nom;
                    listePictureBoxEquipe[i].Image = Image.FromFile(parent + "\\Icons\\" + listeEquipe[i].IconeCombat);
                    listeHPEquipe[i].Text = Convert.ToString(listeEquipe[i].MaxVie) + " / " + Convert.ToString(listeEquipe[i].Vie);
                    listeMPEquipe[i].Text = Convert.ToString(listeEquipe[i].MaxMP) + " / " + Convert.ToString(listeEquipe[i].PointSort);
                    listeLVLEquipe[i].Text = Convert.ToString(listeEquipe[i].Niveau);
                    Console.WriteLine(listeNameEquipe[i].Text);
                }

                Console.WriteLine("Nom du personnage :" + unHeros.Nom);

                /*
                foreach(PictureBox uneImageHeros in listePictureBoxEquipe)
                {
                    uneImageHeros.Image = Image.FromFile(parent + "\\Icons\\" + unHeros.IconeCombat);
                }
                

                foreach(Label unHPHeros in listeHPEquipe)
                {
                  // unHPHeros.Text = Convert.ToString(unHeros.Vie) + " / " + Convert.ToString(unHeros.MaxVie);
                }

                foreach (Label unMPHeros in listeMPEquipe)
                {
                    unMPHeros.Text = Convert.ToString(unHeros.PointSort) + " / " + Convert.ToString(unHeros.MaxMP);
                }

                foreach (Label unLVLHeros in listeLVLEquipe)
                {
                    unLVLHeros.Text = Convert.ToString(unHeros.Niveau);
                }
                */

                //lbHerosName2.Text = unHeros.Nom;
                //pbHeros2.Image = Image.FromFile(parent + "\\Icons\\" + unHeros.IconeCombat);
                //lbAfficheHPheros2.Text = Convert.ToString(unHeros.Vie) + " / " + Convert.ToString(unHeros.MaxVie);
                //lbAfficheMPheros2.Text = Convert.ToString(unHeros.PointSort) + " / " + Convert.ToString(unHeros.MaxMP);
                //lbAfficheLVLheros2.Text = Convert.ToString(unHeros.Niveau);
                selectIntMenuMax = listeMonstres.Count;
            }

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
                unMonstre.PositionPb = rnd.Next(tlpMonstres.ColumnCount);
                Console.WriteLine("Position Pb de "+unMonstre.Nom+" : "+unMonstre.PositionPb);
                tlpMonstres.Controls.Add(pbMonstre1, unMonstre.PositionPb, 0);
                foreach (Label unLabelMonstre in listeLabelMonstre)
                {
                    unLabelMonstre.Text = unMonstre.Nom;
                }
                postText += unMonstre.Nom + " apparaît ! \n";
                //lbTxtCombat.Text += unMonstre.Nom+" apparaît ! \n";
            }


            for (int i = 0; i < listeMonstres.Count; i++)
            {
                listePictureBoxMonstre[listeMonstres[i].PositionPb].Visible = true;
            }

            compteurCara = 0;
            cara = new List<char>(postText.ToCharArray());
        }

        private void timerCombat_Tick(object sender, EventArgs e)
        {
            counter--;
            
            if (counter <= 0)
            {
               
                if (lbTxtDialogue.Visible == true)
                {
                   
                    //defilement du dialogue a partir de post Text
                    if (lbTxtDialogue.Text != postText)
                    {
                        if (compteurCara < cara.Count)
                        {
                            lbTxtDialogue.Text += cara[compteurCara];
                            compteurCara++;

                            counter = 1;
                        }
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

            if (selectionner == true)
            {
                for (int i = 0; i < listeEquipe.Count; i++)
                {
                    if (listeEquipe[i].SonTour && listeEquipe[i].Vie > 0)
                    {
                        listePanelEquipe[i].BackColor = Color.DimGray;
                    }
                }
            }
            else
            {
                for (int i = 0; i < listePanelEquipe.Count; i++)
                {
                    for(int s = 0; s<listeEquipe.Count; s++)
                    {
                        if (listeEquipe[s].Vie > 0)
                        {
                            listePanelEquipe[s].BackColor = Color.Black;
                        }
                        else
                        {
                            listePanelEquipe[s].BackColor = Color.Red;
                        }
                    }
                    
                }
            }

            

            /////////////////////////////////////////////

            // Affichage du dialogue et des actions
            // Dialogue qui s'affiche
            if (dialogue == true && combat == false && actionsJoueur == false)
            {
                lbTxtDialogue.Visible = true;
                dialogueFleche.Visible = true;

                pnActions.Visible = false;
                tpnActions.Visible = false;

                for(int x = 0; x<listeMonstres.Count; x++)
                {
                    for (int y = 0; y < listeEquipe.Count; y++)
                    {
                        /*
                        if(listeMonstres[x].ListeActions.Count > 0 || listeEquipe[y].ListeActions.Count > 0)
                        {
                            phaseAction = true;
                        }
                        else
                        {
                            phaseAction = false;
                        }
                        */

                        if (actionAffichage == listeMonstres[x].Nom)
                        {
                            /*
                            foreach(KeyValuePair<string, string> uneAction in listeMonstres[x].ListeActions)
                            {
                                if(uneAction.Key == "attaqueP")
                                {
                                    Personnage personnageCible = new Personnage();
                                    foreach(Heros unHeros in listeEquipe)
                                    {
                                        if(uneAction.Value == unHeros.Nom)
                                        {
                                            personnageCible = unHeros;
                                        }
                                    }

                                    for(int z = 0; z<listeEquipe.Count; z++) { 
                                        if(personnageCible.Nom == listeEquipe[z].Nom)
                                        {
                                            listeEquipe[z] = listeMonstres[x].AttaqueNormal(personnageCible);
                                        }
                                    }
                                }
                            }
                            */
                        }

                        if(actionAffichage == listeEquipe[y].Nom)
                        {

                        }
                    }
                }
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
                    else if (selectIntMenu == 6)
                    {
                        selectMenuActions2 = "aptitudes";
                    }
                    else if (selectIntMenu == 7)
                    {
                        selectMenuActions2 = "objets";
                    }
                    else if (selectIntMenu == 8)
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

                    if (selectIntMenu == 0)
                    {
                        selectIntMenu = 3;
                    }
                    else if (selectIntMenu == 4)
                    {
                        selectIntMenu = 1;
                    }
                    else if (selectIntMenu == 5)
                    {
                        selectIntMenu = 8;
                    }
                    else if (selectIntMenu == 5)
                    {
                        selectIntMenu = 8;
                    }
                    else if (selectIntMenu == 9)
                    {
                        selectIntMenu = 6;
                    }
                }

                // Menu1 selection
                if (activeSelectMenu3 == true)
                {
                    

                    for(int i=1; i <= selectIntMenuMax; i++)
                    {
                        if(selectIntMenu == i)
                        {
                            if (listeMonstres[i - 1].EstMort == false)
                            {
                                selectMenuActions3 = listeMonstres[i - 1].Nom;
                            }
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


                    for(int i=0; i< listeMonstres.Count; i++)
                    {
                        if (listeMonstres[i].EstMort == false)
                        {


                            if (selectMenuActions3 == listeMonstres[i].Nom)
                            {
                                listePictureBoxMonstre[listeMonstres[i].PositionPb].BackColor = Color.DimGray;
                                listeLabelMonstre[i].Text = "> " + listeMonstres[i].Nom;
                            }
                            else
                            {
                                listePictureBoxMonstre[listeMonstres[i].PositionPb].BackColor = Color.Transparent;
                                listeLabelMonstre[i].Text = listeMonstres[i].Nom;
                            }
                        }
                    }

                    if (selectionner == true)
                    {
                        for (int i = 0; i < listeEquipe.Count; i++)
                        {
                            if (listeEquipe[i].SonTour && listeEquipe[i].Vie > 0)
                            {
                                listePanelEquipe[i].BackColor = Color.DimGray;
                            }
                            else if(!listeEquipe[i].SonTour && listeEquipe[i].Vie > 0)
                            {
                                listePanelEquipe[i].BackColor = Color.Black;
                            }
                        }
                    }

                    for (int j= listeMonstres.Count; j<listeLabelMonstre.Count; j++)
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
                        selectIntMenu = selectIntMenuMax;
                        Console.WriteLine(selectIntMenu);
                    }
                    else if (selectIntMenu > selectIntMenuMax)
                    {
                        selectIntMenu = 1;
                        Console.WriteLine(selectIntMenu);
                    }
                }

                
            }
            /////////////////////////////////////////////
            
        }

        private void Combat_KeyDown(object sender, KeyEventArgs e)
        {

            if (selectionner == true)
            {
                for(int i = 0; i < listeEquipe.Count; i++)
                {
                    if (listeEquipe[i].SonTour && listeEquipe[i].Vie > 0)
                    {
                        listePanelEquipe[i].BackColor = Color.DimGray;
                    }
                    else if (!listeEquipe[i].SonTour && listeEquipe[i].Vie > 0)
                    {
                        listePanelEquipe[i].BackColor = Color.Black;
                    }
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (passeDialogue == true)
                {
                    int nbPerso = 0;
                    bool heros = false;
                 

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
                    player.Play();
                    
                    if(phaseAction == true)
                    {
                        postText = "";
                        lbTxtDialogue.Text = "";
                        compteurCara = 0;
                        cara = new List<char>(postText.ToCharArray());

                        Console.WriteLine("PHASE ACTIONNN");
                        for (int x = 0; x < listeMonstres.Count; x++)
                        {
                            if(listePersonnagesCombat[nbPersonnageAction].Nom == listeMonstres[x].Nom && listeMonstres[x].EstMort == false)
                            {
                                nbPerso = x;
                                heros = false;
                                Console.WriteLine(listePersonnagesCombat[nbPersonnageAction].Nom + " correspond " + listeMonstres[x].Nom);
                                
                            }
                        }
                        for (int x = 0; x < listeEquipe.Count; x++)
                        {
                            if (listePersonnagesCombat[nbPersonnageAction].Nom == listeEquipe[x].Nom && listeEquipe[x].EstMort == false)
                            {
                                nbPerso = x;
                                heros = true;
                                Console.WriteLine(listePersonnagesCombat[nbPersonnageAction].Nom + " correspond " + listeEquipe[x].Nom);
                            }
                        }

                       

                        if (nbPersonnageAction >= 0)
                        {
                            Personnage personnageCible = new Personnage();
                            /*
                            for (int x = 0; x < listeMonstres.Count; x++)
                            {
                                for (int y = 0; y < listeEquipe.Count; y++)
                                {
                                    
                                    if (heros)
                                    {
                                        if (listeEquipe[nbPerso].ListeActions.Count > 0)
                                        {
                                            if (listeEquipe[nbPerso].ListeActions.ElementAt(nbActions).Value == listeMonstres[x].Nom && listeMonstres[x].EstMort == false)
                                            {
                                                personnageCible = listeMonstres[x];
                                            }

                                            if (listeEquipe[nbPerso].ListeActions.ElementAt(nbActions).Value == listeMonstres[x].Nom && listeMonstres[x].EstMort )
                                            {
                                                
                                                personnageCible = listeMonstres[rnd.Next(listeMonstres.Count)];
                                            }

                                            if (listeEquipe[nbPerso].ListeActions.ElementAt(nbActions).Value == listeEquipe[y].Nom)
                                            {
                                                personnageCible = listeEquipe[y];
                                            }
                                        }
                                        
                                    }
                                    else
                                    {

                                        Console.WriteLine("nbActions "+nbActions);

                                        if(listeMonstres[nbPerso].ListeActions.Count > 0)
                                        {
                                            if (listeMonstres[nbPerso].ListeActions.ElementAt(nbActions).Value == listeMonstres[x].Nom)
                                            {
                                                personnageCible = listeMonstres[x];
                                            }

                                            if (listeMonstres[nbPerso].ListeActions.ElementAt(nbActions).Value == listeEquipe[y].Nom)
                                            {
                                                personnageCible = listeEquipe[y];
                                            }
                                        }
                                       
                                    }
                                    
                                }

                            }
                            */
                            Console.WriteLine("Chiffre du perso :"+nbPerso);
                            
                            int degats = 0;
                            if (nbActions >= 0)
                            {
                                if (heros)
                                {
                                    if (listeEquipe[nbPerso].ListeActions.Count > 0)
                                    {
                                        if (listeMonstres.Count > 0)
                                        {


                                            if (listeEquipe[nbPerso].ListeActions.Keys.ElementAt(nbActions) == "attaqueP" && listeEquipe[nbPerso].EstMort == false)
                                            {
                                                if (personnageCible.Nom == null)
                                                {
                                                    bool trouve = false;
                                                    //timerSonsCombat.Stop();
                                                    for (int x = 0; x < listeMonstres.Count; x++)
                                                    {
                                                        for (int y = 0; y < listeEquipe.Count; y++)
                                                        {
                                                            Console.WriteLine(listeEquipe[nbPerso].ListeActions.ElementAt(nbActions).Value);

                                                            if (listeEquipe[nbPerso].ListeActions.ElementAt(nbActions).Value != listeMonstres[x].Nom)
                                                            {

                                                                personnageCible = listeMonstres[rnd.Next(listeMonstres.Count)];
                                                            }

                                                            if (listeEquipe[nbPerso].ListeActions.ElementAt(nbActions).Value == listeMonstres[x].Nom && listeMonstres[x].EstMort == false)
                                                            {
                                                                personnageCible = listeMonstres[x];
                                                                trouve = true;
                                                            }



                                                            if (listeEquipe[nbPerso].ListeActions.ElementAt(nbActions).Value == listeEquipe[y].Nom)
                                                            {
                                                                personnageCible = listeEquipe[y];
                                                            }
                                                        }
                                                    }

                                                }



                                                degats = listeEquipe[nbPerso].AttaqueNormal(personnageCible);
                                                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(parent + @"\Sounds\combat\attack.wav");
                                                player2.Play();
                                                if (degats < 0)
                                                {
                                                    degats = 0;
                                                }

                                                personnageCible.Vie -= degats;

                                                if (personnageCible.Vie <= 0)
                                                {
                                                    personnageCible.Vie = 0;
                                                    personnageCible.EstMort = true;
                                                }



                                                postText = listeEquipe[nbPerso].Nom + " attaque " + /*listeEquipe[nbPerso].ListeActions.Values.ElementAt(nbActions) + */"\n";
                                                if (degats > 1)
                                                {
                                                    postText += personnageCible.Nom + " subit " + degats + " points de degats" + "\n";

                                                }
                                                else
                                                {
                                                    postText += personnageCible.Nom + " subit " + degats + " point de degats" + "\n";
                                                }

                                                timerSonsCombat.Stop();
                                                timerSonsCombat.Start();
                                                if (personnageCible.TypePersonnage == "monstre")
                                                {
                                                    for (int i = 0; i < listeMonstres.Count; i++)
                                                    {
                                                        if (listeMonstres[i].Nom == personnageCible.Nom)
                                                        {
                                                            listeMonstres[i] = (Monstre)personnageCible;
                                                        }

                                                        if (listeMonstres[i].EstMort == true)
                                                        {
                                                            listePictureBoxMonstre[listeMonstres[i].PositionPb].Visible = false;

                                                            for (int h = 0; h < listeLabelMonstre.Count; h++)
                                                            {
                                                                if ((listeLabelMonstre[h].Text == "> " + listeMonstres[i].Nom) || (listeLabelMonstre[h].Text == listeMonstres[i].Nom))
                                                                {
                                                                    listeLabelMonstre[h].Text = "";

                                                                    selectIntMenu = 1;
                                                                }
                                                            }
                                                            /*
                                                            for (int x = 0; x < listeLabelMonstre.Count - 1; x++)
                                                            {
                                                                if((listeLabelMonstre[x].Text == listeLabelMonstre[x + 1].Text) || (listeLabelMonstre[x].Text == "> "+listeLabelMonstre[x + 1].Text))
                                                                {
                                                                    listeLabelMonstre[x + 1].Text = "";
                                                                }

                                                                if (listeLabelMonstre[x].Text == "")
                                                                {
                                                                    listeLabelMonstre[x].Text = listeLabelMonstre[x + 1].Text;
                                                                }
                                                            }
                                                            */
                                                            listeMonstres.Remove(listeMonstres[i]);
                                                            selectIntMenuMax = listeMonstres.Count;
                                                        }
                                                        else if (listeMonstres[i].EstMort == false)
                                                        {
                                                            listePictureBoxMonstre[listeMonstres[i].PositionPb].Visible = true;
                                                        }


                                                    }


                                                    foreach (Label unLabelMonstre in listeLabelMonstre)
                                                    {
                                                        unLabelMonstre.Text = "";
                                                    }

                                                    for (int i = 0; i < listeMonstres.Count; i++)
                                                    {
                                                        foreach (Label unLabelMonstre in listeLabelMonstre)
                                                        {
                                                            unLabelMonstre.Text = listeMonstres[i].Nom;
                                                        }
                                                    }
                                                }
                                                if (personnageCible.TypePersonnage == "heros")
                                                {
                                                    for (int i = 0; i < listeEquipe.Count; i++)
                                                    {
                                                        if (listeEquipe[i].Nom == personnageCible.Nom)
                                                        {
                                                            listeEquipe[i] = (Heros)personnageCible;
                                                        }

                                                    }
                                                }

                                                for (int i = 0; i < listeEquipe.Count; i++)
                                                {
                                                    listeHPEquipe[i].Text = Convert.ToString(listeEquipe[i].MaxVie) + " / " + Convert.ToString(listeEquipe[i].Vie);
                                                }

                                            }
                                        }
                                    }
                                   
                                   
                                    compteurCara = 0;
                                    cara = new List<char>(postText.ToCharArray());

                                    if (nbActions >= listeEquipe[nbPerso].ListeActions.Count - 1)
                                    {
                                        listeEquipe[nbPerso].ListeActions.Remove("attaqueP");
                                        personnageCible = new Personnage();
                                        nbActions = 0;
                                        nbPersonnageAction++;

                                    }
                                    else
                                    {
                                        nbActions++;
                                    }
                                    
                                }
                                else
                                {
                                    if (listeMonstres.Count > 0)
                                    {
                                        if (listeMonstres[nbPerso].ListeActions.Count > 0)
                                        {
                                            for (int x = 0; x < listeMonstres.Count; x++)
                                            {
                                                for (int y = 0; y < listeEquipe.Count; y++)
                                                {
                                                    if (listeMonstres[nbPerso].ListeActions.ElementAt(nbActions).Value == listeMonstres[x].Nom)
                                                    {
                                                        personnageCible = listeMonstres[x];
                                                    }

                                                    if (listeMonstres[nbPerso].ListeActions.ElementAt(nbActions).Value == listeEquipe[y].Nom)
                                                    {
                                                        personnageCible = listeEquipe[y];
                                                    }
                                                }
                                            }

                                            if (listeMonstres[nbPerso].ListeActions.Keys.ElementAt(nbActions) == "attaqueP" && listeMonstres[nbPerso].EstMort == false)
                                            {
                                                timerSonsCombat.Stop();
                                                degats = listeMonstres[nbPerso].AttaqueNormal(personnageCible);
                                                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(parent + @"\Sounds\combat\attack.wav");
                                                player2.Play();

                                                if (degats < 0)
                                                {
                                                    degats = 0;
                                                }
                                                personnageCible.Vie -= degats;

                                                postText = listeMonstres[nbPerso].Nom + " attaque " + listeMonstres[nbPerso].ListeActions.Values.ElementAt(nbActions) + "\n";
                                                if (degats > 1)
                                                {
                                                    postText += personnageCible.Nom + " subit " + degats + " points de degats" + "\n";
                                                }
                                                else
                                                {
                                                    postText += personnageCible.Nom + " subit " + degats + " point de degats" + "\n";
                                                }

                                                if (personnageCible.Vie <= 0)
                                                {
                                                    personnageCible.Vie = 0;
                                                    personnageCible.EstMort = true;

                                                    for (int v = 0; v < listePersonnagesCombat.Count; v++)
                                                    {
                                                        if (personnageCible.EstMort)
                                                        {
                                                            if (personnageCible.Nom == listePersonnagesCombat[v].Nom)
                                                            {
                                                                listePersonnagesCombat.RemoveAt(v);
                                                            }
                                                        }
                                                    }
                                                }

                                                timerSonsCombat.Stop();
                                                timerSonsCombat.Start();

                                                if (personnageCible.TypePersonnage == "monstre")
                                                {
                                                    for (int i = 0; i < listeMonstres.Count; i++)
                                                    {
                                                        if (listeMonstres[i].Nom == personnageCible.Nom)
                                                        {
                                                            listeMonstres[i] = (Monstre)personnageCible;
                                                        }
                                                    }
                                                }

                                                if (personnageCible.TypePersonnage == "heros")
                                                {

                                                    for (int i = 0; i < listeEquipe.Count; i++)
                                                    {
                                                        if (listeEquipe[i].Nom == personnageCible.Nom)
                                                        {
                                                            listeEquipe[i] = (Heros)personnageCible;
                                                        }
                                                    }
                                                }

                                                for (int i = 0; i < listeEquipe.Count; i++)
                                                {
                                                    listeHPEquipe[i].Text = Convert.ToString(listeEquipe[i].MaxVie) + " / " + Convert.ToString(listeEquipe[i].Vie);
                                                }
                                            }
                                        }
                                    }
                                    compteurCara = 0;
                                    cara = new List<char>(postText.ToCharArray());

                                    if (listeMonstres.Count > 0)
                                    {
                                        if (nbActions >= listeMonstres[nbPerso].ListeActions.Count - 1)
                                        {
                                            listeMonstres[nbPerso].ListeActions.Remove("attaqueP");
                                            nbActions = 0;
                                            nbPersonnageAction++;
                                        }
                                        else
                                        {
                                            nbActions++;
                                        }
                                    }
                                    
                                }
                                
                               
                            }         
                            
                        }

                        if (nbPersonnageAction == listePersonnagesCombat.Count){
                            phaseAction = false;
                            nbPersonnageAction = -1;
                            nbActions = -1;
                            numeroHeros = 0;

                            if (listeEquipe[0].EstMort == false)
                            {
                                listeEquipe[0].SonTour = true;
                            }
                            else if (listeEquipe[1].EstMort == false)
                            {
                                listeEquipe[1].SonTour = true;
                            }
                            else if (listeEquipe[2].EstMort == false)
                            {
                                listeEquipe[2].SonTour = true;
                            }
                            else if (listeEquipe[3].EstMort == false)
                            {
                                listeEquipe[3].SonTour = true;
                            }
                            /*
                            postText = "";
                            lbTxtDialogue.Text = "";
                            compteurCara = 0;
                            cara = new List<char>(postText.ToCharArray());
                            */

                        } 
                    }
                    else
                    {
                        dialogue = false;
                        combat = true;
                        actionsJoueur = true;
                        passeDialogue = false;
                        lbTxtDialogue.Text = "";
                        postText = "";
                    }
                    
                    
                    
                }

                if (combat == true && actionsJoueur == true)
                {
                    for(int i = 0; i < listeEquipe.Count; i++)
                    {
                        if (activeSelectMenu1 == true)
                        {
                            if (selectMenuActions1 == "fuir")
                            {
                                Form jeu = new Jeu(listeEquipe[0].Nom, listeEquipe[0].Race, listeEquipe[0].Classe, listeEquipe[0].X, listeEquipe[0].Y);
                                Form.ActiveForm.Close();
                                jeu.Show();

                            }

                            if (selectMenuActions1 == "combattre")
                            {
                                pnCombattre.Visible = true;
                                if (listeEquipe[i].SonTour == true)
                                {
                                   lbheroSelect.Text = listeEquipe[i].Nom;
                                }
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
                            for (int y = 0; y < listeMonstres.Count; y++)
                            {
                                if (selectMenuActions3 == listeMonstres[y].Nom)
                                {
                                    
                                    if (listeEquipe[i].SonTour == true)
                                    {

                                        // joueur.AttaquePhysique(listeMonstres[i]);

                                        // Memorise l'action du heros
                                        listeEquipe[i].ListeActions.Add("attaqueP", listeMonstres[y].Nom);
                                        Console.WriteLine("Le heros " + listeEquipe[i].Nom + " prévoit une attaque physique sur " + listeMonstres[y].Nom);

                                        for (int z = 0; z < listeMonstres.Count; z++)
                                        {
                                            listePictureBoxMonstre[z].BackColor = Color.Transparent;
                                        }
                                        

                                        // Passe son tour
                                        if (i < listeEquipe.Count-1)
                                        {
                                            
                                            listeEquipe[numeroHeros + 1].SonTour = true;
                                            lbheroSelect.Text = listeEquipe[numeroHeros + 1].Nom;



                                            if (listeEquipe[numeroHeros + 1].SonTour == true && listeEquipe[numeroHeros + 1].EstMort == true)
                                            {
                                                i++;
                                            }

                                        }

                                        
                                        listeEquipe[i].SonTour = false;
                                        
                                        // controle menu attaquer
                                        activeSelectMenu1 = true;
                                        activeSelectMenu2 = false;
                                        activeSelectMenu3 = false;
                                        selectionner = false;
                                        pnCombattre.Visible = false;
                                        pnMonstre.Visible = false;
                                        tpnMonstre.Visible = false;

                                        selectMenuActions2 = "";
                                        selectMenuActions1 = "";
                                        selectMenuActions3 = "";
                                        selectIntMenu = 1;


                                        if (i == listeEquipe.Count - 1)
                                        {
                                            timerCombat.Stop();
                                            timerCombat.Start();
                                            combat = false;
                                            actionsJoueur = false;
                                            dialogue = true;
                                            bool personnageFaible = false;
                                            Personnage lePersonnage = listeEquipe[0];
                                            if (listeEquipe[0].EstMort)
                                            {
                                                lePersonnage = listeEquipe[1];
                                            }
                                            
                                            Console.WriteLine("IA Ennemi");
                                            // Personnage avec la vie le plus faible
                                            for(int x = 0; x<listeEquipe.Count; x++)
                                            {
                                                if(listeEquipe[x].Vie > lePersonnage.Vie && !listeEquipe[x].EstMort)
                                                {
                                                    lePersonnage = listeEquipe[x];
                                                    Console.WriteLine("Remplacement !");
                                                    personnageFaible = true;
                                                }
                                            }
                                           
                                            for(int z = 0; z<listeMonstres.Count; z++)
                                            {
                                                if (personnageFaible == true)
                                                {
                                                    listeMonstres[z].ListeActions.Add("attaqueP", lePersonnage.Nom);
                                                    Console.WriteLine(listeMonstres[z].Nom + " attaque " + lePersonnage.Nom);
                                                }
                                                else
                                                {

                                                    int nbChoixAttaque = rnd.Next(0, listeEquipe.Count);
                                                    listeMonstres[z].ListeActions.Add("attaqueP", listeEquipe[nbChoixAttaque].Nom);
                                                    Console.WriteLine(listeMonstres[z].Nom + " attaque " + listeEquipe[nbChoixAttaque].Nom);
                                                }

                                            }
                                            
                                            actionAffichage = listePersonnagesCombat[0].Nom;
                                            phaseAction = true;
                                            nbPersonnageAction = 0;
                                            nbActions = 0;
                                            /*
                                            compteurCara = 0;
                                            cara = new List<char>(postText.ToCharArray());
                                            */

                                        }

                                    }/*
                                    else
                                    {
                                        for (int y = 0; y < listeEquipe.Count; y++)
                                        {
                                            if (listeEquipe[y].SonTour == true)
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
                                                    if (y == 0)
                                                    {
                                                        // passe le tour au heros suivant
                                                        listeEquipe[1].SonTour = true;
                                                    }
                                                    else if (y == 1)
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
                                                    else if (y == 2)
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
                                    */
                                    numeroHeros++;
                                    
                                }
                            }
                            
                        }
                        

                    }

                }

            }

            // Controle de l'interface
            if (combat == true && actionsJoueur == true)
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
                            selectIntMenu = 6;
                        }
                        else if (selectIntMenu == 2)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 7;
                        }
                        else if (selectIntMenu == 3)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 8;
                        }
                    }
                }

                if(e.KeyCode == Keys.Left)
                {
                    if (activeSelectMenu2 == true)
                    {
                        if (selectIntMenu == 6)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 1;
                        }
                        else if (selectIntMenu == 7)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
                            player.Play();
                            selectIntMenu = 2;
                        }
                        else if (selectIntMenu == 8)
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
            
            foreach (Monstre unMonstre in listeMonstres)
            {
               // unMonstre.ListeActions.Add("attaque")
            }
        }

        private void timerSonsCombat_Tick(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player3 = new System.Media.SoundPlayer(parent + @"\Sounds\combat\hit.wav");
            player3.Play();
            timerSonsCombat.Stop();
        }
    }
}
