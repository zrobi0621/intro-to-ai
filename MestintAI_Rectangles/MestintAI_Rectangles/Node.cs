using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestintAI_Rectangles
{
    public class Node
    {
        List<int[]> state;
        List<Node> children;

        public Node(List<int[]> state, List<Node> children)
        {
            this.state = state;
            children = new List<Node>();
            this.children = children;
        }

        public List<int[]> GetState()
        {
            return state;
        }
        public void SetState(List<int[]> state)
        {
            this.state = state;
        }

        public void AddChild(Node child)
        {
            children.Add(child);
        }

        public List<Node> GetChildren()
        {

            return children;
        }        

        public List<Position> GetEmptyCells()
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
    }
}
