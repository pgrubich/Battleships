using System.Collections.Generic;

namespace Battleships.Core
{
    public class Ship
    {
        public string Type { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public List<BoardField> BoardFields { get; set; }

        public Ship(string type, int size)
        {
            Type = type;
            Size = size;
            Hits = 0;
            BoardFields = new List<BoardField>();
        }
    }
}