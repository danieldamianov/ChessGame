using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButtonStartGame = new System.Windows.Forms.Button();
            this.numericUpDownMinutesPerPlayer = new System.Windows.Forms.NumericUpDown();
            this.LabelTime = new System.Windows.Forms.Label();
            this.BoardPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ConfigureGameTimeBox = new System.Windows.Forms.GroupBox();
            this.TimeInfoBox = new System.Windows.Forms.GroupBox();
            this.BlacksTimeLabel = new System.Windows.Forms.Label();
            this.WhitesTimeLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutesPerPlayer)).BeginInit();
            this.ConfigureGameTimeBox.SuspendLayout();
            this.TimeInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonStartGame
            // 
            this.ButtonStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonStartGame.Location = new System.Drawing.Point(103, 115);
            this.ButtonStartGame.Name = "ButtonStartGame";
            this.ButtonStartGame.Size = new System.Drawing.Size(138, 71);
            this.ButtonStartGame.TabIndex = 2;
            this.ButtonStartGame.Text = "Play";
            this.ButtonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click_1);
            // 
            // numericUpDownMinutesPerPlayer
            // 
            this.numericUpDownMinutesPerPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownMinutesPerPlayer.Location = new System.Drawing.Point(163, 33);
            this.numericUpDownMinutesPerPlayer.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMinutesPerPlayer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMinutesPerPlayer.Name = "numericUpDownMinutesPerPlayer";
            this.numericUpDownMinutesPerPlayer.Size = new System.Drawing.Size(130, 49);
            this.numericUpDownMinutesPerPlayer.TabIndex = 1;
            this.numericUpDownMinutesPerPlayer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelTime
            // 
            this.LabelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelTime.Location = new System.Drawing.Point(6, 33);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(190, 44);
            this.LabelTime.TabIndex = 0;
            this.LabelTime.Text = "Minutes";
            // 
            // BoardPanel
            // 
            this.BoardPanel.Location = new System.Drawing.Point(608, 18);
            this.BoardPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(747, 685);
            this.BoardPanel.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(115, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 6;
            // 
            // ConfigureGameTimeBox
            // 
            this.ConfigureGameTimeBox.BackColor = System.Drawing.Color.SandyBrown;
            this.ConfigureGameTimeBox.Controls.Add(this.numericUpDownMinutesPerPlayer);
            this.ConfigureGameTimeBox.Controls.Add(this.LabelTime);
            this.ConfigureGameTimeBox.Controls.Add(this.ButtonStartGame);
            this.ConfigureGameTimeBox.Location = new System.Drawing.Point(101, 18);
            this.ConfigureGameTimeBox.Name = "ConfigureGameTimeBox";
            this.ConfigureGameTimeBox.Size = new System.Drawing.Size(331, 194);
            this.ConfigureGameTimeBox.TabIndex = 0;
            this.ConfigureGameTimeBox.TabStop = false;
            // 
            // TimeInfoBox
            // 
            this.TimeInfoBox.BackColor = System.Drawing.Color.SandyBrown;
            this.TimeInfoBox.Controls.Add(this.BlacksTimeLabel);
            this.TimeInfoBox.Controls.Add(this.WhitesTimeLable);
            this.TimeInfoBox.Controls.Add(this.textBox2);
            this.TimeInfoBox.Controls.Add(this.textBox1);
            this.TimeInfoBox.Location = new System.Drawing.Point(101, 18);
            this.TimeInfoBox.Name = "TimeInfoBox";
            this.TimeInfoBox.Size = new System.Drawing.Size(221, 100);
            this.TimeInfoBox.TabIndex = 7;
            this.TimeInfoBox.TabStop = false;
            // 
            // BlacksTimeLabel
            // 
            this.BlacksTimeLabel.AutoSize = true;
            this.BlacksTimeLabel.Location = new System.Drawing.Point(9, 42);
            this.BlacksTimeLabel.Name = "BlacksTimeLabel";
            this.BlacksTimeLabel.Size = new System.Drawing.Size(100, 17);
            this.BlacksTimeLabel.TabIndex = 8;
            this.BlacksTimeLabel.Text = "Time of Blacks";
            // 
            // WhitesTimeLable
            // 
            this.WhitesTimeLable.AutoSize = true;
            this.WhitesTimeLable.Location = new System.Drawing.Point(7, 11);
            this.WhitesTimeLable.Name = "WhitesTimeLable";
            this.WhitesTimeLable.Size = new System.Drawing.Size(102, 17);
            this.WhitesTimeLable.TabIndex = 7;
            this.WhitesTimeLable.Text = "Time of Whites";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1364, 712);
            this.Controls.Add(this.TimeInfoBox);
            this.Controls.Add(this.ConfigureGameTimeBox);
            this.Controls.Add(this.BoardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutesPerPlayer)).EndInit();
            this.ConfigureGameTimeBox.ResumeLayout(false);
            this.TimeInfoBox.ResumeLayout(false);
            this.TimeInfoBox.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }





        #endregion

        private System.Windows.Forms.Button ButtonStartGame;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutesPerPlayer;
        private System.Windows.Forms.Label LabelTime;
        private Button[,] board;
        private FlowLayoutPanel BoardPanel;
        private Timer timer1;
        private Timer timer2;
        private TextBox textBox1;
        private TextBox textBox2;
        private GroupBox ConfigureGameTimeBox;
        private GroupBox TimeInfoBox;
        private Label BlacksTimeLabel;
        private Label WhitesTimeLable;
    }
}

