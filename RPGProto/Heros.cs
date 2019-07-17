﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGProto
{
    public class Heros : Sprite
    {
        private string nom;
        private string villeNatale;
        private DateTime dateNaissance;
        private string iconeCombat;

        private string race;
        private string classe;
        private bool sonTour;
        private Dictionary<string, string> listeActions;
        private int niveau;
        private int experience;
    
        private int vie;
        private int pointSort;
        private int defense;

        private int maxVie;
        private int maxMP;

        private List<Objet> equipements;

        private int force;
        private int agilite;
        private int dexterite;

        private List<Objet> inventaire;

        public Heros(string nomSprite, int width, int height, int x, int y, string path) : base(nomSprite, width, height, x, y, path)
        {
            this.nom = nomSprite;
            equipements = new List<Objet>();
            listeActions = new Dictionary<string, string>();
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }


        public string VilleNatale
        {
            get
            {
                return villeNatale;
            }
        }

        public DateTime DateNaissance
        {
            get
            {
                return dateNaissance;
            }
        }

        public int Niveau
        {
            get
            {
                return niveau;
            }

            set
            {
                niveau = value;
            }
        }

        public int Vie
        {
            get
            {
                return vie;
            }

            set
            {
                vie = value;
            }
        }

 

        public List<Objet> Equipements
        {
            get
            {
                return equipements;
            }

            set
            {
                equipements = value;
            }
        }

        public int Force
        {
            get
            {
                return force;
            }

            set
            {
                force = value;
            }
        }

        public int Agilite
        {
            get
            {
                return agilite;
            }

            set
            {
                agilite = value;
            }
        }

        public int Dexterite
        {
            get
            {
                return dexterite;
            }

            set
            {
                dexterite = value;
            }
        }

        public List<Objet> Inventaire
        {
            get
            {
                return inventaire;
            }

            set
            {
                inventaire = value;
            }
        }

        public int Defense
        {
            get
            {
                return defense;
            }

            set
            {

                defense = value;
            }
        }

        public string IconeCombat { get => iconeCombat; set => iconeCombat = value; }
        public int PointSort { get => pointSort; set => pointSort = value; }
        public int MaxVie { get => maxVie; set => maxVie = value; }
        public int MaxMP { get => maxMP; set => maxMP = value; }
        public bool SonTour { get => sonTour; set => sonTour = value; }
        public int Experience { get => experience; set => experience = value; }
        public Dictionary<string, string> ListeActions { get => listeActions; set => listeActions = value; }

        public void AttaquePhysique(Ennemi unEnnemi)
        {
            int pointAttaque = force - unEnnemi.Defense;
            unEnnemi.Vie -= pointAttaque;
            Console.WriteLine("L'ennemi " + unEnnemi.Nom + " perd " + pointAttaque + " de damage.");
        }
    }
}