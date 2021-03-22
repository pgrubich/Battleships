using System;

namespace Battleships.Core
{
    public class Game
    {
        public Game()
        { 
        }

        public Board Board { get; set; }

        public string Shoot(char row, int column)
        {
            var field = Board.BoardFields.Find(f => f.Row == row && f.Column == column);
            if (field.Value == "Empty")
                return "Miss";
            else
                return "Hit. " + field.Value;
        }
    }
}
