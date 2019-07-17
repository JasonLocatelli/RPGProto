namespace RPGProto
{
    partial class Jeu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jeu));
            this.axWindowsMediaPlayerJeu = new AxWMPLib.AxWindowsMediaPlayer();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerJeu)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayerJeu
            // 
            this.axWindowsMediaPlayerJeu.Enabled = true;
            this.axWindowsMediaPlayerJeu.Location = new System.Drawing.Point(166, 51);
            this.axWindowsMediaPlayerJeu.Name = "axWindowsMediaPlayerJeu";
            this.axWindowsMediaPlayerJeu.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayerJeu.OcxState")));
            this.axWindowsMediaPlayerJeu.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayerJeu.TabIndex = 0;
            this.axWindowsMediaPlayerJeu.Visible = false;
            this.axWindowsMediaPlayerJeu.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayerJeu_PlayStateChange);
            this.axWindowsMediaPlayerJeu.Enter += new System.EventHandler(this.axWindowsMediaPlayerJeu_Enter);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Jeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 612);
            this.Controls.Add(this.axWindowsMediaPlayerJeu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Jeu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jeu";
            this.Load += new System.EventHandler(this.Jeu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Jeu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerJeu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayerJeu;
        private System.Windows.Forms.Timer timer;
    }
}