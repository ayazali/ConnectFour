using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Threading;
using System.Media;
namespace ConnectFourAI
{
    public partial class Form1 : Form
    {

        Board brd;
        ConnectFourAIClass cfai;
        Button[] btns = new Button[7];
        MenuItem option, hlp, nGame, ext, aboutDev,advanced;

        public Form1()
        {
            InitializeComponent();
           
            panel1.Paint += new PaintEventHandler(panel1_Paint);
        }

        public void AddMenu()
        {
            MainMenu mnuFileMenu = new MainMenu();

            option = new MenuItem("&Options");
            hlp = new MenuItem("&Help");
            aboutDev = new MenuItem("&About Developers");
            nGame = new MenuItem("&New Game");
            ext = new MenuItem("&Exit");
            advanced = new MenuItem("&Show/Hide Developer Console");

            advanced.Shortcut = System.Windows.Forms.Shortcut.F1;

            mnuFileMenu.MenuItems.Add(option);
            mnuFileMenu.MenuItems.Add(hlp);
            hlp.MenuItems.Add(aboutDev);
            option.MenuItems.Add(nGame);
            option.MenuItems.Add(advanced);
            option.MenuItems.Add(ext);


            nGame.Click += new System.EventHandler(this.menuItems_onClick);
            ext.Click += new System.EventHandler(this.menuItems_onClick);
            aboutDev.Click += new System.EventHandler(this.menuItems_onClick);
            advanced.Click += new System.EventHandler(this.menuItems_onClick);
            this.Menu = mnuFileMenu;
        }

        /// <summary>
        /// Event Listener for Panel1 containing the grid is redrawn, on the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void panel1_Paint(object sender, PaintEventArgs e)
        {
            updateBoardAndText();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddMenu();
            panel1.Width = 400;
            panel1.Height = 350;
            brd = new Board();

            cfai = new ConnectFourAIClass(brd);
            labelConsole.Text = labelConsole.Text + brd.console;


            flowLayoutPanel1.Width = 700;
            flowLayoutPanel1.Height = 60;
            for (int i = 0; i < btns.Length; i++)
            {

                btns[i] = new Button();
                btns[i].Width = 50;
                btns[i].Height = 50;
                btns[i].BackgroundImage = global::ConnectFourAI.Properties.Resources.arrow_down_small;
                btns[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                btns[i].Margin = new Padding(0);
                btns[i].Click += new EventHandler(buttons_panel_onClick);
                flowLayoutPanel1.Controls.Add(btns[i]);


            }
            SoundPlayer simpleSound = new SoundPlayer(global::ConnectFourAI.Properties.Resources.start);
            simpleSound.Play();
        }

        void buttons_panel_disable() {



            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Enabled = false;
            
            
            }
        
        }
        void buttons_panel_onClick(object sender, EventArgs e)
        {


            for (int i = 0; i < btns.Length; i++)
            {

                if (btns[i].Equals(sender))
                {

                    int move = brd.ColumnFilledTill(i + 1);

                    if (move != brd.EMPTY)
                    {
                        brd.move_playerone(move, brd.IntoRC(move)[0], brd.IntoRC(move)[1]);
                        cfai.nextMove();
                        cfai.nextMove();
                        panel1.Invalidate();

                        if (brd.isDraw() && cfai.isWin == brd.EMPTY)
                        {
                            buttons_panel_disable();
                            updateBoardAndText();
                            Thread.Sleep(2000);
                            flowLayoutPanel1.Hide();
                            panel1.Hide();
                            devPanel.Hide();
                            playerName_panel.Hide();
                            winImage.Image = global::ConnectFourAI.Properties.Resources.draw1;
                            winImage.Show();
                            SoundPlayer simpleSound = new SoundPlayer(global::ConnectFourAI.Properties.Resources.draw);
                            simpleSound.Play();
                        }

                    }
                    else
                        MessageBox.Show("Column is Filled !");
                }

            }

            if (cfai.isWin == brd.PLAYER_ONE)
            {

                buttons_panel_disable();
                updateBoardAndText();
                Thread.Sleep(2000);
                flowLayoutPanel1.Hide();
                panel1.Hide();
                devPanel.Hide();
                playerName_panel.Hide();
                winImage.Image = global::ConnectFourAI.Properties.Resources.You_Win;
                winImage.Show();
                SoundPlayer simpleSound = new SoundPlayer(global::ConnectFourAI.Properties.Resources.you_have_won);
                simpleSound.Play();


            }
            else if (cfai.isWin == brd.PLAYER_TWO)
            {
                buttons_panel_disable();
                updateBoardAndText();
                Thread.Sleep(2000);
                flowLayoutPanel1.Hide();
                panel1.Hide();
                devPanel.Hide();
                playerName_panel.Hide();
                winImage.Image = global::ConnectFourAI.Properties.Resources.game_over;
                winImage.Show();
                SoundPlayer simpleSound = new SoundPlayer(global::ConnectFourAI.Properties.Resources.gameover);
                simpleSound.Play();


            }






        }

        public void menuItems_onClick(object sender, EventArgs e)
        {



            if (sender.Equals(nGame)) {

                Application.Restart();

            
            }
            else if (sender.Equals(ext)) {

                Application.Exit();

            }
            else if (sender.Equals(advanced)) {

                if (devPanel.Visible == true)
                {
                    devPanel.Visible = false;
                }
                else
                    devPanel.Visible =true;
                    
            
            }
            else if (sender.Equals(aboutDev)) {

                Form frm = new AboutDev();
                frm.Show();
            }

            


        }


        //protected override void OnPaint(PaintEventArgs paintEvnt)
        //{
        //    updateBoardAndText();
        //}

        private void updateBoardAndText()
        {
            brd.drawBoard(panel1);
            labelConsole.Text = brd.console;
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            String tmp = textBoxMoveX.Text;

            String tmp2 = textBoxMoveY.Text;




            if (tmp.Length > 0 && tmp2.Length > 0)
            {
                int posr = Convert.ToInt32(tmp);
                int posc = Convert.ToInt32(tmp2);

                if (!brd.move_playerone(brd.RCtoint(posr, posc), posr, posc))
                    MessageBox.Show("Invalid Operation");

                cfai.nextMove();
            }
            else
            {
                MessageBox.Show("Please fill All the fields");
            }

            //panel1.Refresh();
            panel1.Invalidate();
        }

        private void btn_startGame_Click(object sender, EventArgs e)
        {
            if (textBox_playername.Text.ToString().Length > 0)
            {

                label_playerone_name.Text = textBox_playername.Text.ToString();
                panel2.Hide();
                playerName_panel.Show();
                flowLayoutPanel1.Show();
                panel1.Show();


            }
            else
                MessageBox.Show("Please Enter a Name");

        }

    }
}
