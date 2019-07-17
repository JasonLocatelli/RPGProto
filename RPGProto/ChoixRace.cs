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
using System.Text.RegularExpressions;

namespace RPGProto
{
    public partial class ChoixRace : Form
    {
        string str_directory;
        string parent;
        string choix;
        string nomPerso;

        public ChoixRace()
        {
            InitializeComponent();
            lbAfficheChoix.Text = "";
            str_directory = Environment.CurrentDirectory.ToString();
            parent = System.IO.Directory.GetParent(str_directory).FullName;
        }

        private void btRetour_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\back.wav");
            player.Play();
            Form.ActiveForm.Close();
            Form menu = new Menu();
            menu.Show();
        }
        private void btValider_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            Console.WriteLine(tbNom.Text);
            Form choixClasse = new ChoixClasse(choix, tbNom.Text);
            Console.WriteLine("Vous avez choisis : " + choix);
            choixClasse.Show();
            this.Hide();
        }

        private void btHumain_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btHumain.Text;
            btContinuer.Enabled = true;
            lbAfficheChoix.Text = choix;
            rtbDescription.Text = "Les humains possèdent un dynamisme exceptionnel ainsi qu’une grande capacité à surmonter les difficultés et à se multiplier, ce qui explique sans doute pourquoi il s’agit de la race dominante." +
                "\n\nLeurs empires et leurs nations s’étendent sur de larges territoires et les membres de ces sociétés se forgent un nom à la pointe de leur épée ou grâce à la puissance de leur magie." +
                "\n\nLes humains se démarquent également par leur agitation permanente et leur grande diversité." +
                "\n\nLeurs sociétés sont très variées, allant des tribus sauvages dont la culture est basée sur l’honneur jusqu’aux familles nobles et décadentes des cités cosmopolites dont les membres vénèrent des entités infernales.La curiosité et l’ambition des humains prennent souvent le pas sur leur goût pour un mode de vie sédentaire." +
                "\n\nBeaucoup d’entre eux quittent leur demeure pour aller explorer les innombrables recoins oubliés du monde ou pour prendre la tête de puissantes armées et conquérir les territoires voisins, simplement parce que ces possibilités s’offrent à eux.";
        }

        private void btNain_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btNain.Text;
            btContinuer.Enabled = true;
            lbAfficheChoix.Text = choix;
        }

        private void btOrc_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btOrc.Text;
            btContinuer.Enabled = true;
            lbAfficheChoix.Text = choix;
        }

        private void btElfe_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btElfe.Text;
            btContinuer.Enabled = true;
            lbAfficheChoix.Text = choix;
        }

        private void btGnome_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btGnome.Text;
            btContinuer.Enabled = true;
            lbAfficheChoix.Text = choix;
        }

        private void btMagicien_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
            choix = btMagicien.Text;
            btContinuer.Enabled = true;
            lbAfficheChoix.Text = choix;
        }

        private void tbNom_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btHumain_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btElfe_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btGnome_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btNain_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btOrc_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btMagicien_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btContinuer_MouseHover(object sender, EventArgs e)
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
