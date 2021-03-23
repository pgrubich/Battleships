using System;

namespace Battleships.Core
{
    public class Game
    {
        public Game()
        { 
        }

        public Board Board { get; set; }

        public string Shoot(char column, int row)
        {
            string message;
            Ship ship = Board.Ships.Find(s => s.BoardFields.Exists(bf => bf.Column == column && bf.Row == row));

            if (ship != null)
            {
                var boardField = ship.BoardFields.Find(f => f.Column == column && f.Row == row);
                if (boardField.Value == BoardField.FieldDesignation.NotVisited)
                {
                    boardField.Value = BoardField.FieldDesignation.Hit;
                    ship.Hits += 1;

                    if (ship.HasSunk)
                    {
                        Board.ShipsLeft -= 1;
                        foreach (var f in ship.BoardFields)
                        {
                            f.Value = BoardField.FieldDesignation.Sunk;
                        }
                    }
                }

                message = boardField.Value + ". " + ship.Type;
                if (Board.ShipsLeft == 0)
                    message += ". " + "You won.";
            }
            else
            {
                message = "Miss";
            }
            return message;
        }
    }
}
