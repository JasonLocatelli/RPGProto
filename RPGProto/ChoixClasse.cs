using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace RPGProto
{
    public partial class ChoixClasse : Form
    {
        string str_directory;
        string parent;

        string choixClasse;
        string nomPerso;

        string choix;
       
        public ChoixClasse(string choix, string nom)
        {
            InitializeComponent();
            choixClasse = choix;
            nomPerso = nom;
            tbNom.Text = nomPerso;
            lbAfficheChoix.Text = "";
            str_directory = Environment.CurrentDirectory.ToString();
            parent = System.IO.Directory.GetParent(str_directory).FullName;
        }

        private void btRetour_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\back.wav");
            player.Play();
            Form.ActiveForm.Close();
        }

        private void btValider_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            nomPerso = tbNom.Text;
            Form.ActiveForm.Close();
            Form jeu = new Jeu(nomPerso, choixClasse, choix, 2,2);
            jeu.Show();

        }

        private void btGuerier_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btGuerier.Text;
            lbAfficheChoix.Text = choix;
            lbAfficheChoix.Text = choix;
            rtbDescription.Text = "Certains prennent les armes en quête de gloire, de richesse, ou de vengeance." +
                "\n\nD’autres combattent pour faire leurs preuves, pour protéger des proches ou parce qu’ils ne savent rien faire d’autre. " +
                "\n\nEt d’autres encore s’engagent sur la voie des armes pour affûter leur corps et démontrer leur courage lorsque le combat fait rage. " +
                "\n\nLes guerriers, ces seigneurs du champ de bataille, forment un groupe hétéroclite. Ils s’entraînent à manier de nombreuses armes ou juste une, ils apprennent à utiliser les armures de manière optimale, ils suivent les enseignements martiaux de maîtres exotiques et étudient l’art de la guerre." +
                "\n\nTout cela pour devenir de véritables armes vivantes. Ces combattants exceptionnels sont plus que de simples brutes : ils révèlent la véritable puissance des armes et transforment de simples morceaux de métal en outils permettant de soumettre des royaumes, de massacrer des monstres et d’unir des armées." +
                "\n\nLes guerriers sont des soldats, des chevaliers, des chasseurs, des artistes de la guerre et des champions sans égal. " +
                "\n\nMalheur à ceux qui oseraient s’opposer à eux.";
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void btMagicien_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btMagicien.Text;
            lbAfficheChoix.Text = choix;
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void btBarbare_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btBarbare.Text;
            lbAfficheChoix.Text = choix;
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void btDruide_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btDruide.Text;
            lbAfficheChoix.Text = choix;
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void btEnsorceleur_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btEnsorceleur.Text;
            lbAfficheChoix.Text = choix;
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void btMoine_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btMoine.Text;
            lbAfficheChoix.Text = choix;
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void btPaladin_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btPaladin.Text;
            lbAfficheChoix.Text = choix;
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void btPretre_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btPretre.Text;
            lbAfficheChoix.Text = choix;
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void btRôdeur_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btRôdeur.Text;
            lbAfficheChoix.Text = choix;
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void btRoublard_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btRoublard.Text;
            lbAfficheChoix.Text = choix;
            if (tbNom.Text != "")
            {
                btValider.Enabled = true;
            }

           
        }

        private void tbNom_TextChanged(object sender, EventArgs e)
        {
            if (choix != null)
            {
                btValider.Enabled = true;
            }
            else
            {
                btValider.Enabled = false;
            }
        }

        private void btGuerier_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btMagicien_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btBarbare_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btDruide_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btEnsorceleur_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btMoine_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btPaladin_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btPretre_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btRôdeur_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btRoublard_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btValider_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btRetour_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void rtbDescription_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = lbAfficheChoix;
        }
    }
}
