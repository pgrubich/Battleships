using System.Collections.Generic;

namespace Battleships.Core
{
    public class Ship
    {
        public string Type { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public bool HasSunk
        {
            get { return Hits == Size; }
        }
        public List<ShipField> Fields { get; set; }

        public Ship(string type, int size)
        {
            Type = type;
            Size = size;
            Hits = 0;
            Fields = new List<ShipField>();
        }
    }
}