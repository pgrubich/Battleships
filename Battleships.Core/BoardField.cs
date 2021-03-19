namespace Battleships.Core
{
    public class BoardField
    {
        public string Coordinates { get; set; }
        public string Value { get; set; }
        public BoardField(string coordinates)
        {
            Coordinates = coordinates;
            Value = "Empty";
        }

    }
}