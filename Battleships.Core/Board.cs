using System;
using System.Collections.Generic;

namespace Battleships.Core
{
    public class Board
    {
        public List<Ship> Ships { get; set; }

        public Board()
        {
            Ships = new List<Ship>();
        }

        public void AddShip(Ship ship, char startingPositionColumn, int startingPositionRow, string orientation)
        {
            Ships.Add(ship);

            if (orientation == "horizontal")
            {
                for (char column = startingPositionColumn; column <= startingPositionColumn + ship.Size-1; column++)
                {
                    var boardField = new BoardField(column, startingPositionRow);
                    ship.BoardFields.Add(boardField);
                }
            }
        }
    }
}