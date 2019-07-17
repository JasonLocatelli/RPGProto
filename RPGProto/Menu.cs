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
    public partial class Menu : Form
    {
        string str_directory;
        string parent;
        bool musicPlaying;
        public Menu()
        {
            InitializeComponent();
            str_directory = Environment.CurrentDirectory.ToString();
            parent = System.IO.Directory.GetParent(str_directory).FullName;
            this.axWindowsMediaPlayer1.settings.playCount = 1000;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayer1_PlayStateChange);
            axWindowsMediaPlayer1.URL = parent + @"\Sounds\UI\menu.wav";
            axWindowsMediaPlayer1.Ctlcontrols.play();
          
        }

        private void btJouer_Click(object sender, EventArgs e)
        {
            Form choixRace = new ChoixRace();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent+@"\Sounds\UI\select.wav");
            player.Play();
            choixRace.Show();
            this.axWindowsMediaPlayer1.Ctlcontrols.pause();
            this.Hide();
            
            
        }

        private void btQuitter_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();

            Form.ActiveForm.Close();
        }

        private void btOptions_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\select.wav");
            player.Play();
           
        }

        private void btJouer_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
           
        }

        private void btOptions_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void btQuitter_MouseHover(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(parent + @"\Sounds\UI\sur.wav");
            player.Play();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1 && musicPlaying == true)
            {
                this.axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void Menu_VisibleChanged(object sender, EventArgs e)
        {
       
        }
    }
}
