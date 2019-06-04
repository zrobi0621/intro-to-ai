using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestintAI_Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGoalAdded = false;
            List<int[]> goalGrid = new List<int[]>();
            bool isStartAdded = false;
            List<int[]> startGrid = new List<int[]>();
            bool isSolve = false;

            Node startNode;

            Console.WriteLine("-- Rectangles --");
            Console.WriteLine();
            Console.WriteLine("The grid size is 4x4.");
            Console.WriteLine("Please add the Goal state:");
            Console.WriteLine("Command structure: [row] [position0] [position1] [position2] [position3]");
            Console.WriteLine("Command example: 1 2 3 3 3");
            Console.WriteLine();
            Console.WriteLine("Write 'Exit' if you want to quit!");
            Console.WriteLine();

            int rowsG = 0;

            while (!isGoalAdded)
            {
                if (rowsG == 4)
                {
                    isGoalAdded = true;
                    break;
                }

                Console.WriteLine("Command:");
                string command = Console.ReadLine();
                string[] token = command.Split(' ');
                
                if (token.Length == 5)
                {
                    int rowN = int.Parse(token[0]);
                    int col1 = int.Parse(token[1]);
                    int col2 = int.Parse(token[2]);
                    int col3 = int.Parse(token[3]);
                    int col4 = int.Parse(token[4]);
                    int[] row = new int[4] { col1, col2, col3, col4 };
                    goalGrid.Add(row);
                    Console.WriteLine($"Row {rowN} added: {col1} {col2} {col3} {col4}");
                    rowsG++;
                }
                else
                {
                    if (command.Equals("Exit"))
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Bad command!");
                    }
                }
            }

            if (isGoalAdded)
            {
                Console.WriteLine();
                Console.WriteLine("-- Goal state --");
                DisplayGrid(goalGrid);
                Console.WriteLine();
                Console.WriteLine("Please add the Start state:");
                Console.WriteLine("Command structure: [row] [position0] [position1] [position2] [position3]");
                Console.WriteLine("Command example: 1 2 0 2 0");
                Console.WriteLine();

                int rowsS = 0;

                while (!isStartAdded)
                {
                    if (rowsS == 4)
                    {
                        isStartAdded = true;
                        break;
                    }

                    Console.WriteLine("Command:");
                    string command = Console.ReadLine();
                    string[] token = command.Split(' ');

                    if (token.Length == 5)
                    {
                        int rowN = int.Parse(token[0]);
                        int col1 = int.Parse(token[1]);
                        int col2 = int.Parse(token[2]);
                        int col3 = int.Parse(token[3]);
                        int col4 = int.Parse(token[4]);
                        int[] row = new int[4] { col1, col2, col3, col4 };
                        startGrid.Add(row);
                        Console.WriteLine($"Row {rowN} added: {col1} {col2} {col3} {col4}");
                        rowsS++;
                    }
                    else
                    {
                        if (command.Equals("Exit"))
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Bad command!");
                        }
                    }
                }

                if (isStartAdded)
                {
                    Console.WriteLine();
                    Console.WriteLine("-- Goal state --");
                    DisplayGrid(goalGrid);
                    Console.WriteLine();
                    Console.WriteLine("-- Start state --");
                    DisplayGrid(startGrid);
                    Console.WriteLine();
                    Console.WriteLine("Solve? Type 'YES' or 'NO'!");
                    Console.WriteLine();

                    while (!isSolve)
                    {
                        Console.WriteLine("Command:");
                        string command = Console.ReadLine();
                        if (command.Equals("YES"))
                        {
                            isSolve = true;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    if (isSolve)
                    {
                        Problem problem = new Problem();
                        problem.SetGoalState(goalGrid);
                        problem.SetStartState(startGrid);
                        startNode = problem.GetStartNode();
                        Search search = new Search();
                        bool solved = search.DepthFirstSearch(startNode, goalGrid);

                        if (!solved)
                        {
                            Console.WriteLine("No solution!");
                        }
                        else
                        {
                            Console.WriteLine("Solution found!");
                        }
                        Console.ReadKey();
                        Console.ReadKey();
                    }
                }
            }
        }
       
        static void DisplayGrid(List<int[]> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    Console.Write(grid[i][j] + ",");
                }
                Console.WriteLine();
            }
        }
    }
}
