using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConnectFourAI
{
    [Serializable]
    class ConnectFourAIClass
    {
        public Board ConnectFourBoard { get; set; }
        public CustomHeuristicTree CusHeuristic;
        public ConnectFourAI.CustomHeuristicTree.HNode maxHeurisitic;
        
        int position;
        public int rowLastMoveOtherPlayer { get; set; }
        public int colLastMoveOtherPlayer { get; set; }
        public int redRow;
        public int isWin { get; set; } 

        public int redCol;
        
        //int HorCount = 0;
        //int VerCount = 0;
        //int LeftCount = 0;
        //int RightCount = 0;
        public int TotalHeuristicCount = 0;
        public int[] PositionArray;
        public ConnectFourAIClass(Board cnboard)
        {
            ConnectFourBoard = cnboard;
            isWin = ConnectFourBoard.EMPTY;
            PositionArray = ConnectFourBoard.getPositionArray();
            //CusHeuristic(this).
            //nextMove();
        }
        public void nextMove()
        {
            if(ConnectFourBoard.count % 2==0){
            
            rowLastMoveOtherPlayer = ConnectFourBoard.lastMove_PlayeroneRow;
            colLastMoveOtherPlayer = ConnectFourBoard.lastMove_PlayeroneCol;
            redCol = colLastMoveOtherPlayer;
            redRow = rowLastMoveOtherPlayer;
            ConnectFourBoard.count++;
            //ConnectFourBoard.console = redRow+" " + redCol;
            if (checkWinState(rowLastMoveOtherPlayer, colLastMoveOtherPlayer, ConnectFourBoard.PLAYER_ONE) == 1)
            {
                MessageBox.Show("You have won");
                isWin = ConnectFourBoard.PLAYER_ONE;
            }
         
            }
            else if(ConnectFourBoard.count%2!=0){
            
            ConnectFourAIClass vtmp = ConnectFourAI.ConnectFourAIClass.DeepClone(this);
            CusHeuristic = new CustomHeuristicTree(vtmp);
            maxHeurisitic = CusHeuristic.hHeuristic;
            //
            int npos = maxHeurisitic.connect4aiclass.ConnectFourBoard.RCtoint(maxHeurisitic.connect4aiclass.rowLastMoveOtherPlayer, maxHeurisitic.connect4aiclass.colLastMoveOtherPlayer);
            if (ConnectFourBoard.isColumnFilled(npos))
            {

                Boolean res = ConnectFourBoard.move_playertwo(npos, maxHeurisitic.connect4aiclass.rowLastMoveOtherPlayer, maxHeurisitic.connect4aiclass.colLastMoveOtherPlayer);
                ConnectFourBoard.console = "row " + maxHeurisitic.connect4aiclass.rowLastMoveOtherPlayer + " col " + maxHeurisitic.connect4aiclass.colLastMoveOtherPlayer;
                if (checkWinState(maxHeurisitic.connect4aiclass.rowLastMoveOtherPlayer, maxHeurisitic.connect4aiclass.colLastMoveOtherPlayer, ConnectFourBoard.PLAYER_TWO) == 1)
                {
                    MessageBox.Show("Jarvis has won");
                    isWin = ConnectFourBoard.PLAYER_TWO;
                }

            }
            else
            { 
                int[] vtpos=ConnectFourBoard.IntoRC(npos);

                if (vtpos[0] != ConnectFourBoard.EMPTY && vtpos[1] != ConnectFourBoard.EMPTY) {


                    int vtrow=ConnectFourBoard.ColumnFilledTill(vtpos[1]);
                    vtrow = ConnectFourBoard.IntoRC(vtrow)[0];
                    int vvtpos = ConnectFourBoard.RCtoint(vtrow, vtpos[1]);

                    Boolean res = ConnectFourBoard.move_playertwo(vvtpos, vtrow, vtpos[1]); 
                    ConnectFourBoard.console = "row " + vtrow + " col " + vtpos[1]+" r";
                    if (checkWinState(vtrow, vtpos[1],ConnectFourBoard.PLAYER_TWO) == 1)
                    {
                        //ConnectFourBoard.console = "you have won";
                        //MessageBox.Show("Computer have won");
                        isWin = ConnectFourBoard.PLAYER_TWO;
                    }
    
                }
            }
            ConnectFourBoard.count++;
            }
           }

        public int CalHeuristic(int r, int c, int p)
        {
            int TotalHeuristic = 0;
            TotalHeuristic = CheckHorizontal(r, c, p) + CheckVertical(r, c, p) + CheckLeftSideDiagonal(r, c, p) + CheckRightSideDiagonal(r, c, p);
            return TotalHeuristic;
        }
        public int getPosition(int r, int c)
        {
            return ((r - 1) * 7 + c);
        }
        public int getRow(int position)
        {
            return ((position / 7) + 1);
        }
        public int getCol(int position)
        {
            return (position % 7);
        }
        public int getHeuristic(int value)
        {
            int num = 0;
            if (value == 1)
                num = 1;
            else if (value == 2)
                num = 4;
            else if (value == 3)
                num = 32;
            else if (value == 4)
                num = 64;
            else if (value == 5)
                num = 128;
            else if (value == 6)
                num = 256;
            return num;
        }
        public int CheckHorizontal(int r, int c,int p)
        {
            int OriginalR = r;
            int OriginalC = c;
            int check = 0;
            int heuristicCountHorizontal = 0;
            int heuristic = 0;
            //rowLastMoveOtherPlayer = redRow;
            //colLastMoveOtherPlayer = redCol;
            while (r<= 6 && c>= 1 && check == 0)//to check the left
            {
                position = getPosition(r, c);
                if (c>= 1 && c<= 7 && r>= 1 && r<=6 && PositionArray[position] == p)
                {
                    c= c- 1;
                    heuristic++;
                    heuristicCountHorizontal = getHeuristic(heuristic);
                }
                else
                    check = 1;
            }
            check = 0;
            c= OriginalC;
            while (r<= 6 && c<= 7 && check == 0)//to check the right
            {
                if (heuristicCountHorizontal > 0)
                {
                        c= c+ 1;
                        if (c>= 1 && c<= 7 && c>= 1 && r <= 6 && PositionArray[getPosition(r, c)] == p)
                    {
                       // colLastMoveOtherPlayer = colLastMoveOtherPlayer + 1;
                        heuristic++;
                        heuristicCountHorizontal = getHeuristic(heuristic);
                    }
                    else
                        check = 1;
                }
                else {
                    if (c >= 1 && c <= 7 && r >= 1 && r <= 6 && PositionArray[getPosition(r, c)] == p)
                    {
                         c = c + 1;
                        heuristic++;
                        heuristicCountHorizontal = getHeuristic(heuristic);
                    }
                    else
                        check = 1;
                
                }
            }
            //ConnectFourBoard.console =  "heuristic is "+heuristicCountHorizontal+" in horizontal function" ;
            return heuristicCountHorizontal;
        }
        public int CheckVertical(int r, int c, int p)
        {
            int check = 0;
            int heuristicCountVertical = 0;
            int heuristic = 0;
            int OriginalR = r;
            int OriginalC = c;
            while (r >= 1 && check == 0)//to check the bottom
            {
                position = getPosition(r, c);
                if (c >= 1 && c <= 7 && r >= 1 && r<= 6 && PositionArray[getPosition(r, c)] == p  )
                {
                    r = r + 1;
                    heuristic++;
                    heuristicCountVertical = getHeuristic(heuristic);
                }
                else
                    check = 1;
            }
            return heuristicCountVertical;
            //ConnectFourBoard.console = heuristicCountVertical + "lm row " + ConnectFourBoard.lastMove_PlayeroneRow + " lm c" + ConnectFourBoard.lastMove_PlayeroneCol;
        }
        public int CheckLeftSideDiagonal(int r, int c, int p)////when the slope is 1
        {
            int check = 0;
            int heuristicCountLeftSideDiagonal = 0;
            int heuristic = 0;
            int OriginalR = r;
            int OriginalC = c;
            while (r>= 1 && c<= 7 && check == 0)//right uper
            {
                position = getPosition(r, c);
                if (c >= 1 && c<= 7 && r>= 1 && r<= 6 && PositionArray[getPosition(r, c)] == p)
                {
                    r--;
                    c++;
                    heuristic++;
                    heuristicCountLeftSideDiagonal = getHeuristic(heuristic);
                }
                else
                    check = 1;
            }
            r= OriginalR;
            c= OriginalC;
            check = 0;
            while (r<= 6 && c>= 1 && check == 0)//to check the left bottom
            {
                if (heuristicCountLeftSideDiagonal > 0)
                {
                    r++;
                    c--;
                    if (c>= 1 && c<= 7 && r>= 1 && r<= 6 && PositionArray[getPosition(r, c)] == p)
                    {
                        heuristic++;
                        heuristicCountLeftSideDiagonal = getHeuristic(heuristic);
                    }
                    else
                        check = 1;
                }
                else
                {
                    if (c>= 1 && c<= 7 && r>= 1 && r<= 6 && PositionArray[getPosition(r, c)] == p)
                    {
                        r++;
                        c--;
                        heuristic++;
                        heuristicCountLeftSideDiagonal = getHeuristic(heuristic);
                    }
                    else
                        check = 1;
                }
            }
            return heuristicCountLeftSideDiagonal;
        }
        public int CheckRightSideDiagonal(int r, int c, int p) //when the slope is -1
        {
            int check = 0;
            int heuristicCountRightSideDiagonal = 0;
            int heuristic = 0;
            int OriginalR = r;
            int OriginalC = c;
            while (r>= 1 && c>=1 && check == 0)//left uper
            {
                position = getPosition(r, c);
                if (c>= 1 && c<= 7 && r>= 1 && r<= 6 && PositionArray[getPosition(r, c)] == p)
                {
                    r--;
                    c--;
                    heuristic++;
                    heuristicCountRightSideDiagonal = getHeuristic(heuristic);
                }
                else
                    check = 1;
            }
            r= OriginalR;
            c= OriginalC;
            check = 0;
            while (r<= 6 && c<=7 && check == 0)//to check the right lower
            {
                if (heuristicCountRightSideDiagonal > 0)
                {
                    r++;
                    c++;
                    if (c>= 1 && c<= 7 && r>= 1 && r<= 6 && PositionArray[getPosition(r, c)] == p)
                    {

                        heuristic++;
                        heuristicCountRightSideDiagonal = getHeuristic(heuristic);
                    }
                    else
                        check = 1;

                }
                else
                {
                    if (c >= 1 && c <= 7 && r >= 1 && r <= 6 && PositionArray[getPosition(r, c)] == p)
                    {
                        r++;
                        c--;

                        heuristic++;
                        heuristicCountRightSideDiagonal = getHeuristic(heuristic);
                    }
                    else
                        check = 1;
                }
            }
            return heuristicCountRightSideDiagonal;
        }
        public static ConnectFourAIClass DeepClone<ConnectFourAIClass>(ConnectFourAIClass obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (ConnectFourAIClass)formatter.Deserialize(ms);
            }
        }
        public void updateClass_fromBoardPlayerOne() {


            PositionArray = ConnectFourBoard.getPositionArray();
            rowLastMoveOtherPlayer = ConnectFourBoard.lastMove_PlayeroneRow;
            colLastMoveOtherPlayer = ConnectFourBoard.lastMove_PlayeroneCol;
        
        }
        public void updateClass_fromBoardPlayerTwo()
        {


            PositionArray = ConnectFourBoard.getPositionArray();
            rowLastMoveOtherPlayer = ConnectFourBoard.lastMove_PlayertwoRow;
            colLastMoveOtherPlayer = ConnectFourBoard.lastMove_PlayertwoCol;


        }
        public int checkWinState(int r, int c,int p)
        {
            int WinState = 0;
            int total = CalHeuristic(r, c,p);
            if (total >= 67)
            {
                if ((CheckHorizontal(r, c,p) >= 64) || (CheckVertical(r, c,p) >= 64) || (CheckLeftSideDiagonal(r, c,p) >= 64) || (CheckRightSideDiagonal(r, c,p) >= 64))
                {
                    WinState = 1;
                    return WinState;
                }
            }
            return WinState;
        }
    }
}