using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        static public Position Nowhere
        {
            get { return (new Position(-1, -1)); }
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public Position Translate(double direction, int spaces)
        {
            int x = X + (int)Math.Cos(direction) * spaces;
            int y = Y + (int)Math.Sin(direction) * spaces;

            return new Position(x, y);
        }
    }
}