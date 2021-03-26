using Battleships.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core
{
    public class ScoreBoard
    {
        public string[,] Board { get; set; }
        public int ColumnsNumber { get; set; }
        public int RowsNumber { get; set; }

        public ScoreBoard()
        {
            ColumnsNumber = 10;
            RowsNumber = 10;
            Board = new string[RowsNumber, ColumnsNumber];

            for (int row = 0; row < RowsNumber; row++)
            {
                for (int column = 0; column < ColumnsNumber; column++)
                {
                    Board[row, column] = EnumHelper.GetFieldDescription(FieldDesignation.NotVisited);
                }
            }
        }

        public void DrawBoard()
        {
            Console.Write("   ");
            for (char i = 'A'; i <= NumberToCharacter(ColumnsNumber); i++)
            {
                Console.Write(i.ToString() + "  ");
            }
            Console.WriteLine(Environment.NewLine);
            for (int row = 0; row < RowsNumber; row++)
            {
                Console.Write((row + 1).ToString());
                if (row < RowsNumber - 1)
                {
                    Console.Write("  ");
                }
                else
                {
                    Console.Write(" ");
                }
                for (int column = 0; column < ColumnsNumber; column++)
                {
                    var value = Board[row, column];
                    Console.Write(value + "  ");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }

        public char NumberToCharacter(int number)
        {
            return (char)((char)number + 64);
        }
    }
}
