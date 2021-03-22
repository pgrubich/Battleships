namespace Battleships.Core
{
    public class BoardField
    {
        public char Row { get; set; }
        public int Column { get; set; }
        public string Value { get; set; }
        public BoardField(char row, int column)
        {
            Row = row;
            Column = column;
            Value = "Empty";
        }

    }
}