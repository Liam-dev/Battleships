using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class Opponent : Player
    {
        Random rnd;

        public Opponent(Random rnd)
        {
            this.rnd = rnd;
            Init();
            PlaceShips(rnd, true);            
        }

        public override void Turn()
        {
            Position adjacentShot = AdjacentShot();
            Position randomShot = RandomShot();

            if (!(adjacentShot.Equals(Position.Nowhere)))
            {
                FireShot(adjacentShot);
            }
            else
            {
                FireShot(randomShot);
            }
        }

        protected Position RandomShot()
        {
            Position position = Position.Nowhere;
            Position randomPosition;
            do
            {
                
                randomPosition = new Position(rnd.Next(0, 10), rnd.Next(0, 10));
                if (!(shots.Any(p => p.position.Equals(randomPosition))))
                {
                    position = randomPosition;
                }

            } while (shots.Any(p => p.position.Equals(randomPosition)));

            return position;
        }

        protected Position AdjacentShot()
        {
            List<Position> neighbours = new List<Position>();
            Position position = Position.Nowhere;

            foreach ((Position position, bool hit) shot in shots)
            {
                if (shot.hit)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        position = shot.position.Translate((i * Math.PI) / 2, 1);
                        if (!(shots.Any(p => p.position.Equals(position))))
                        {
                            return position;
                        }
                    }
                }
            }

            return position;
        }
    }
}
