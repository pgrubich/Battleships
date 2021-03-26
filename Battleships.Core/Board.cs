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

        public void FindPlaceForShip(Ship ship)
        {
            var rand = new Random();
            string[] orientations = { "vertical", "horizontal" };
            int row = 1;
            char column = 'A';
            int orientationIndex;
            string orientation = "vertical";
            bool spaceOccupied = true;

            while (spaceOccupied)
            {
                //choose new starting point
                row = rand.Next(1, 11);
                column = (char)rand.Next('A', 'K');
                orientationIndex = rand.Next(orientations.Length);
                orientation = orientations[orientationIndex];

                for (int i = 0; i < ship.Size; i++)
                {
                    if (orientation == "vertical")
                    {
                        if (IsFieldOccupied(column, row + i) || (row + i) > 10)
                        {
                            spaceOccupied = true;
                            break;
                        }
                        else
                        {
                            spaceOccupied = false;
                        }
                    }
                    else if (orientation == "horizontal")
                    {
                        if (IsFieldOccupied((char)(column + i), row) || (column + i) > 'J')
                        {
                            spaceOccupied = true;
                            break;
                        }
                        else
                        {
                            spaceOccupied = false;
                        }
                    }
                }
            }
            AddShip(ship, column, row, orientation);
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
                    var shipField = new ShipField(column, startingPositionRow);
                    ship.Fields.Add(shipField);
                }
            }
            else if (orientation == "vertical")
            {
                var endPositionRow = startingPositionRow + ship.Size - 1;
                for (int row = startingPositionRow; row <= endPositionRow; row++)
                {
                    var shipField = new ShipField(startingPositionColumn, row);
                    ship.Fields.Add(shipField);
                }
            }
        }

        public bool IsFieldOccupied(char column, int row)
        {
            Ship ship = Ships.Find(s => s.Fields.Exists(bf => bf.Column == column && bf.Row == row));
            return ship != null;
        }
    }
}