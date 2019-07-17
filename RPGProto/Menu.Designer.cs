namespace RPGProto
{
    partial class Menu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btOptions = new System.Windows.Forms.Button();
            this.btJouer = new System.Windows.Forms.Button();
            this.btQuitter = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btOptions
            // 
            this.btOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOptions.Location = new System.Drawing.Point(227, 264);
            this.btOptions.Name = "btOptions";
            this.btOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btOptions.Size = new System.Drawing.Size(106, 53);
            this.btOptions.TabIndex = 1;
            this.btOptions.Text = "OPTIONS";
            this.btOptions.UseVisualStyleBackColor = true;
            this.btOptions.Click += new System.EventHandler(this.btOptions_Click);
            this.btOptions.MouseHover += new System.EventHandler(this.btOptions_MouseHover);
            // 
            // btJouer
            // 
            this.btJouer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btJouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJouer.Location = new System.Drawing.Point(227, 194);
            this.btJouer.Name = "btJouer";
            this.btJouer.Size = new System.Drawing.Size(106, 51);
            this.btJouer.TabIndex = 0;
            this.btJouer.Text = "JOUER";
            this.btJouer.UseVisualStyleBackColor = true;
            this.btJouer.Click += new System.EventHandler(this.btJouer_Click);
            this.btJouer.MouseHover += new System.EventHandler(this.btJouer_MouseHover);
            // 
            // btQuitter
            // 
            this.btQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuitter.Location = new System.Drawing.Point(227, 338);
            this.btQuitter.Name = "btQuitter";
            this.btQuitter.Size = new System.Drawing.Size(106, 53);
            this.btQuitter.TabIndex = 2;
            this.btQuitter.Text = "QUITTER";
            this.btQuitter.UseVisualStyleBackColor = true;
            this.btQuitter.Click += new System.EventHandler(this.btQuitter_Click);
            this.btQuitter.MouseHover += new System.EventHandler(this.btQuitter_MouseHover);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(28, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            this.axWindowsMediaPlayer1.Visible = false;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 434);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.btQuitter);
            this.Controls.Add(this.btJouer);
            this.Controls.Add(this.btOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.VisibleChanged += new System.EventHandler(this.Menu_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOptions;
        private System.Windows.Forms.Button btJouer;
        private System.Windows.Forms.Button btQuitter;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

