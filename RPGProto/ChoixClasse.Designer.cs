namespace RPGProto
{
    partial class ChoixClasse
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
            this.btGuerier = new System.Windows.Forms.Button();
            this.lbChoixPersonnage = new System.Windows.Forms.Label();
            this.btRetour = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grChoixRace = new System.Windows.Forms.GroupBox();
            this.btRoublard = new System.Windows.Forms.Button();
            this.btRôdeur = new System.Windows.Forms.Button();
            this.btPretre = new System.Windows.Forms.Button();
            this.btPaladin = new System.Windows.Forms.Button();
            this.btMoine = new System.Windows.Forms.Button();
            this.btEnsorceleur = new System.Windows.Forms.Button();
            this.btMagicien = new System.Windows.Forms.Button();
            this.btDruide = new System.Windows.Forms.Button();
            this.btBarbare = new System.Windows.Forms.Button();
            this.btTourneGauche = new System.Windows.Forms.Button();
            this.btTourneDroite = new System.Windows.Forms.Button();
            this.btValider = new System.Windows.Forms.Button();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.lbChoisi = new System.Windows.Forms.Label();
            this.lbAfficheChoix = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grChoixRace.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGuerier
            // 
            this.btGuerier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGuerier.Location = new System.Drawing.Point(33, 56);
            this.btGuerier.Name = "btGuerier";
            this.btGuerier.Size = new System.Drawing.Size(69, 122);
            this.btGuerier.TabIndex = 1;
            this.btGuerier.Text = "Guerrier";
            this.btGuerier.UseVisualStyleBackColor = true;
            this.btGuerier.Click += new System.EventHandler(this.btGuerier_Click);
            this.btGuerier.MouseHover += new System.EventHandler(this.btGuerier_MouseHover);
            // 
            // lbChoixPersonnage
            // 
            this.lbChoixPersonnage.AutoSize = true;
            this.lbChoixPersonnage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChoixPersonnage.Location = new System.Drawing.Point(187, 21);
            this.lbChoixPersonnage.Name = "lbChoixPersonnage";
            this.lbChoixPersonnage.Size = new System.Drawing.Size(205, 20);
            this.lbChoixPersonnage.TabIndex = 1;
            this.lbChoixPersonnage.Text = "Choississez votre classe";
            // 
            // btRetour
            // 
            this.btRetour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRetour.Location = new System.Drawing.Point(-2, 2);
            this.btRetour.Name = "btRetour";
            this.btRetour.Size = new System.Drawing.Size(60, 45);
            this.btRetour.TabIndex = 0;
            this.btRetour.Text = "<";
            this.btRetour.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRetour.UseVisualStyleBackColor = true;
            this.btRetour.Click += new System.EventHandler(this.btRetour_Click);
            this.btRetour.MouseHover += new System.EventHandler(this.btRetour_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(637, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 381);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // grChoixRace
            // 
            this.grChoixRace.Controls.Add(this.btRoublard);
            this.grChoixRace.Controls.Add(this.btRôdeur);
            this.grChoixRace.Controls.Add(this.btPretre);
            this.grChoixRace.Controls.Add(this.btPaladin);
            this.grChoixRace.Controls.Add(this.btMoine);
            this.grChoixRace.Controls.Add(this.btEnsorceleur);
            this.grChoixRace.Controls.Add(this.btMagicien);
            this.grChoixRace.Controls.Add(this.btDruide);
            this.grChoixRace.Controls.Add(this.btBarbare);
            this.grChoixRace.Controls.Add(this.btGuerier);
            this.grChoixRace.Location = new System.Drawing.Point(30, 53);
            this.grChoixRace.Name = "grChoixRace";
            this.grChoixRace.Size = new System.Drawing.Size(503, 377);
            this.grChoixRace.TabIndex = 4;
            this.grChoixRace.TabStop = false;
            // 
            // btRoublard
            // 
            this.btRoublard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRoublard.Location = new System.Drawing.Point(403, 205);
            this.btRoublard.Name = "btRoublard";
            this.btRoublard.Size = new System.Drawing.Size(69, 122);
            this.btRoublard.TabIndex = 10;
            this.btRoublard.Text = "Roublard";
            this.btRoublard.UseVisualStyleBackColor = true;
            this.btRoublard.Click += new System.EventHandler(this.btRoublard_Click);
            this.btRoublard.MouseHover += new System.EventHandler(this.btRoublard_MouseHover);
            // 
            // btRôdeur
            // 
            this.btRôdeur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRôdeur.Location = new System.Drawing.Point(313, 205);
            this.btRôdeur.Name = "btRôdeur";
            this.btRôdeur.Size = new System.Drawing.Size(69, 122);
            this.btRôdeur.TabIndex = 9;
            this.btRôdeur.Text = "Rôdeur";
            this.btRôdeur.UseVisualStyleBackColor = true;
            this.btRôdeur.Click += new System.EventHandler(this.btRôdeur_Click);
            this.btRôdeur.MouseHover += new System.EventHandler(this.btRôdeur_MouseHover);
            // 
            // btPretre
            // 
            this.btPretre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPretre.Location = new System.Drawing.Point(226, 205);
            this.btPretre.Name = "btPretre";
            this.btPretre.Size = new System.Drawing.Size(69, 122);
            this.btPretre.TabIndex = 8;
            this.btPretre.Text = "Prêtre";
            this.btPretre.UseVisualStyleBackColor = true;
            this.btPretre.Click += new System.EventHandler(this.btPretre_Click);
            this.btPretre.MouseHover += new System.EventHandler(this.btPretre_MouseHover);
            // 
            // btPaladin
            // 
            this.btPaladin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPaladin.Location = new System.Drawing.Point(127, 205);
            this.btPaladin.Name = "btPaladin";
            this.btPaladin.Size = new System.Drawing.Size(69, 122);
            this.btPaladin.TabIndex = 7;
            this.btPaladin.Text = "Paladin";
            this.btPaladin.UseVisualStyleBackColor = true;
            this.btPaladin.Click += new System.EventHandler(this.btPaladin_Click);
            this.btPaladin.MouseHover += new System.EventHandler(this.btPaladin_MouseHover);
            // 
            // btMoine
            // 
            this.btMoine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btMoine.Location = new System.Drawing.Point(33, 205);
            this.btMoine.Name = "btMoine";
            this.btMoine.Size = new System.Drawing.Size(69, 122);
            this.btMoine.TabIndex = 6;
            this.btMoine.Text = "Moine";
            this.btMoine.UseVisualStyleBackColor = true;
            this.btMoine.Click += new System.EventHandler(this.btMoine_Click);
            this.btMoine.MouseHover += new System.EventHandler(this.btMoine_MouseHover);
            // 
            // btEnsorceleur
            // 
            this.btEnsorceleur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEnsorceleur.Location = new System.Drawing.Point(400, 56);
            this.btEnsorceleur.Name = "btEnsorceleur";
            this.btEnsorceleur.Size = new System.Drawing.Size(72, 122);
            this.btEnsorceleur.TabIndex = 5;
            this.btEnsorceleur.Text = "Ensorceleur";
            this.btEnsorceleur.UseVisualStyleBackColor = true;
            this.btEnsorceleur.Click += new System.EventHandler(this.btEnsorceleur_Click);
            this.btEnsorceleur.MouseHover += new System.EventHandler(this.btEnsorceleur_MouseHover);
            // 
            // btMagicien
            // 
            this.btMagicien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btMagicien.Location = new System.Drawing.Point(127, 56);
            this.btMagicien.Name = "btMagicien";
            this.btMagicien.Size = new System.Drawing.Size(69, 122);
            this.btMagicien.TabIndex = 2;
            this.btMagicien.Text = "Magicien";
            this.btMagicien.UseVisualStyleBackColor = true;
            this.btMagicien.Click += new System.EventHandler(this.btMagicien_Click);
            this.btMagicien.MouseHover += new System.EventHandler(this.btMagicien_MouseHover);
            // 
            // btDruide
            // 
            this.btDruide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDruide.Location = new System.Drawing.Point(313, 56);
            this.btDruide.Name = "btDruide";
            this.btDruide.Size = new System.Drawing.Size(69, 122);
            this.btDruide.TabIndex = 4;
            this.btDruide.Text = "Druide";
            this.btDruide.UseVisualStyleBackColor = true;
            this.btDruide.Click += new System.EventHandler(this.btDruide_Click);
            this.btDruide.MouseHover += new System.EventHandler(this.btDruide_MouseHover);
            // 
            // btBarbare
            // 
            this.btBarbare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBarbare.Location = new System.Drawing.Point(226, 56);
            this.btBarbare.Name = "btBarbare";
            this.btBarbare.Size = new System.Drawing.Size(69, 122);
            this.btBarbare.TabIndex = 3;
            this.btBarbare.Text = "Barbare";
            this.btBarbare.UseVisualStyleBackColor = true;
            this.btBarbare.Click += new System.EventHandler(this.btBarbare_Click);
            this.btBarbare.MouseHover += new System.EventHandler(this.btBarbare_MouseHover);
            // 
            // btTourneGauche
            // 
            this.btTourneGauche.BackColor = System.Drawing.Color.Transparent;
            this.btTourneGauche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btTourneGauche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTourneGauche.FlatAppearance.BorderSize = 0;
            this.btTourneGauche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTourneGauche.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTourneGauche.Location = new System.Drawing.Point(654, 220);
            this.btTourneGauche.Name = "btTourneGauche";
            this.btTourneGauche.Size = new System.Drawing.Size(39, 41);
            this.btTourneGauche.TabIndex = 5;
            this.btTourneGauche.Text = "<";
            this.btTourneGauche.UseVisualStyleBackColor = false;
            // 
            // btTourneDroite
            // 
            this.btTourneDroite.BackColor = System.Drawing.Color.Transparent;
            this.btTourneDroite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btTourneDroite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTourneDroite.FlatAppearance.BorderSize = 0;
            this.btTourneDroite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTourneDroite.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTourneDroite.Location = new System.Drawing.Point(823, 220);
            this.btTourneDroite.Name = "btTourneDroite";
            this.btTourneDroite.Size = new System.Drawing.Size(36, 41);
            this.btTourneDroite.TabIndex = 6;
            this.btTourneDroite.Text = ">";
            this.btTourneDroite.UseVisualStyleBackColor = false;
            // 
            // btValider
            // 
            this.btValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btValider.Enabled = false;
            this.btValider.Location = new System.Drawing.Point(330, 447);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(309, 40);
            this.btValider.TabIndex = 11;
            this.btValider.Text = "VALIDER";
            this.btValider.UseVisualStyleBackColor = true;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            this.btValider.MouseHover += new System.EventHandler(this.btValider_MouseHover);
            // 
            // tbNom
            // 
            this.tbNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNom.ForeColor = System.Drawing.Color.Blue;
            this.tbNom.Location = new System.Drawing.Point(699, 458);
            this.tbNom.MaxLength = 25;
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(130, 26);
            this.tbNom.TabIndex = 12;
            this.tbNom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNom.TextChanged += new System.EventHandler(this.tbNom_TextChanged);
            // 
            // lbChoisi
            // 
            this.lbChoisi.AutoSize = true;
            this.lbChoisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChoisi.Location = new System.Drawing.Point(13, 461);
            this.lbChoisi.Name = "lbChoisi";
            this.lbChoisi.Size = new System.Drawing.Size(181, 17);
            this.lbChoisi.TabIndex = 8;
            this.lbChoisi.Text = "Vous avez choisi la classe :";
            // 
            // lbAfficheChoix
            // 
            this.lbAfficheChoix.AutoSize = true;
            this.lbAfficheChoix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAfficheChoix.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbAfficheChoix.Location = new System.Drawing.Point(200, 461);
            this.lbAfficheChoix.Name = "lbAfficheChoix";
            this.lbAfficheChoix.Size = new System.Drawing.Size(110, 17);
            this.lbAfficheChoix.TabIndex = 9;
            this.lbAfficheChoix.Text = "lbAfficheChoix";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(950, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Description de la classe";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDescription.CausesValidation = false;
            this.rtbDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDescription.Location = new System.Drawing.Point(937, 49);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.ShortcutsEnabled = false;
            this.rtbDescription.Size = new System.Drawing.Size(227, 381);
            this.rtbDescription.TabIndex = 12;
            this.rtbDescription.TabStop = false;
            this.rtbDescription.Text = "";
            this.rtbDescription.Enter += new System.EventHandler(this.rtbDescription_Enter);
            // 
            // ChoixClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 499);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAfficheChoix);
            this.Controls.Add(this.lbChoisi);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.btTourneDroite);
            this.Controls.Add(this.btTourneGauche);
            this.Controls.Add(this.grChoixRace);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btRetour);
            this.Controls.Add(this.lbChoixPersonnage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChoixClasse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChoixPersonnage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grChoixRace.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGuerier;
        private System.Windows.Forms.Label lbChoixPersonnage;
        private System.Windows.Forms.Button btRetour;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grChoixRace;
        private System.Windows.Forms.Button btTourneGauche;
        private System.Windows.Forms.Button btTourneDroite;
        private System.Windows.Forms.Button btMagicien;
        private System.Windows.Forms.Button btDruide;
        private System.Windows.Forms.Button btBarbare;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button btRoublard;
        private System.Windows.Forms.Button btRôdeur;
        private System.Windows.Forms.Button btPretre;
        private System.Windows.Forms.Button btPaladin;
        private System.Windows.Forms.Button btMoine;
        private System.Windows.Forms.Button btEnsorceleur;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label lbChoisi;
        private System.Windows.Forms.Label lbAfficheChoix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbDescription;
    }
}