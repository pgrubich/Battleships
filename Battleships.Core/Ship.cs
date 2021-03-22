namespace Battleships.Core
{
    public class Ship
    {
        public string Type { get; set; }
        public int Size { get; set; }

        public Ship(string type, int size)
        {
            Type = type;
            Size = size;
        }
    }
}