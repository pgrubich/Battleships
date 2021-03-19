using System.Collections.Generic;

namespace Battleships.Core
{
    public class Board
    {
        public List<BoardField> BoardFields { get; set; }
        public Board()
        {
            BoardFields = new List<BoardField>();           
            for (char row = 'A'; row <= 'J'; row++)
            {
                for (int column = 1; column <= 10; column++)
                {
                    BoardFields.Add(new BoardField(row.ToString() + column.ToString()));
                }
            }           
        }
    }
}