using Battleships.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Battleships.Core
{
    public class Game
    {
        public Board Board { get; set; }
        public ScoreBoard ScoreBoard { get; set; }
        public bool End
        {
            get { return Board.ShipsLeft == 0; }
        }

        public Game(Board board, ScoreBoard scoreBoard)
        {
            Board = board;
            ScoreBoard = scoreBoard;
        }

        public void CreateShips()
        {
            CreateShip("Destroyer", 4);
            CreateShip("Destroyer", 4);
            CreateShip("Battleship", 5);
        }

        public void CreateShip(string shipType, int shipSize)
        {
            var ship = new Ship(shipType, shipSize);
            Board.FindPlaceForShip(ship);
        }

        public string Shoot(char column, int row)
        {
            string message;
            Ship ship = Board.Ships.Find(s => s.Fields.Exists(bf => bf.Column == column && bf.Row == row));

            if (ship != null)
            {
                var shipField = ship.Fields.Find(f => f.Column == column && f.Row == row);
                if (shipField.Value == FieldDesignation.NotVisited)
                {
                    shipField.Value = FieldDesignation.Hit;
                    ScoreBoard.Board[row-1, CharacterToNumber(column)-1] = EnumHelper.GetFieldDescription(FieldDesignation.Hit);
                    ship.Hits += 1;

                    if (ship.HasSunk)
                    {
                        Board.ShipsLeft -= 1;
                        foreach (var f in ship.Fields)
                        {
                            f.Value = FieldDesignation.Sunk;
                            ScoreBoard.Board[f.Row-1, CharacterToNumber(f.Column)-1] = EnumHelper.GetFieldDescription(FieldDesignation.Sunk);
                        }
                    }
                }

                message = shipField.Value + ". " + ship.Type;
            }
            else
            {
                message = "Miss";
                ScoreBoard.Board[row-1, CharacterToNumber(column)-1] = EnumHelper.GetFieldDescription(FieldDesignation.Visited);
            }
            return message;
        }

        public int CharacterToNumber(char character)
        {
            return character - 64;
        }
    }
}
