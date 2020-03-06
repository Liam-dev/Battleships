using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    //Struct to represent a position in integer x-y space
    struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        //Nowhere equivalent to empty position
        static public Position Nowhere
        {
            get { return (new Position(-1, -1)); }
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

        //allows the equality comparison of positions
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        //returns image position of a polar translation
        public Position Translate(double direction, int spaces)
        {
            int x = X + (int)Math.Cos(direction) * spaces;
            int y = Y + (int)Math.Sin(direction) * spaces;

            return new Position(x, y);
        }
    }
}