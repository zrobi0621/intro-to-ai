using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MestintAI_Rectangles
{
    public class Search
    {
        int c = 0;

        public bool DepthFirstSearch(Node startState, List<int[]> goal)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(startState);
            List<Node> visited = new List<Node>();
            ISet<int> neighbors = new SortedSet<int>();

            neighbors = GetPossibleNeighbors(startState.GetState());
            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    
                    DispState(node.GetState());

                    if (Problem.IsGoalState(node.GetState(), goal))
                    {
                        return true;
                    }
                    else
                    {
                        List<Action> actions = GetActions(node.GetState(),neighbors);
                        foreach (Action action in actions)
                        {
                            Node newN = new Node(action.GetState(), new List<Node>());
                            if (!visited.Contains(newN))
                            {
                                node.AddChild(newN);
                            }
                        }

                        foreach (Node state in node.GetChildren())
                        {
                            stack.Push(state);
                        }
                    }
                }
            }
            return false;
        }

        void DispState(List<int[]> s)
        {            
            string line = "";
            for (int i = 0; i < s.Count; i++)
            {
                for (int j = 0; j < s[i].Length; j++)
                {
                    string sl = " " + s[i][j];
                    line += sl;
                }
            }

            c++;
            Console.WriteLine(c + ".: " + line);            
        }

        public static List<Action> GetActions(List<int[]> state, ISet<int> neighbors)
        {
            List<Position> emptys = new List<Position>();
            emptys = GetEmptys(state);

            Temp t = new Temp();
            t.tempState = DeepCopy(state);
            
            List<Action> actions = new List<Action>();
            
            
            foreach (Position empty in emptys)
            {
                List<int[]> newS = new List<int[]>();
                newS = DeepCopy(t.tempState);

                foreach (int n in neighbors)
                {
                    newS = DeepCopy(t.tempState);
                    actions.Add(new Action
                    {
                        Pos = empty,
                        Value = n,
                        State = DoAction(newS, empty, n)
                    });
                }               
            }
            return actions;
        }

        public static List<int[]> DoAction(List<int[]> state, Position pos, int number)
        {
            int x = pos.X;
            int y = pos.Y;
            for (int i = 0; i < state.Count; i++)
            {
                for (int j = 0; j < state[i].Length; j++)
                {
                    if (i == x && j == y)
                    {
                        state[i][y] = number;
                        goto Fin;
                    }
                }
            }
            Fin:
            return state;
        }

        public static ISet<int> GetPossibleNeighbors(List<int[]> state)
        {
            ISet<int> neighbors = new HashSet<int>();
            int max = 0;
            for (int k = 0; k < state.Count; k++)
            {
                for (int l = 0; l < state[k].Length; l++)
                {
                    if (state[k][l] > max)
                    {
                        max = state[k][l];
                    }
                }
            }

            for (int o = 1; o < max; o++)
            {
                neighbors.Add(o + 1);
            }

            return neighbors;
        }

        public static List<Position> GetEmptys(List<int[]> state)
        {
            List<Position> emptyCells = new List<Position>();

            for (int i = 0; i < state.Count; i++)
            {
                for (int j = 0; j < state[i].Length; j++)
                {
                    if (state[i][j] == 0)
                    {
                        emptyCells.Add(new Position(i, j));
                    }
                }
            }
            return emptyCells;
        }

        public static T DeepCopy<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
