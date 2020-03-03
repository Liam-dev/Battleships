using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsFinal
{
    struct Position
    {
        int x;
        int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public void ChangeInDirection(double direction, int spaces)
        {
            x += (int)Math.Cos(direction) * spaces;
            y += (int)Math.Sin(direction) * spaces;
        }
    }
}