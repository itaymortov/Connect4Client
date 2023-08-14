namespace ClientSideConnect4
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
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.labelAccount = new System.Windows.Forms.Label();
            this.labelAccountName = new System.Windows.Forms.Label();
            this.labelAccountPhone = new System.Windows.Forms.Label();
            this.labelAccountCountry = new System.Windows.Forms.Label();
            this.labelAccountTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.GamesComboBox = new System.Windows.Forms.ComboBox();
            this.TextGame = new System.Windows.Forms.Label();
            this.StartGameText = new System.Windows.Forms.Label();
            this.winnerText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(22, 211);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(167, 24);
            this.buttonRegister.TabIndex = 5;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.Register_Func);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(22, 182);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(167, 25);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(22, 158);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(168, 20);
            this.textBoxID.TabIndex = 7;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(22, 140);
            this.labelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 13);
            this.labelID.TabIndex = 8;
            this.labelID.Text = "ID:";
            // 
            // labelAccount
            // 
            this.labelAccount.AutoSize = true;
            this.labelAccount.Location = new System.Drawing.Point(70, 64);
            this.labelAccount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(0, 13);
            this.labelAccount.TabIndex = 9;
            // 
            // labelAccountName
            // 
            this.labelAccountName.AutoSize = true;
            this.labelAccountName.Location = new System.Drawing.Point(70, 81);
            this.labelAccountName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAccountName.Name = "labelAccountName";
            this.labelAccountName.Size = new System.Drawing.Size(0, 13);
            this.labelAccountName.TabIndex = 10;
            // 
            // labelAccountPhone
            // 
            this.labelAccountPhone.AutoSize = true;
            this.labelAccountPhone.Location = new System.Drawing.Point(70, 98);
            this.labelAccountPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAccountPhone.Name = "labelAccountPhone";
            this.labelAccountPhone.Size = new System.Drawing.Size(0, 13);
            this.labelAccountPhone.TabIndex = 11;
            // 
            // labelAccountCountry
            // 
            this.labelAccountCountry.AutoSize = true;
            this.labelAccountCountry.Location = new System.Drawing.Point(70, 116);
            this.labelAccountCountry.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAccountCountry.Name = "labelAccountCountry";
            this.labelAccountCountry.Size = new System.Drawing.Size(0, 13);
            this.labelAccountCountry.TabIndex = 12;
            // 
            // labelAccountTitle
            // 
            this.labelAccountTitle.AutoSize = true;
            this.labelAccountTitle.Location = new System.Drawing.Point(22, 46);
            this.labelAccountTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAccountTitle.Name = "labelAccountTitle";
            this.labelAccountTitle.Size = new System.Drawing.Size(104, 13);
            this.labelAccountTitle.TabIndex = 13;
            this.labelAccountTitle.Text = "Account information:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Country: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Phone: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Name: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "ID: ";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(22, 192);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(167, 25);
            this.buttonLogout.TabIndex = 18;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Blue;
            this.pictureBox1.Location = new System.Drawing.Point(250, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 600);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(963, 46);
            this.StartGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(125, 20);
            this.StartGameButton.TabIndex = 20;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // GamesComboBox
            // 
            this.GamesComboBox.FormattingEnabled = true;
            this.GamesComboBox.Location = new System.Drawing.Point(963, 98);
            this.GamesComboBox.Name = "GamesComboBox";
            this.GamesComboBox.Size = new System.Drawing.Size(121, 21);
            this.GamesComboBox.TabIndex = 21;
            this.GamesComboBox.SelectedIndexChanged += new System.EventHandler(this.GamesComboBox_SelectedIndexChanged);
            // 
            // TextGame
            // 
            this.TextGame.AutoSize = true;
            this.TextGame.Location = new System.Drawing.Point(963, 81);
            this.TextGame.Name = "TextGame";
            this.TextGame.Size = new System.Drawing.Size(116, 13);
            this.TextGame.TabIndex = 22;
            this.TextGame.Text = "Pick a game to restore:";
            this.TextGame.Click += new System.EventHandler(this.TextGame_Click);
            // 
            // StartGameText
            // 
            this.StartGameText.AutoSize = true;
            this.StartGameText.Location = new System.Drawing.Point(966, 28);
            this.StartGameText.Name = "StartGameText";
            this.StartGameText.Size = new System.Drawing.Size(139, 13);
            this.StartGameText.TabIndex = 23;
            this.StartGameText.Text = "Please login to play a game.";
            // 
            // winnerText
            // 
            this.winnerText.AutoSize = true;
            this.winnerText.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.winnerText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.winnerText.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.winnerText.Location = new System.Drawing.Point(969, 292);
            this.winnerText.Name = "winnerText";
            this.winnerText.Size = new System.Drawing.Size(0, 26);
            this.winnerText.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 604);
            this.Controls.Add(this.winnerText);
            this.Controls.Add(this.StartGameText);
            this.Controls.Add(this.TextGame);
            this.Controls.Add(this.GamesComboBox);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAccountTitle);
            this.Controls.Add(this.labelAccountCountry);
            this.Controls.Add(this.labelAccountPhone);
            this.Controls.Add(this.labelAccountName);
            this.Controls.Add(this.labelAccount);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonRegister);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelAccount;
        private System.Windows.Forms.Label labelAccountName;
        private System.Windows.Forms.Label labelAccountPhone;
        private System.Windows.Forms.Label labelAccountCountry;
        private System.Windows.Forms.Label labelAccountTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.ComboBox GamesComboBox;
        private System.Windows.Forms.Label TextGame;
        private System.Windows.Forms.Label StartGameText;
        private System.Windows.Forms.Label winnerText;
    }
}