using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
    partial class WumpusWorldSquare : PictureBox
    {
        bool isHole;
        bool isWumpus;
        bool stench;
        bool breeze;
        bool glitter;
        bool explored;
        bool isAgent;
        bool show;

        public WumpusWorldSquare()
        {
            isHole = false;
            isWumpus = false;
            explored = false;
            glitter = false;
            stench = false;
            breeze = false;
            isAgent = false;
            show = false;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            InitializeComponent();
            this.InitialImage = global::CustomControls.Properties.Resources.clear;
            ChangeBackgroundImage();
            ChangeImage();
        }

        public bool IsAgent
        {
            get { return isAgent; }
            set
            {
                isAgent = value;
                this.ChangeImage();
            }
        }

        public bool IsWumpus
        {
            get { return isWumpus; }
            set
            {
                isWumpus = value;
                this.ChangeImage();
            }
        }

        public bool IsHole
        {
            get { return isHole; }
            set
            {
                isHole = value;
                this.ChangeImage();
            }
        }

        public bool Stench
        {
            get { return stench; }
            set
            {
                stench = value;
                this.ChangeBackgroundImage();
            }
        }

        public bool Breeze
        {
            get { return breeze; }
            set
            {
                breeze = value;
                this.ChangeBackgroundImage();
            }
        }

        public bool Glitter
        {
            get { return glitter; }
            set
            {
                glitter = value;
                this.ChangeImage();
            }
        }

        public bool Explored
        {
            get { return explored; }
            set
            {
                explored = value;
                this.ChangeImage();
            }
        }

        public bool ShowSquare
        {
            get { return show; }
            set
            {
                show = value;
                this.ChangeImage();
            }
        }

        private void ChangeBackgroundImage()
        {
            if (breeze)
                if (stench)
                    this.BackgroundImage = global::CustomControls.Properties.Resources.stenchbreeze;
                else
                    this.BackgroundImage = global::CustomControls.Properties.Resources.breeze;
            else
                if(stench)
                    this.BackgroundImage = global::CustomControls.Properties.Resources.stench;
                else
                    this.BackgroundImage = global::CustomControls.Properties.Resources.clear;
            Invalidate();
        }

        private void ChangeImage()
        {
            if (!explored && !show)
            {
                this.Image = global::CustomControls.Properties.Resources.unknown;
                return;
            }
            if (isAgent)
            {
                if(isWumpus || isHole)
                    this.Image = global::CustomControls.Properties.Resources.boom;
                else
                    if(glitter)
                        this.Image = global::CustomControls.Properties.Resources.agentgold;
                    else
                        this.Image = global::CustomControls.Properties.Resources.agent;
                return;
            }
            if (isWumpus)
                if (isHole)
                    if (glitter)
                        this.Image = global::CustomControls.Properties.Resources.wumpusholegoldc;
                    else this.Image = global::CustomControls.Properties.Resources.wumpusholec;
                else
                    if (glitter)
                        this.Image = global::CustomControls.Properties.Resources.wumpusgoldc;
                    else this.Image = global::CustomControls.Properties.Resources.wumpusc;
            else
                if (isHole)
                    if (glitter)
                        this.Image = global::CustomControls.Properties.Resources.holegoldc;
                    else this.Image = global::CustomControls.Properties.Resources.holec;
                else
                    if (glitter)
                        this.Image = global::CustomControls.Properties.Resources.goldc;
                    else this.Image = null;
            Invalidate();
        }
    }
}
