using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class ShotBoard : Board
    {
        protected List<(Position position, bool hit)> shots;

        public ShotBoard(ref List<(Position position, bool hit)> shots)
        {
            FillBoard(SquareType.Ocean);
            this.shots = shots;
        }

        public override void Update()
        {
            foreach ((Position position, bool hit) shot in shots)
            {
                Position position = shot.position;
                bool hit = shot.hit;
                SquareType square;

                if (hit)
                {
                    square = SquareType.Hit;
                }
                else
                {
                    square = SquareType.Miss;
                }

                grid[position.X, position.Y] = square;
            }
        }
    }
}
