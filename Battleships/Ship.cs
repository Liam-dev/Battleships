using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    abstract class Ship
    {      
        public SquareType Type { get; protected set; }
        public int Length { get; protected set; }
        public List<Position> SpacesOccupied { get; protected set; } = new List<Position>();
        public List<Position> DamagedSpaces { get; protected set; } = new List<Position>();
        //Destroyed returns true if all the spaces are damaged
        public bool Destroyed { get { return (SpacesOccupied.Count == 0); } }

        //moves position space from spaces pccupied to damaged spaces
        public void DestroyShipSpace(Position space)
        {
            DamagedSpaces.Add(space);
            SpacesOccupied.Remove(space);
        }
    }

    //ship subclasses
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