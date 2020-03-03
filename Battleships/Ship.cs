using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsFinal
{
    abstract class Ship
    {      
        public SquareType Type;
        public int Length;
        private List<Position> spacesOccupied = new List<Position>();
        private List<Position> damagedSpaces = new List<Position>();
        public bool Destroyed
        {
            get { return (SpacesOccupied.Count == 0); }
        }

        public List<Position> SpacesOccupied
        {
            get { return spacesOccupied; }
        }

        public List<Position> DamagedSpaces
        {
            get { return damagedSpaces; }
        }

        public void DestroyShipSpace(Position space)
        {
            damagedSpaces.Add(space);
            spacesOccupied.Remove(space);
        }
    }

    class Destroyer : Ship
    {
        public Destroyer()
        {
            Type = SquareType.Destroyer;
            Length = 2;
        }
    }

    class Submarine : Ship
    {
        public Submarine()
        {
            Type = SquareType.Submarine;
            Length = 3;
        }
    }

    class Cruiser : Ship
    {
        public Cruiser()
        {
            Type = SquareType.Cruiser;
            Length = 3;
        }
    }

    class Battleship : Ship
    {
        public Battleship()
        {
            Type = SquareType.Battleship;
            Length = 4;
        }
    }

    class AircraftCarrier : Ship
    {
        public AircraftCarrier()
        {
            Type = SquareType.AircraftCarrier;
            Length = 5;
        }
    }
}