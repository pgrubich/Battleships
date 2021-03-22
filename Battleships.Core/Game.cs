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
            Ship ship = Board.Ships.Find(s => s.BoardFields.Exists(bf => bf.Column == column && bf.Row == row));

            if (ship != null)
            {
                var boardField = ship.BoardFields.Find(f => f.Column == column && f.Row == row);
                if (boardField.Value == null)
                {
                    boardField.Value = "Hit";
                    ship.Hits += 1;
                    if (ship.Hits == ship.Size)
                    {
                        foreach (var f in ship.BoardFields)
                        {
                            f.Value = "Sunk";
                        }
                    }
                }
                return boardField.Value + ". " + ship.Type;
            }
            else
            {
                return "Miss";
            }
        }
    }
}
