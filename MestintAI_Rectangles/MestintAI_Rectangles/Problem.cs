using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestintAI_Rectangles
{
    class Problem
    {
        List<int[]> goalState = new List<int[]>();
        List<int[]> startState = new List<int[]>();

        Node startNode;

        public void SetGoalState(List<int[]> state)
        {
            goalState = state;
        }
        public void SetStartState(List<int[]> state)
        {
            goalState = state;
            SetStartNode(state);
        }

        public List<int[]> GetStartState()
        {
            return startState;
        }

        public void SetStartNode(List<int[]> state)
        {
            startNode = new Node(state, null);
        }

        public Node GetStartNode()
        {
            return startNode;
        }

        public static bool IsGoalState(List<int[]> state, List<int[]> goalState)
        {
            int c = 0;

            for (int i = 0; i < state.Count; i++)
            {
                for (int j = 0; j < state[i].Length; j++)
                {
                    if (state[i][j] == goalState[i][j])
                    {
                        c++;
                    }
                }
            }

            if (c == 16)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
