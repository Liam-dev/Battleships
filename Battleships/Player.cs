using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    abstract class Player
    {
        protected Ship[] ships;
        protected Player opponent;
        protected List<(Position position, bool hit)> shots = new List<(Position, bool)>();
        protected List<Position> receivedHits = new List<Position>();

        public bool HasLost
        {
            get { return Array.TrueForAll(ships, ship => ship.Destroyed); }
        }

        protected OwnBoard ownBoard;
        protected ShotBoard firingBoard;
        protected Board[] boards;
        
        public void Init()
        {
            ships = new Ship[]
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new AircraftCarrier()
            };

            ownBoard = new OwnBoard(ships, ref receivedHits);
            firingBoard = new ShotBoard(ref shots);

            boards = new Board[] { ownBoard, firingBoard };
        }

        public abstract void Turn();

        public void SetOpponent(Player opponent)
        {
            this.opponent = opponent;
        }

        public void FireShot(Position location)
        {
            bool shipHit = opponent.ReceiveShot(location);
            shots.Add((location, shipHit));
        }

        public bool ReceiveShot(Position location)
        {
            bool shipHit = false;
            foreach (Ship ship in ships)
            {
                if (ship.SpacesOccupied.Contains(location))
                {
                    shipHit = true;
                    ship.DestroyShipSpace(location);                 
                }
            }

            receivedHits.Add(location);
            return shipHit;
        }
        
        public void PlaceShips(Random rnd, bool canTouch)
        {
            List<Position> gridSpacesOccupied = new List<Position>();

            foreach (Ship ship in ships)
            {
                bool shipGenerated = false;
                while (!(shipGenerated))
                {
                    List<Position> spacesOccupied = new List<Position>();

                    Position position = new Position(rnd.Next(0, 10), rnd.Next(0, 10));
                    double direction = ((double)rnd.Next(0, 4) / 2) * Math.PI;

                    bool isRoom = true;
                    for (int i = 0; i < ship.Length; i++)
                    {
                        bool outOfBounds = (position.X < 0 || position.Y < 0 || position.X > 10 - 1 || position.Y > 10 - 1);

                        if (!canTouch)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                Position space = position.Translate((k * Math.PI) / 2, 1);
                                if (gridSpacesOccupied.Contains(space))
                                {
                                    outOfBounds = true;
                                }
                            }
                        }

                        if (gridSpacesOccupied.Contains(position) || outOfBounds)
                        {
                            isRoom = false;
                            break;
                        }
                        else
                        {
                            spacesOccupied.Add(position);
                            position = position.Translate(direction, 1);
                        }
                    }

                    if (isRoom == true)
                    {
                        gridSpacesOccupied.AddRange(spacesOccupied);
                        ship.SpacesOccupied.AddRange(spacesOccupied);
                        shipGenerated = true;
                    }
                }
            }

            ownBoard.Update();
        }
    }
}
