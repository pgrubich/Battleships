namespace Battleships.Core
{
    public class BoardField
    {
        public int Row { get; set; }
        public char Column { get; set; }
        public FieldDesignation Value { get; set; }
        public BoardField(char column, int row)
        {
            Row = row;
            Column = column;
            Value = FieldDesignation.NotVisited;
        }

        public enum FieldDesignation
        {
            NotVisited,
            Hit,
            Sunk
        }
    }
}