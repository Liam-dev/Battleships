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

        //list of fired shots
        protected List<(Position position, bool hit)> shots = new List<(Position, bool)>();
        //list of received shots
        protected List<Position> receivedHits = new List<Position>();

        //has lost if all ships are destroyed
        public bool HasLost
        {
            get { return Array.TrueForAll(ships, ship => ship.Destroyed); }
        }

        //own and firing boards of the player
        protected OwnBoard ownBoard;
        protected ShotBoard firingBoard;
        protected Board[] boards;

        //General initialisation of the player - run in subclass's constructors
        public void Init()
        {
            //create ships
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

        //abstract method Turn - implemented by computer and user controlled subclasses
        public abstract Position Turn();

        //receives confirmation of hit
        public void ReceiveHitConfirmation(Position location, bool hit)
        {
            shots.Add((location, hit));
        }

        //called when hit by opponent - returns hit confirmation
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
        
        //method to randomly place ships in the grid - can be configured to allow touching ships or not
        public void PlaceShips(Random rnd, bool canTouch)
        {
            List<Position> gridSpacesOccupied = new List<Position>();

            foreach (Ship ship in ships)
            {
                bool shipGenerated = false;

                //continue until ship is generated
                while (!(shipGenerated))
                {
                    List<Position> spacesOccupied = new List<Position>();

                    //choose random starting positions and directions
                    Position position = new Position(rnd.Next(0, 10), rnd.Next(0, 10));
                    double direction = ((double)rnd.Next(0, 4) / 2) * Math.PI;

                    bool isRoom = true;
                    for (int i = 0; i < ship.Length; i++)
                    {
                        //check if position is off the board
                        bool outOfBounds = (position.X < 0 || position.Y < 0 || position.X > 10 - 1 || position.Y > 10 - 1);

                        if (!canTouch)
                        {
                            //checks adjacent positions for any ships - if so, cancel generation
                            for (int k = 0; k < 4; k++)
                            {
                                Position space = position.Translate((k * Math.PI) / 2, 1);
                                if (gridSpacesOccupied.Contains(space))
                                {
                                    outOfBounds = true;
                                }
                            }
                        }

                        //checks if ship already generated in that position or out of bounds
                        if (gridSpacesOccupied.Contains(position) || outOfBounds)
                        {
                            //no room
                            isRoom = false;
                            break;
                        }
                        else
                        {
                            //try next position
                            spacesOccupied.Add(position);
                            position = position.Translate(direction, 1);
                        }
                    }

                    if (isRoom == true)
                    {
                        //create ship
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
