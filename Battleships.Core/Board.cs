using System;
using System.Collections.Generic;

namespace Battleships.Core
{
    public class Board
    {
        public List<Ship> Ships { get; set; }
        public int ShipsLeft { get; set; }

        public Board()
        {
            Ships = new List<Ship>();
            ShipsLeft = 0;
        }

        public void AddShip(Ship ship, char startingPositionColumn, int startingPositionRow, string orientation)
        {
            Ships.Add(ship);
            ShipsLeft += 1;

            if (orientation == "horizontal")
            {
                var endPositionColumn = startingPositionColumn + ship.Size - 1;
                for (char column = startingPositionColumn; column <= endPositionColumn; column++)
                {
                    var boardField = new BoardField(column, startingPositionRow);
                    ship.BoardFields.Add(boardField);
                }
            }
            else if (orientation == "vertical")
            {
                var endPositionRow = startingPositionRow + ship.Size - 1;
                for (int row = startingPositionRow; row <= endPositionRow; row++)
                {
                    var boardField = new BoardField(startingPositionColumn, row);
                    ship.BoardFields.Add(boardField);
                }
            }
        }
    }
}