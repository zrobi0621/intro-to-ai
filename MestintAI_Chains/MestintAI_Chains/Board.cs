using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestintAI_Chains
{
    class Board
    {
        

        List<int[]> originalBoard = new List<int[]>()
            {
                new int[]{0,0,0,0 },
                new int[]{0,0,0,0,0 },
                new int[]{0,0,0,0,0,0 },
                new int[]{0,0,0,0,0 },
                new int[]{0,0,0,0 },
            };

        public List<int[]> GetEmptyBoard()
        {
            return originalBoard;
        }

        public bool IsMovesLeft(List<int[]> board)
        {
            for (int i = 0; i < board.Count; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int WhoIsWinning(List<int[]> board)
        {
            int player = 0;
                      int opponent = 0;
        
                      for (int i = 0; i < board.Count; i++)
                      {
                          for (int j = 0; j < board[i].Length; j++)
                          {
                              if (board[i][j] == 1)
                              {
                                  player++;
                              }
                              else if(board[i][j] == 2)
                              {
                                  opponent++;
                              }
                          }
                      }
                      if (player == 5)
                      {
                          return 10;
                      }
                      if (opponent == 5)
                      {
                          return 10;
                      }
                      return 0;
                }

        public void Display(List<int[]> board)
        {
            for (int i = 0; i < board.Count; i++)
            {
                if (i == 0 || i == 4)
                {
                    Console.Write("  ");
                }
                else if (i == 1 || i == 3)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < board[i].Length; j++)
                {
                    Console.Write(board[i][j]+",");
                }
                Console.WriteLine();
            }
        }
    }
}
