using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint_Chains
{
    class Game
    {
        public List<int[]> originalBoard = new List<int[]>()
        {
            new int[]{0,0,0 },
            new int[]{0,0,0,0 },
            new int[]{0,0,0,0,0 },
            new int[]{0,0,0,0 },
            new int[]{0,0,0 },
        };

        public int[,] originalMatrix = new int[,]{
            {-1,-1,0,0,0,-1},
            {-1,0,0,0,0,-1},
            {0,0,0,0,0,0},
            {-1,0,0,0,0,-1},
            {-1,-1,0,0,0,-1}
        };
        //int[] originalBoard = { 0, 1, 0, 0, 0, 0, 0, 0 };
                              //0 -> empty, -1 - > wall
        int  huPlayer = 1;    //black
        int  aiPlayer = 2;    //white

        int score;
        List<int> emptyCells = new List<int>();

        public int Minimax(int[] newBoard, int player)
        {
            emptyCells = GetEmptyCells();

            if (Winning(newBoard, huPlayer))
            {
                return score = -10;
            }
            else if (Winning(newBoard, aiPlayer))
            {                
                return score = 10;
            }
            else if (emptyCells.Count == 0)
            {
                return score = 0;
            }

            Dictionary<int,int> moves = new Dictionary<int,int>();

            for (int i = 0; i < emptyCells.Count; i++)
            {                
                int moveIndex;
                int moveScore;

                moveIndex = newBoard[emptyCells[i]];

                newBoard[emptyCells[i]] = player;

                if (player == aiPlayer)
                {
                    int result = Minimax(newBoard, huPlayer);
                    moveScore = result;
                }
                else
                {
                    int result = Minimax(newBoard, aiPlayer);
                    moveScore = result;
                }
                newBoard[emptyCells[i]] = moveIndex;

                moves.Add(moveIndex, moveScore);
            }

            int bestMove = 0;

            if (player == aiPlayer)
            {
                int bestScore = -10000;
                for (int i = 0; i < moves.Count; i++)
                {
                    if (moves.ElementAt(i).Value > bestScore)
                    {
                        bestScore = moves.ElementAt(i).Value;
                        bestMove = i;
                    }
                }
            }
            else
            {
                int bestScore = 10000;
                for (int i = 0; i < moves.Count; i++)
                {
                    if (moves.ElementAt(i).Value < bestScore)
                    {
                        bestScore = moves.ElementAt(i).Value;
                        bestMove = i;
                    }
                }
            }
            return moves.ElementAt(bestMove).Key;            
        }

        private bool Winning(object newBoard, object huPlayer)
        {
            throw new NotImplementedException();
        }


        private List<int> GetEmptyCells()
        {
            throw new NotImplementedException();
        }

    }
}
