using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestintAI_Chains
{
    public class AI
    {
        enum Cell { Empty = 0, Player = 1, Opponent = 2 };

        public int Minimax(List<int[]> board, int depth, bool isMax)
        {
            Board b = new Board();
            int score = b.WhoIsWinning(board);

            if (score == 10)
            {
                return score;
            }
            if (score == -10)
            {
                return score;
            }
            if (b.IsMovesLeft(board) == false)
            {
                return 0;
            }

            if (isMax)
            {
                int best = -1000;
                for (int i = 0; i < board.Count; i++)
                {
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        if (board[i][j].Equals(Cell.Empty))
                        {
                            board[i][j] = (int)Cell.Player;
                            best = Math.Max(best,Minimax(board, depth + 1, !isMax));
                            board[i][j] = (int)Cell.Empty;
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;
                for (int i = 0; i < board.Count; i++)
                {
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        if (board[i][j].Equals(Cell.Empty))
                        {
                            board[i][j] = (int)Cell.Opponent;
                            best = Math.Min(best, Minimax(board, depth + 1, !isMax));
                            board[i][j] = (int)Cell.Empty;
                        }
                    }
                }
                return best;
            }
        }

        public Move FindBestMove(List<int[]> board)
        {
            int bestVal = -1000;
            Move bestMove = new Move();
            bestMove.Row = -1;
            bestMove.Pos = -1;
            for (int i = 0; i < board.Count; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 0)
                    {
                        board[i][j] = (int)Cell.Player;
                        int moveVal = Minimax(board, 0, false);
                        board[i][j] = (int)Cell.Empty;

                        if (moveVal > bestVal)
                        {
                            bestMove.Row = i;
                            bestMove.Pos = j;
                            bestVal = moveVal;
                        }
                    }
                }
            }
            Console.WriteLine($"The value of the best Move is :{bestVal}");
            return bestMove;
        }
    }
}
