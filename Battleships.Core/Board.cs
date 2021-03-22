using System;
using System.Collections.Generic;

namespace Battleships.Core
{
    public class Board
    {
        public List<BoardField> BoardFields { get; set; }

        public Board()
        {
            BoardFields = new List<BoardField>();           
            for (char row = 'A'; row <= 'J'; row++)
            {
                for (int column = 1; column <= 10; column++)
                {
                    BoardFields.Add(new BoardField(row, column));
                }
            }           
        }

        public void AddShip(Ship ship, char startingPositionRow, int startingPositionColumn, string orientation)
        {
            if (orientation == "horizontal")
            {
                for (int column = startingPositionColumn; column <= startingPositionColumn + ship.Size-1; column++)
                {
                    BoardFields.Find(field => field.Row == startingPositionRow && field.Column == column).Value = ship.Type;
                }
            }
        }
    }
}