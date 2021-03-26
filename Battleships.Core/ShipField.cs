using System.ComponentModel;

namespace Battleships.Core
{
    public class ShipField
    {
        public int Row { get; set; }
        public char Column { get; set; }
        public FieldDesignation Value { get; set; }
        public ShipField(char column, int row)
        {
            Row = row;
            Column = column;
            Value = FieldDesignation.NotVisited;
        }
    }
}