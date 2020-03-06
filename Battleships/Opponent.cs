using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    //computer controlled opponent
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
            //two strategies - either take a random shot or shoot adjacent to a previous hit
            Position adjacentShot = AdjacentShot();
            Position randomShot = RandomShot();

            if (!(adjacentShot.Equals(Position.Nowhere)) && rnd.Next(0, 3) == 0)
            {
                FireShot(adjacentShot);
            }
            else
            {
                FireShot(randomShot);
            }
        }

        //chooses a new random position to fire at where not fired before
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

        //attempts to find a position adjacent to a hit to uncover the rest of the ship
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
                        bool outOfBounds = (position.X < 0 || position.Y < 0 || position.X > 10 - 1 || position.Y > 10 - 1);
                        if (!(shots.Any(p => p.position.Equals(position)) || outOfBounds))
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
