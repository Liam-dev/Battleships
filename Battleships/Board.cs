using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    //enumeration of status' of a square on the board
    enum SquareType
    {
        Ocean = '·',
        Hit = 'X',
        OwnHit = 'x',
        Miss = 'M',
        Destroyer = 'D',
        Submarine = 'S',
        Cruiser = 'C',
        Battleship = 'B',
        AircraftCarrier = 'A',
        HitDestroyer = 'd',
        HitSubmarine = 's',
        HitCruiser = 'c',
        HitBattleship = 'b',
        HitAircraftCarrier = 'a'
    }

    abstract class Board
    {   
        //dictionary to store all the colours for differnt status' - it's long but it makes it look cool :)
        static protected Dictionary<SquareType, ConsoleColor> SquareColours = new Dictionary<SquareType, ConsoleColor>()
        {
            {SquareType.Ocean, ConsoleColor.DarkGray },
            {SquareType.Hit, ConsoleColor.Green },
            {SquareType.OwnHit, ConsoleColor.Gray },
            {SquareType.Miss, ConsoleColor.Red },
            {SquareType.Destroyer, ConsoleColor.Green },
            {SquareType.Submarine, ConsoleColor.Yellow },
            {SquareType.Cruiser, ConsoleColor.Red },
            {SquareType.Battleship, ConsoleColor.Magenta },
            {SquareType.AircraftCarrier, ConsoleColor.Cyan },
            {SquareType.HitDestroyer, ConsoleColor.DarkGreen },
            {SquareType.HitSubmarine, ConsoleColor.DarkYellow },
            {SquareType.HitCruiser, ConsoleColor.DarkRed },
            {SquareType.HitBattleship, ConsoleColor.DarkMagenta },
            {SquareType.HitAircraftCarrier, ConsoleColor.DarkCyan }
        };

        //array of damged ship types
        static protected SquareType[] damagedShipsTypes = new SquareType[]
        {
            SquareType.HitDestroyer,
            SquareType.HitSubmarine,
            SquareType.HitCruiser,
            SquareType.HitBattleship,
            SquareType.HitAircraftCarrier
        };

        //array that makes a 10x10 grid of SquareTypes
        protected SquareType[,] grid = new SquareType[10, 10];

        //abstract method - each child of Board has its own Update method
        public abstract void Update();

        //sets a certain position on the grid to a certain value
        protected void SetGridPosition(Position position, SquareType type)
        {
            grid[position.X, position.Y] = type;
        }

        //fills the board with ocean (empty) squares
        protected void FillBoard(SquareType type)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = type;
                }
            }
        }

        //prints the board at a certain position on the screen
        public void Print(Position position)
        {
            Console.CursorTop = position.Y;
            Console.CursorLeft = position.X;
            Console.Write("    A   B   C   D   E   F   G   H   I   J\n\n");
            for (int i = 0; i < 10; i++)
            {
                Console.CursorLeft = position.X;
                Console.Write(i.ToString());
                for (int j = 0; j < 10; j++)
                {
                    SquareType square = grid[j, i];

                    char character;
                    if (damagedShipsTypes.Contains(square))
                    {
                        character = (char)SquareType.Hit;
                    }
                    else
                    {
                        character = (char)square;
                    }

                    Console.Write("   ");
                    Console.ForegroundColor = SquareColours[square];
                    Console.Write(character.ToString().ToUpper());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("\n\n");
            }
        }
    }
}
