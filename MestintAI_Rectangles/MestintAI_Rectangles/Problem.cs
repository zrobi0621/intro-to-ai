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
            startNode = new Node(state, null, null);
        }

        public Node GetStartNode()
        {
            return startNode;
        }

        public static bool IsGoalState(List<int[]> state, List<int[]> goalState)
        {
            if (state == goalState)
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
