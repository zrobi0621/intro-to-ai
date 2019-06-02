using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestintAI_Chains
{
    class Program
    {
        static List<int[]> gameBoard = new List<int[]>();

        static void Main(string[] args)
        {
            Board b = new Board();
            bool canGo = false;
            List<int[]> board = new List<int[]>();
            board = b.GetEmptyBoard();
            int nextTurn = 0;

            Console.WriteLine("-- ChainsAI --");
            Console.WriteLine();
            b.Display(board);            
            Console.WriteLine();
            Console.WriteLine("Please add the current state:");
            Console.WriteLine();
            Console.WriteLine("Player => 1, Opponent => 2");
            Console.WriteLine("Command structure: [playerNumber: 1-2] [row: 0-4] [position: 0-5]");
            Console.WriteLine("Command example : 1 3 2");
            Console.WriteLine();
            Console.WriteLine("Write 'Start1' or 'Start2' (Next turn:1 or 2) when you done or 'Exit' if you want to quit!");
            Console.WriteLine();

            while (!canGo)
            {
                Console.WriteLine("Command:");
                
                string command = Console.ReadLine();
                string[] token = command.Split(' ');
                if (token.Length == 3)
                {
                    int player = int.Parse(token[0]);
                    int row = int.Parse(token[1]);
                    int position = int.Parse(token[2]);

                    board[row][position] = player;
                    SetBoard(board);

                    b.Display(board);
                }
                else
                {
                    if (command.Equals("Start1"))
                    {
                        canGo = true;
                        nextTurn = 1;
                    }
                    else if (command.Equals("Start2"))
                    {
                        canGo = true;
                        nextTurn = 2;
                    }
                    else if (command.Equals("Exit"))
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Bad command!");                    
                    }
                }                                
            }

            if (canGo)
            {
                AI ai = new AI();
                Move bestMove = ai.FindBestMove(board);
                Console.WriteLine("The Optimal Move is:");
                Console.WriteLine($"Row: {bestMove.Row} Pos: {bestMove.Pos}");
                board[bestMove.Row][bestMove.Pos] = 5;
                Console.WriteLine();
                Console.WriteLine("-- Result --");
                b.Display(board);
                Console.ReadKey();
            }
        }


        public static void SetBoard(List<int[]> board)
        {
            gameBoard = board;
        }

        public List<int[]> GetBoard()
        {
            return gameBoard;
        }
    }
}
