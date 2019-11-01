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
            this.InitialPlayGameButton = new System.Windows.Forms.Button();
            this.player1Label = new System.Windows.Forms.Label();
            this.user1TextBox = new System.Windows.Forms.TextBox();
            this.player2Label = new System.Windows.Forms.Label();
            this.user2TextBox = new System.Windows.Forms.TextBox();
            this.RegisterUserButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmUserButton = new System.Windows.Forms.Button();
            this.ConfigureGameTimeBox = new System.Windows.Forms.GroupBox();
            this.StartGameBox = new System.Windows.Forms.GroupBox();
            this.SignInButton = new System.Windows.Forms.Button();
            this.SeeStatsButtton = new System.Windows.Forms.Button();
            this.TimeInfoBox = new System.Windows.Forms.GroupBox();
            this.BlacksTimeLabel = new System.Windows.Forms.Label();
            this.WhitesTimeLable = new System.Windows.Forms.Label();
            this.ChooseUserGameBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ReplayGameButton = new System.Windows.Forms.Button();
            this.UsersGamesListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutesPerPlayer)).BeginInit();
            this.ConfigureGameTimeBox.SuspendLayout();
            this.StartGameBox.SuspendLayout();
            this.TimeInfoBox.SuspendLayout();
            this.ChooseUserGameBox.SuspendLayout();
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
            // InitialPlayGameButton
            // 
            this.InitialPlayGameButton.Location = new System.Drawing.Point(20, 129);
            this.InitialPlayGameButton.Name = "InitialPlayGameButton";
            this.InitialPlayGameButton.Size = new System.Drawing.Size(114, 74);
            this.InitialPlayGameButton.TabIndex = 1;
            this.InitialPlayGameButton.Text = "Play";
            this.InitialPlayGameButton.UseVisualStyleBackColor = true;
            this.InitialPlayGameButton.Click += new System.EventHandler(this.InitialPlayGameButton_Click);
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(17, 18);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(54, 17);
            this.player1Label.TabIndex = 7;
            this.player1Label.Text = "User 1:";
            // 
            // user1TextBox
            // 
            this.user1TextBox.Location = new System.Drawing.Point(77, 18);
            this.user1TextBox.Name = "user1TextBox";
            this.user1TextBox.Size = new System.Drawing.Size(100, 22);
            this.user1TextBox.TabIndex = 10;
            this.user1TextBox.TextChanged += new System.EventHandler(this.user1TextBox_TextChanged);
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Location = new System.Drawing.Point(17, 72);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(54, 17);
            this.player2Label.TabIndex = 8;
            this.player2Label.Text = "User 2:";
            // 
            // user2TextBox
            // 
            this.user2TextBox.Location = new System.Drawing.Point(77, 69);
            this.user2TextBox.Name = "user2TextBox";
            this.user2TextBox.Size = new System.Drawing.Size(100, 22);
            this.user2TextBox.TabIndex = 9;
            this.user2TextBox.TextChanged += new System.EventHandler(this.user2TextBox_TextChanged);
            // 
            // RegisterUserButton
            // 
            this.RegisterUserButton.Location = new System.Drawing.Point(77, 322);
            this.RegisterUserButton.Name = "RegisterUserButton";
            this.RegisterUserButton.Size = new System.Drawing.Size(119, 74);
            this.RegisterUserButton.TabIndex = 0;
            this.RegisterUserButton.Text = "Register User";
            this.RegisterUserButton.UseVisualStyleBackColor = true;
            this.RegisterUserButton.Click += new System.EventHandler(this.RegisterUserButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(123, 420);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(73, 17);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(217, 415);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 22);
            this.usernameTextBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(123, 462);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(73, 17);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(217, 462);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(100, 22);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // ConfirmUserButton
            // 
            this.ConfirmUserButton.Location = new System.Drawing.Point(77, 510);
            this.ConfirmUserButton.Name = "ConfirmUserButton";
            this.ConfirmUserButton.Size = new System.Drawing.Size(119, 74);
            this.ConfirmUserButton.TabIndex = 2;
            this.ConfirmUserButton.Text = "Confirm";
            this.ConfirmUserButton.UseVisualStyleBackColor = true;
            this.ConfirmUserButton.Click += new System.EventHandler(this.ConfirmUserButton_Click);
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
            // StartGameBox
            // 
            this.StartGameBox.BackColor = System.Drawing.Color.SandyBrown;
            this.StartGameBox.Controls.Add(this.SignInButton);
            this.StartGameBox.Controls.Add(this.RegisterUserButton);
            this.StartGameBox.Controls.Add(this.SeeStatsButtton);
            this.StartGameBox.Controls.Add(this.ConfirmUserButton);
            this.StartGameBox.Controls.Add(this.passwordTextBox);
            this.StartGameBox.Controls.Add(this.passwordLabel);
            this.StartGameBox.Controls.Add(this.usernameTextBox);
            this.StartGameBox.Controls.Add(this.usernameLabel);
            this.StartGameBox.Controls.Add(this.user2TextBox);
            this.StartGameBox.Controls.Add(this.player2Label);
            this.StartGameBox.Controls.Add(this.user1TextBox);
            this.StartGameBox.Controls.Add(this.player1Label);
            this.StartGameBox.Controls.Add(this.InitialPlayGameButton);
            this.StartGameBox.Location = new System.Drawing.Point(101, 18);
            this.StartGameBox.Name = "StartGameBox";
            this.StartGameBox.Size = new System.Drawing.Size(495, 600);
            this.StartGameBox.TabIndex = 11;
            this.StartGameBox.TabStop = false;
            // 
            // SignInButton
            // 
            this.SignInButton.Location = new System.Drawing.Point(328, 510);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(114, 74);
            this.SignInButton.TabIndex = 11;
            this.SignInButton.Text = "Sign in";
            this.SignInButton.UseVisualStyleBackColor = true;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // SeeStatsButtton
            // 
            this.SeeStatsButtton.Location = new System.Drawing.Point(328, 324);
            this.SeeStatsButtton.Name = "SeeStatsButtton";
            this.SeeStatsButtton.Size = new System.Drawing.Size(114, 72);
            this.SeeStatsButtton.TabIndex = 0;
            this.SeeStatsButtton.Text = "See user statistics";
            this.SeeStatsButtton.UseVisualStyleBackColor = true;
            this.SeeStatsButtton.Click += new System.EventHandler(this.button1_Click);
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
            // ChooseUserGameBox
            // 
            this.ChooseUserGameBox.BackColor = System.Drawing.Color.SandyBrown;
            this.ChooseUserGameBox.Controls.Add(this.button1);
            this.ChooseUserGameBox.Controls.Add(this.nextButton);
            this.ChooseUserGameBox.Controls.Add(this.label1);
            this.ChooseUserGameBox.Controls.Add(this.ReplayGameButton);
            this.ChooseUserGameBox.Controls.Add(this.UsersGamesListBox);
            this.ChooseUserGameBox.Location = new System.Drawing.Point(76, 272);
            this.ChooseUserGameBox.Name = "ChooseUserGameBox";
            this.ChooseUserGameBox.Size = new System.Drawing.Size(495, 264);
            this.ChooseUserGameBox.TabIndex = 12;
            this.ChooseUserGameBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "BackToStartPage";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(414, 202);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 3;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please choose a game";
            // 
            // ReplayGameButton
            // 
            this.ReplayGameButton.Location = new System.Drawing.Point(190, 169);
            this.ReplayGameButton.Name = "ReplayGameButton";
            this.ReplayGameButton.Size = new System.Drawing.Size(176, 89);
            this.ReplayGameButton.TabIndex = 1;
            this.ReplayGameButton.Text = "ReplayGame";
            this.ReplayGameButton.UseVisualStyleBackColor = true;
            this.ReplayGameButton.Click += new System.EventHandler(this.ReplayGameButton_Click);
            // 
            // UsersGamesListBox
            // 
            this.UsersGamesListBox.FormattingEnabled = true;
            this.UsersGamesListBox.ItemHeight = 16;
            this.UsersGamesListBox.Location = new System.Drawing.Point(6, 79);
            this.UsersGamesListBox.Name = "UsersGamesListBox";
            this.UsersGamesListBox.Size = new System.Drawing.Size(336, 84);
            this.UsersGamesListBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1364, 712);
            this.Controls.Add(this.ChooseUserGameBox);
            this.Controls.Add(this.TimeInfoBox);
            this.Controls.Add(this.ConfigureGameTimeBox);
            this.Controls.Add(this.StartGameBox);
            this.Controls.Add(this.BoardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutesPerPlayer)).EndInit();
            this.ConfigureGameTimeBox.ResumeLayout(false);
            this.StartGameBox.ResumeLayout(false);
            this.StartGameBox.PerformLayout();
            this.TimeInfoBox.ResumeLayout(false);
            this.TimeInfoBox.PerformLayout();
            this.ChooseUserGameBox.ResumeLayout(false);
            this.ChooseUserGameBox.PerformLayout();
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
        private Button InitialPlayGameButton;
        private Button RegisterUserButton;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Button ConfirmUserButton;
        private Label player1Label;
        private TextBox user1TextBox;
        private Label player2Label;
        private TextBox user2TextBox;
        private GroupBox ConfigureGameTimeBox;
        private GroupBox StartGameBox;
        private GroupBox TimeInfoBox;
        private Label BlacksTimeLabel;
        private Label WhitesTimeLable;
        private Button SignInButton;
        private Button SeeStatsButtton;
        private GroupBox ChooseUserGameBox;
        private ListBox UsersGamesListBox;
        private Label label1;
        private Button ReplayGameButton;
        private Button nextButton;
        private Button button1;
    }
}

