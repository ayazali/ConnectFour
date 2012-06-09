using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConnectFourAI
{
    [Serializable]
    class CustomHeuristicTree
    {

        public HNode hHeuristic { get; set; }

        public CustomHeuristicTree(ConnectFourAIClass connectFourclass)
        {

            NodeList rootNode = new NodeList(ConnectFourAI.ConnectFourAIClass.DeepClone(connectFourclass));
            List<NodeList> firstNode = new List<NodeList>();
            List<NodeList> secondNode = new List<NodeList>();

            hHeuristic = ConnectFourAI.CustomHeuristicTree.HNode.DeepClone(
                rootNode.hnlist.ElementAt(0));


            foreach (HNode ele in rootNode.hnlist)
            {

                firstNode.Add(new NodeList(ele.connect4aiclass));

                //if (ele.hval > hHeuristic.hval)
                //    if (ele.hval != null)
                //        hHeuristic = ele;


            }

            foreach (NodeList ele in firstNode)
                foreach (HNode nele in ele.hnlist)
                {


                    secondNode.Add(new NodeList(nele.connect4aiclass));

                    //if (nele.hval != null)
                        if (nele.hval > hHeuristic.hval)
                                hHeuristic = nele;
                }

   
        }

        public ConnectFourAIClass copyClass(ConnectFourAIClass oldobj)
        {

            ConnectFourAIClass newobj = new ConnectFourAIClass(oldobj.ConnectFourBoard);
            newobj.PositionArray = oldobj.PositionArray;
            newobj.colLastMoveOtherPlayer = oldobj.colLastMoveOtherPlayer;
            newobj.rowLastMoveOtherPlayer = oldobj.rowLastMoveOtherPlayer;
            newobj.redCol = oldobj.redCol;
            newobj.redRow = oldobj.redRow;

            return newobj;
        }

        [Serializable]
        public class NodeList
        {
            public List<HNode> hnlist;

            public NodeList(ConnectFourAIClass c4ai)
            {

                hnlist = new List<HNode>();

                for (int i = 1; i <= 7; i++)
                {
                    HNode tmp = new HNode(ConnectFourAI.ConnectFourAIClass.DeepClone(c4ai));
                    int movpos = tmp.connect4aiclass.ConnectFourBoard.ColumnFilledTill(i);
                    int[] rcpos = tmp.connect4aiclass.ConnectFourBoard.IntoRC(movpos);
                    tmp.connect4aiclass.TotalHeuristicCount = tmp.hval;

                    if (tmp.connect4aiclass.ConnectFourBoard.count % 2 == 0)
                    {
                        tmp.connect4aiclass.ConnectFourBoard.move_playerone(movpos, rcpos[0], rcpos[1]);
                        tmp.connect4aiclass.updateClass_fromBoardPlayerOne();
                        tmp.hval = tmp.connect4aiclass.CalHeuristic(rcpos[0], rcpos[1], tmp.connect4aiclass.ConnectFourBoard.PLAYER_ONE);
                    }
                    else
                    {
                        tmp.connect4aiclass.ConnectFourBoard.move_playertwo(movpos, rcpos[0], rcpos[1]);
                        tmp.connect4aiclass.updateClass_fromBoardPlayerTwo();
                        tmp.hval = tmp.connect4aiclass.CalHeuristic(rcpos[0], rcpos[1],tmp.connect4aiclass.ConnectFourBoard.PLAYER_TWO);
                    }
                    
                    tmp.connect4aiclass.TotalHeuristicCount = tmp.hval;
                    tmp.connect4aiclass.ConnectFourBoard.count++;
                    hnlist.Add(tmp);
                }

            }
        }
        [Serializable]
        public class HNode
        {
            public int hval;
            public ConnectFourAIClass connect4aiclass;

            public HNode(ConnectFourAIClass c4aiclass)
            {
                connect4aiclass = ConnectFourAI.ConnectFourAIClass.DeepClone(c4aiclass);
                if(connect4aiclass.ConnectFourBoard.count %2 ==0)
                hval = connect4aiclass.CalHeuristic(connect4aiclass.rowLastMoveOtherPlayer, connect4aiclass.colLastMoveOtherPlayer,connect4aiclass.ConnectFourBoard.PLAYER_ONE);
                else if(connect4aiclass.ConnectFourBoard.count %2 != 0)
                    hval = connect4aiclass.CalHeuristic(connect4aiclass.rowLastMoveOtherPlayer, connect4aiclass.colLastMoveOtherPlayer, connect4aiclass.ConnectFourBoard.PLAYER_TWO);
            }

            public static HNode DeepClone<HNode>(HNode obj)
            {
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, obj);
                    ms.Position = 0;

                    return (HNode)formatter.Deserialize(ms);
                }
            }

        }
    }
}
