﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class OwnBoard : Board
    {
        protected Ship[] ships;
        protected List<Position> hitPositions;

        public OwnBoard(Ship[] ships, ref List<Position> hitPositions)
        {
            FillBoard(SquareType.Ocean);
            this.ships = ships;
            this.hitPositions = hitPositions;
        }

        public override void Update()
        {
            foreach (Position space in hitPositions)
            {
                SetGridPosition(space, SquareType.OwnHit);
            }

            foreach (Ship ship in ships)
            {
                foreach (Position space in ship.SpacesOccupied)
                {
                    SetGridPosition(space, ship.Type);
                }

                foreach (Position space in ship.DamagedSpaces)
                {
                    SetGridPosition(space, ship.Type + 32);
                }
            }



        }

    }
}
