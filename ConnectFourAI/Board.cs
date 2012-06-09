using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ConnectFourAI
{
    [Serializable]
    class Board
    {
        int[] boardarr;
        public  readonly int PLAYER_ONE = 1, PLAYER_TWO = -1, EMPTY = 0;
        public int lastMove_PlayeroneRow { get; set; }
        public int lastMove_PlayeroneCol { get; set; }

        public int lastMove_PlayertwoRow { get; set; }
        public int lastMove_PlayertwoCol { get; set; }
        public int count = 0;
        //  public int lastMove_Playertwo{get;set;}
        public String console { get; set; }



        public Board()
        {
            boardarr = new int[43];
            for (int i = 1; i <= 42; i++)
            {

                boardarr[i] = EMPTY;
            }

        }

        public int[] getPositionArray()
        {

            return boardarr;

        }




        public Boolean move_playerone(int pos, int row, int col)
        {

            if (pos <= 42 && pos >= 1)
            {

                if (isColumnFilled(pos) == false)
                    return false;


                if (count % 2 == 0)
                {
                    boardarr[pos] = PLAYER_ONE;
                    lastMove_PlayeroneRow = row;
                    lastMove_PlayeroneCol = col;
                    return true;
                }
                //else
                //{
                //    boardarr[pos] = PLAYER_TWO;
                //    lastMove_PlayertwoRow = row;
                //    lastMove_PlayertwoCol = col;
                //    return true;

                //}
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean move_playertwo(int pos, int row, int col)
        {

            if (pos <= 42 && pos >= 1)
            {

                if (isColumnFilled(pos) == false)
                    return false;

                else if (count%2!=0)
                {

                    boardarr[pos] = PLAYER_TWO;
                    lastMove_PlayertwoRow = row;
                    lastMove_PlayertwoCol = col;
                    return true;

                }
                else
                    return false;
            }
            else
                return false;
        }



        public int RCtoint(int row, int col)
        {

            if (row <= 6 && col <= 7 && col > 0 && row > 0)
                return ((row - 1) * 7) + col;

            else
                return -1;

        }


        public int[] IntoRC(int num)
        {

            int tmp = 1;
            if (num <= 42 && num >= 1)
                for (int r = 1; r <= 6; r++)
                    for (int c = 1; c <= 7; c++)
                    {
                        if (tmp == num)
                            return (new int[] { r, c });

                        tmp++;

                    }

            return (new int[] { EMPTY, EMPTY });
        }


        public void drawBoard(Panel x)
        {

            // Get the graphics object 
            Graphics gfx = x.CreateGraphics();
            // x.BackColor = Color.Yellow;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            // Create a new pen that we shall use for drawing the line 
            Pen myPen = new Pen(Color.Silver);
            SolidBrush rd = new SolidBrush(Color.Red);
            SolidBrush blck = new SolidBrush(Color.Black);
            // Loop and create a new line 10 pixels below the last one 

            RectangleF[] rects = new RectangleF[43];

            float posx = 0, posy = 0;

            for (int i = 1; i <= 42; i++)
            {


                if (i % 7 == 0)
                {

                    rects[i] = new RectangleF(posx, posy, 50.0F, 50.0F);
                    posx = 0.0F;
                    posy += 50.0F;
                    if (boardarr[i] == PLAYER_ONE)
                    {
                        gfx.FillEllipse(rd, rects[i]);
                    }
                    else if (boardarr[i] == PLAYER_TWO)
                    {

                        gfx.FillEllipse(blck, rects[i]);
                    }
                }
                else
                {
                    rects[i] = new RectangleF(posx, posy, 50.0F, 50.0F);
                    posx += 50.0F;
                    if (boardarr[i] == PLAYER_ONE)
                    {
                        gfx.FillEllipse(rd, rects[i]);
                    }
                    else if (boardarr[i] == PLAYER_TWO)
                    {

                        gfx.FillEllipse(blck, rects[i]);
                    }
                }
            }
            gfx.DrawRectangles(myPen, rects);

        }

        public void print_to_Console(String txt)
        {



        }

        public Boolean isColumnFilled(int positon)
        {


            if (positon <= 35)
            {

                int currtemp = positon + 7;
                if (boardarr[currtemp] == PLAYER_ONE || boardarr[currtemp] == PLAYER_TWO)
                {

                    return true;
                }
                else
                    return false;


            }

            return true;


        }

        public int ColumnFilledTill(int colNum)
        {


            int currtemp = colNum + 35;

            while (currtemp >= 1)
            {

                if (boardarr[currtemp] == EMPTY)
                {

                    return currtemp;

                }
                currtemp = currtemp - 7;


            }

            return EMPTY;
        }

        public Boolean isDraw()
        {
            int nempty = 0;

            for (int i = 1; i <= 42; i++) {

                if (boardarr[i] == EMPTY) {

                    nempty++;
                
                }
            
            }

            if (nempty == 0)
                return true;
            else
                return false;
        }

    }
}
