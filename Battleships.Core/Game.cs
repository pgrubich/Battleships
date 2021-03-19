using System;

namespace Battleships.Core
{
    public class Game
    {
        public Game()
        { 
        }

        public Board Board { get; set; }

        public string Shoot(string coordinates)
        {
            var field = Board.BoardFields.Find(f => f.Coordinates == coordinates);
            if (field.Value == "Empty")
                return "Miss";
            else
                return "Hit";
        }
    }
}
