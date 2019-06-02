using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint_Chains
{
    class Game
    {       
                              //0 -> empty, -1 - > wall
        int  player = 1;    //black
        int  opponent = 2;    //white

        int score = 0;
        List<int> emptyCells = new List<int>();

        public int Minimax(int[] newBoard, int player)
        {
            emptyCells = GetEmptyCells();

            if (Winning(newBoard, this.player))
            {
                return score = -10;
            }
            else if (Winning(newBoard, this.opponent))
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

                if (player == opponent)
                {
                    int result = Minimax(newBoard, this.player);
                    moveScore = result;
                }
                else
                {
                    int result = Minimax(newBoard, opponent);
                    moveScore = result;
                }
                newBoard[emptyCells[i]] = moveIndex;

                moves.Add(moveIndex, moveScore);
            }

            int bestMove = 0;

            if (player == opponent)
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
            //TODO
            throw new NotImplementedException();
        }

        private List<int> GetEmptyCells()
        {
            MainWindow main = new MainWindow();
            int[] currBoard = main.GetCurrentBoard();

            List<int> indexes = new List<int>();

            for (int i = 0; i < currBoard.Length; i++)
            {
                if (currBoard[i] == 0)
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }
    }
}