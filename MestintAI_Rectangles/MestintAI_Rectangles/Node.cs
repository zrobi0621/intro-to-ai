using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestintAI_Rectangles
{
    class Node
    {
        List<int[]> state;
        Node parent;
        List<Node> children;

        public Node()
        {

        }

        public Node(List<int[]> state, Node parent, List<Node> children)
        {
            this.state = state;
            this.parent = parent;
            this.children = children;
        }

        public List<int[]> GetState()
        {
            return state;
        }

        public Node Parent()
        {
            return parent;
        }

        public List<Node> GetChildren()
        {
            return children;
        }        
    }
}
