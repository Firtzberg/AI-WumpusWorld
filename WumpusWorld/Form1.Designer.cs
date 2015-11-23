namespace WumpusWorld
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnReset = new System.Windows.Forms.Button();
            this.WumpusCount = new System.Windows.Forms.NumericUpDown();
            this.Visina = new System.Windows.Forms.NumericUpDown();
            this.Sirina = new System.Windows.Forms.NumericUpDown();
            this.HoleCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Message = new System.Windows.Forms.Label();
            this.btnKorak = new System.Windows.Forms.Button();
            this.btnOdigraj = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblUspjesnost = new System.Windows.Forms.Label();
            this.lblProsjecnaUspjesnost = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblBrojPoraza = new System.Windows.Forms.Label();
            this.lblBrojPobjeda = new System.Windows.Forms.Label();
            this.lblBrojIgara = new System.Windows.Forms.Label();
            this.btnResetStat = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnOtkrij = new System.Windows.Forms.Button();
            this.WW = new CustomControls.WumpusWorldBoard();
            ((System.ComponentModel.ISupportInitialize)(this.WumpusCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Visina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sirina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoleCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(6, 123);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // WumpusCount
            // 
            this.WumpusCount.Location = new System.Drawing.Point(109, 71);
            this.WumpusCount.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.WumpusCount.Name = "WumpusCount";
            this.WumpusCount.Size = new System.Drawing.Size(76, 20);
            this.WumpusCount.TabIndex = 3;
            this.WumpusCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WumpusCount.ValueChanged += new System.EventHandler(this.WorldData_ValueChanged);
            // 
            // Visina
            // 
            this.Visina.Location = new System.Drawing.Point(109, 19);
            this.Visina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Visina.Name = "Visina";
            this.Visina.Size = new System.Drawing.Size(76, 20);
            this.Visina.TabIndex = 1;
            this.Visina.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Visina.ValueChanged += new System.EventHandler(this.WorldData_ValueChanged);
            // 
            // Sirina
            // 
            this.Sirina.Location = new System.Drawing.Point(109, 45);
            this.Sirina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Sirina.Name = "Sirina";
            this.Sirina.Size = new System.Drawing.Size(76, 20);
            this.Sirina.TabIndex = 2;
            this.Sirina.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Sirina.ValueChanged += new System.EventHandler(this.WorldData_ValueChanged);
            // 
            // HoleCount
            // 
            this.HoleCount.Location = new System.Drawing.Point(109, 97);
            this.HoleCount.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.HoleCount.Name = "HoleCount";
            this.HoleCount.Size = new System.Drawing.Size(76, 20);
            this.HoleCount.TabIndex = 7;
            this.HoleCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.HoleCount.ValueChanged += new System.EventHandler(this.WorldData_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Wumpus count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of pits:";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(109, 123);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(76, 23);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Visina);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.HoleCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Sirina);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.WumpusCount);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 152);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map settings";
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(12, 346);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(169, 13);
            this.Message.TabIndex = 12;
            this.Message.Text = "Use WSAD or arrow keys to move";
            // 
            // btnKorak
            // 
            this.btnKorak.Location = new System.Drawing.Point(6, 19);
            this.btnKorak.Name = "btnKorak";
            this.btnKorak.Size = new System.Drawing.Size(75, 23);
            this.btnKorak.TabIndex = 13;
            this.btnKorak.Text = "Move";
            this.btnKorak.UseVisualStyleBackColor = true;
            this.btnKorak.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOdigraj
            // 
            this.btnOdigraj.Location = new System.Drawing.Point(110, 19);
            this.btnOdigraj.Name = "btnOdigraj";
            this.btnOdigraj.Size = new System.Drawing.Size(75, 23);
            this.btnOdigraj.TabIndex = 14;
            this.btnOdigraj.Text = "Finish game";
            this.btnOdigraj.UseVisualStyleBackColor = true;
            this.btnOdigraj.Click += new System.EventHandler(this.btnOdigraj_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKorak);
            this.groupBox2.Controls.Add(this.btnOdigraj);
            this.groupBox2.Location = new System.Drawing.Point(12, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 48);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Let the agent...";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblUspjesnost);
            this.groupBox3.Controls.Add(this.lblProsjecnaUspjesnost);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblBrojPoraza);
            this.groupBox3.Controls.Add(this.lblBrojPobjeda);
            this.groupBox3.Controls.Add(this.lblBrojIgara);
            this.groupBox3.Controls.Add(this.btnResetStat);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 119);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Statistics";
            // 
            // lblUspjesnost
            // 
            this.lblUspjesnost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUspjesnost.Location = new System.Drawing.Point(110, 16);
            this.lblUspjesnost.Name = "lblUspjesnost";
            this.lblUspjesnost.Size = new System.Drawing.Size(75, 19);
            this.lblUspjesnost.TabIndex = 10;
            this.lblUspjesnost.Text = "0";
            this.lblUspjesnost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblProsjecnaUspjesnost
            // 
            this.lblProsjecnaUspjesnost.Location = new System.Drawing.Point(135, 74);
            this.lblProsjecnaUspjesnost.Name = "lblProsjecnaUspjesnost";
            this.lblProsjecnaUspjesnost.Size = new System.Drawing.Size(50, 13);
            this.lblProsjecnaUspjesnost.TabIndex = 9;
            this.lblProsjecnaUspjesnost.Text = "0";
            this.lblProsjecnaUspjesnost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Average score:";
            // 
            // lblBrojPoraza
            // 
            this.lblBrojPoraza.Location = new System.Drawing.Point(135, 61);
            this.lblBrojPoraza.Name = "lblBrojPoraza";
            this.lblBrojPoraza.Size = new System.Drawing.Size(50, 13);
            this.lblBrojPoraza.TabIndex = 7;
            this.lblBrojPoraza.Text = "0";
            this.lblBrojPoraza.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBrojPobjeda
            // 
            this.lblBrojPobjeda.Location = new System.Drawing.Point(135, 48);
            this.lblBrojPobjeda.Name = "lblBrojPobjeda";
            this.lblBrojPobjeda.Size = new System.Drawing.Size(50, 13);
            this.lblBrojPobjeda.TabIndex = 6;
            this.lblBrojPobjeda.Text = "0";
            this.lblBrojPobjeda.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBrojIgara
            // 
            this.lblBrojIgara.Location = new System.Drawing.Point(135, 35);
            this.lblBrojIgara.Name = "lblBrojIgara";
            this.lblBrojIgara.Size = new System.Drawing.Size(50, 13);
            this.lblBrojIgara.TabIndex = 5;
            this.lblBrojIgara.Text = "0";
            this.lblBrojIgara.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnResetStat
            // 
            this.btnResetStat.Location = new System.Drawing.Point(6, 90);
            this.btnResetStat.Name = "btnResetStat";
            this.btnResetStat.Size = new System.Drawing.Size(75, 23);
            this.btnResetStat.TabIndex = 4;
            this.btnResetStat.Text = "Reset";
            this.btnResetStat.UseVisualStyleBackColor = true;
            this.btnResetStat.Click += new System.EventHandler(this.btnResetStat_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Score";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Lost games:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Won games:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Played games:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnOtkrij);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.Message);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.WW);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(597, 388);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 17;
            this.splitContainer1.TabStop = false;
            // 
            // btnOtkrij
            // 
            this.btnOtkrij.Location = new System.Drawing.Point(70, 362);
            this.btnOtkrij.Name = "btnOtkrij";
            this.btnOtkrij.Size = new System.Drawing.Size(75, 23);
            this.btnOtkrij.TabIndex = 17;
            this.btnOtkrij.Text = "Uncover map";
            this.btnOtkrij.UseVisualStyleBackColor = true;
            this.btnOtkrij.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOtkrij_MouseDown);
            this.btnOtkrij.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOtkrij_MouseUp);
            // 
            // WW
            // 
            this.WW.KeyInputEnabled = true;
            this.WW.Location = new System.Drawing.Point(10, 10);
            this.WW.Name = "WW";
            this.WW.Size = new System.Drawing.Size(320, 320);
            this.WW.SquareDimension = 80;
            this.WW.TabIndex = 0;
            this.WW.TabStop = true;
            this.WW.GameEnded += new System.EventHandler<CustomControls.GameEndedEventArgs>(this.WW_GameEnded);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 388);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Wumpus World";
            ((System.ComponentModel.ISupportInitialize)(this.WumpusCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Visina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sirina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoleCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.NumericUpDown WumpusCount;
        private System.Windows.Forms.NumericUpDown Visina;
        private System.Windows.Forms.NumericUpDown Sirina;
        private System.Windows.Forms.NumericUpDown HoleCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreate;
        private CustomControls.WumpusWorldBoard WW;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Button btnKorak;
        private System.Windows.Forms.Button btnOdigraj;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblBrojPoraza;
        private System.Windows.Forms.Label lblBrojPobjeda;
        private System.Windows.Forms.Label lblBrojIgara;
        private System.Windows.Forms.Button btnResetStat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProsjecnaUspjesnost;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblUspjesnost;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOtkrij;
    }
}

