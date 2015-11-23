using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControls;
using Agent;

namespace WumpusWorld
{
    public partial class Form1 : Form
    {
        bool AgentIgra;
        KnowledgeBase KB;
        int GamesWon;
        int GamesPlayed;
        int Uspjesnost;
        int UkupnaUspjesnost;

        public Form1()
        {
            InitializeComponent();
            AgentIgra = false;
            KB = new KnowledgeBase(4, 4, 1, 3, WW.Breeze, WW.Stench, WW.Glitter);
            this.WW.Focus();
            WW.Invalidate();
            GamesPlayed = 0;
            GamesWon = 0;
            Uspjesnost = 0;
            UkupnaUspjesnost = 0;
            WW.GotFocus += WW_GotFocus;
            WW.LostFocus += WW_LostFocus;
            WW.AgentMoved += WW_AgentMoved;
            WW.GoldFoundEH += WW_GoldFoundEH;
        }

        void WW_GoldFoundEH(object sender, EventArgs e)
        {
            Uspjesnost += 1000;
        }

        void WW_AgentMoved(object sender, AgentMovedEventArgs e)
        {
            KB.Move(e.Direction, WW.Breeze, WW.Stench, WW.Glitter);
            this.splitContainer1.Panel2.AutoScrollPosition = new Point(
                WW.AgentPositionX * WW.SquareDimension - this.splitContainer1.Panel2.Width / 2 + WW.SquareDimension / 2,
                (WW.Columns - WW.AgentPositionY - 1) * WW.SquareDimension - this.splitContainer1.Panel2.Height / 2 + WW.SquareDimension / 2);
            Uspjesnost--;
            lblUspjesnost.Text = Uspjesnost.ToString();
            if (AgentIgra)
                WW.AgentMove(KB.BestMove());
        }

        void WW_LostFocus(object sender, EventArgs e)
        {
            if (WW.Result == GameResult.Running)
                this.Message.Text = "Select the board to move your agent.";
        }

        void WW_GotFocus(object sender, EventArgs e)
        {
            if (WW.Result == GameResult.Running)
                this.Message.Text = "Use WSAD or arrow keys to move.";
        }

        private void WorldData_ValueChanged(object sender, EventArgs e)
        {
            if (WumpusCount.Value > Sirina.Value * Visina.Value - 2 - HoleCount.Value)
            {
                if (Sirina.Value * Visina.Value - 2 - HoleCount.Value < 0)
                    WumpusCount.Value = 0;
                else
                    WumpusCount.Value = Sirina.Value * Visina.Value - 2 - HoleCount.Value;
            }
            if (HoleCount.Value > Sirina.Value * Visina.Value - 2 - WumpusCount.Value)
                HoleCount.Value = Sirina.Value * Visina.Value - 2 - WumpusCount.Value;
            WumpusCount.Maximum = Sirina.Value * Visina.Value - 2 - HoleCount.Value;
            HoleCount.Maximum = Sirina.Value * Visina.Value - 2 - WumpusCount.Value;
            if (Sirina.Value < 2)
                this.Visina.Minimum = 2;
            else this.Visina.Minimum = 1;
            if (Visina.Value < 2)
                this.Sirina.Minimum = 2;
            else this.Sirina.Minimum = 1;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.btnReset.Enabled = false;
            this.SuspendLayout();
            this.Visina.Value = 4;
            this.Sirina.Value = 4;
            this.WorldData_ValueChanged(Visina, null);
            this.WumpusCount.Value = 1;
            this.HoleCount.Value = 3;
            this.btnReset.Enabled = true;
            this.ResumeLayout();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AgentIgra = false;
            Uspjesnost = 0;
            this.SuspendLayout();
            this.splitContainer1.Panel2.AutoScrollPosition = new Point(0, 0);
            this.btnCreate.Enabled = false;
            this.btnKorak.Enabled = false;
            this.btnOdigraj.Enabled = false;
            this.Message.Text = "Please wait...";
            this.lblUspjesnost.Text = "0";
            this.splitContainer1.Panel2.Controls.Remove(this.WW);
            this.ResumeLayout(true);
            this.PerformLayout();

            this.WW.Reset(
                (int)Sirina.Value,
                (int)Visina.Value,
                (int)WumpusCount.Value,
                (int)HoleCount.Value);
            KB = new KnowledgeBase(
                (int)Sirina.Value,
                (int)Visina.Value,
                (int)WumpusCount.Value,
                (int)HoleCount.Value,
                WW.Breeze,
                WW.Stench,
                WW.Glitter);

            this.SuspendLayout();
            this.splitContainer1.Panel2.Controls.Add(this.WW);
            this.WW.Focus();
            this.splitContainer1.Panel2.AutoScrollPosition =
                new Point(0, WW.SquareDimension * WW.Columns);
            this.Message.Text = "Use WSAD or arrow keys to move.";
            this.btnCreate.Enabled = true;
            this.btnKorak.Enabled = true;
            this.btnOdigraj.Enabled = true;
            this.ResumeLayout();
            this.PerformLayout();
        }

        private void WW_GameEnded(object sender, GameEndedEventArgs e)
        {
            GamesPlayed++;
            this.lblBrojIgara.Text = GamesPlayed.ToString();
            if (e.GameWon)
            {

                GamesWon++;
                this.lblBrojPobjeda.Text = GamesWon.ToString();
                this.Message.Text = "You won the game!";
            }
            else
            {
                Uspjesnost -= 1000;
                this.Message.Text = "Oh, no! You died.";
                this.lblBrojPoraza.Text = (GamesPlayed - GamesWon).ToString();
            }
            UkupnaUspjesnost += Uspjesnost - 1;
            lblProsjecnaUspjesnost.Text = (UkupnaUspjesnost / GamesPlayed).ToString();
            this.btnKorak.Enabled = false;
            this.btnOdigraj.Enabled = false;
            this.btnCreate.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.btnCreate.Enabled = false;
            this.btnOdigraj.Enabled = false;
            this.btnKorak.Enabled = false;
            WW.AgentMove(KB.BestMove());
            if (!AgentIgra)
            {
                this.btnCreate.Enabled = true;
                if (WW.Result == GameResult.Running)
                {
                    this.btnKorak.Enabled = true;
                    this.btnOdigraj.Enabled = true;
                }
            }
        }

        private void btnOdigraj_Click(object sender, EventArgs e)
        {
            AgentIgra = true;
            button1_Click(sender, e);
        }

        private void btnResetStat_Click(object sender, EventArgs e)
        {
            GamesWon = 0;
            GamesPlayed = 0;
            UkupnaUspjesnost = 0;
            this.lblBrojIgara.Text = "0";
            this.lblBrojPobjeda.Text = "0";
            this.lblBrojPoraza.Text = "0";
            this.lblProsjecnaUspjesnost.Text = "0";
        }

        private void btnOtkrij_MouseDown(object sender, MouseEventArgs e)
        {
            this.WW.ShowSquares(true);
        }

        private void btnOtkrij_MouseUp(object sender, MouseEventArgs e)
        {
            this.WW.ShowSquares(false);
        }
    }
}
