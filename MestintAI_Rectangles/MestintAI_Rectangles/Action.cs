using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestintAI_Rectangles
{
    public class Action
    {
        public Position Pos { get; set; }
        public int Value { get; set; }
        public List<int[]> State;

        public Action()
        {

        }

        public Action(Position pos, int value)
        {
            this.Pos = pos;
            this.Value = value;
            this.State = null;
        }
        public Action(Position pos, int value, List<int[]> state)
        {
            this.Pos = pos;
            this.Value = value;
            this.State = state;
        }        

        public void SetState(List<int[]> state)
        {
            this.State = state;
        }
        public List<int[]> GetState()
        {
            return State;
        }
    }
}
