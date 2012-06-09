namespace ConnectFourAI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMove = new System.Windows.Forms.Button();
            this.textBoxMoveX = new System.Windows.Forms.TextBox();
            this.textBoxMoveY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelConsole = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.devPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_startGame = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_playername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.playerName_panel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label_playerone_name = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.winImage = new System.Windows.Forms.PictureBox();
            this.devPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.playerName_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 238);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(173, 3);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 39);
            this.buttonMove.TabIndex = 1;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // textBoxMoveX
            // 
            this.textBoxMoveX.Location = new System.Drawing.Point(67, 4);
            this.textBoxMoveX.Name = "textBoxMoveX";
            this.textBoxMoveX.Size = new System.Drawing.Size(100, 20);
            this.textBoxMoveX.TabIndex = 2;
            // 
            // textBoxMoveY
            // 
            this.textBoxMoveY.Location = new System.Drawing.Point(67, 23);
            this.textBoxMoveY.Name = "textBoxMoveY";
            this.textBoxMoveY.Size = new System.Drawing.Size(100, 20);
            this.textBoxMoveY.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Row";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Column";
            // 
            // labelConsole
            // 
            this.labelConsole.AutoSize = true;
            this.labelConsole.Location = new System.Drawing.Point(8, 48);
            this.labelConsole.Name = "labelConsole";
            this.labelConsole.Size = new System.Drawing.Size(48, 13);
            this.labelConsole.TabIndex = 6;
            this.labelConsole.Text = "Console:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 74);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 60);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Visible = false;
            // 
            // devPanel
            // 
            this.devPanel.Controls.Add(this.buttonMove);
            this.devPanel.Controls.Add(this.textBoxMoveX);
            this.devPanel.Controls.Add(this.textBox1);
            this.devPanel.Controls.Add(this.textBoxMoveY);
            this.devPanel.Controls.Add(this.labelConsole);
            this.devPanel.Controls.Add(this.label1);
            this.devPanel.Controls.Add(this.label2);
            this.devPanel.Location = new System.Drawing.Point(464, 12);
            this.devPanel.Name = "devPanel";
            this.devPanel.Size = new System.Drawing.Size(308, 102);
            this.devPanel.TabIndex = 9;
            this.devPanel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_startGame);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox_playername);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(249, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 159);
            this.panel2.TabIndex = 11;
            // 
            // btn_startGame
            // 
            this.btn_startGame.Location = new System.Drawing.Point(130, 103);
            this.btn_startGame.Name = "btn_startGame";
            this.btn_startGame.Size = new System.Drawing.Size(75, 23);
            this.btn_startGame.TabIndex = 3;
            this.btn_startGame.Text = "Start Game";
            this.btn_startGame.UseVisualStyleBackColor = true;
            this.btn_startGame.Click += new System.EventHandler(this.btn_startGame_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Player Name";
            // 
            // textBox_playername
            // 
            this.textBox_playername.Location = new System.Drawing.Point(130, 61);
            this.textBox_playername.Name = "textBox_playername";
            this.textBox_playername.Size = new System.Drawing.Size(175, 20);
            this.textBox_playername.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(306, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Please Enter Name Below and press Start";
            // 
            // playerName_panel
            // 
            this.playerName_panel.Controls.Add(this.label7);
            this.playerName_panel.Controls.Add(this.label_playerone_name);
            this.playerName_panel.Controls.Add(this.label6);
            this.playerName_panel.Controls.Add(this.label5);
            this.playerName_panel.Location = new System.Drawing.Point(15, 12);
            this.playerName_panel.Name = "playerName_panel";
            this.playerName_panel.Size = new System.Drawing.Size(200, 56);
            this.playerName_panel.TabIndex = 12;
            this.playerName_panel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(45, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "         ";
            // 
            // label_playerone_name
            // 
            this.label_playerone_name.AutoSize = true;
            this.label_playerone_name.Location = new System.Drawing.Point(4, 30);
            this.label_playerone_name.Name = "label_playerone_name";
            this.label_playerone_name.Size = new System.Drawing.Size(35, 13);
            this.label_playerone_name.TabIndex = 2;
            this.label_playerone_name.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.MenuText;
            this.label6.Location = new System.Drawing.Point(45, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Jarvis";
            // 
            // winImage
            // 
            this.winImage.Image = global::ConnectFourAI.Properties.Resources.draw1;
            this.winImage.Location = new System.Drawing.Point(175, 160);
            this.winImage.Name = "winImage";
            this.winImage.Size = new System.Drawing.Size(400, 400);
            this.winImage.TabIndex = 10;
            this.winImage.TabStop = false;
            this.winImage.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.playerName_panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.devPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.winImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Connect Four";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.devPanel.ResumeLayout(false);
            this.devPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.playerName_panel.ResumeLayout(false);
            this.playerName_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.TextBox textBoxMoveX;
        private System.Windows.Forms.TextBox textBoxMoveY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelConsole;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel devPanel;
        private System.Windows.Forms.PictureBox winImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_playername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_startGame;
        private System.Windows.Forms.Panel playerName_panel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_playerone_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;

        
    }
}

