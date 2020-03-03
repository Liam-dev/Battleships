using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsFinal
{
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
        protected SquareType[,] grid = new SquareType[10, 10];

        protected Dictionary<SquareType, ConsoleColor> SquareColours = new Dictionary<SquareType, ConsoleColor>()
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

        protected SquareType[] damagedShipsTypes = new SquareType[]
        {
            SquareType.HitDestroyer,
            SquareType.HitSubmarine,
            SquareType.HitCruiser,
            SquareType.HitBattleship,
            SquareType.HitAircraftCarrier
        };

        public abstract void Update();

        protected void SetGridPosition(Position position, SquareType type)
        {
            grid[position.X, position.Y] = type;
        }

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
