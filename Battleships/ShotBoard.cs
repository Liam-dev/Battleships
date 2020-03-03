using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsFinal
{
    class ShotBoard : Board
    {
        protected List<(Position, bool)> shots;

        public ShotBoard(ref List<(Position, bool)> shots)
        {
            FillBoard(SquareType.Ocean);
            this.shots = shots;
        }

        public override void Update()
        {
            foreach ((Position, bool) shot in shots)
            {
                Position position = shot.Item1;
                bool hit = shot.Item2;
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
