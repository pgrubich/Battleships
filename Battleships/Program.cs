using Battleships.Core;
using System;
using System.Text.RegularExpressions;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            string shotResult = "";
            Regex rx = new Regex(@"^[A-J](10|[1-9])$");

            var game = new Game(new Board(), new ScoreBoard()); 
            game.CreateShips();

            Console.WriteLine("Welcome to the Battleships Game. To shoot, enter coordinates in correct format (e.g. A5)");
 
            while (!game.End)
            {               
                game.ScoreBoard.DrawBoard();
                Console.WriteLine(shotResult);

                var coordinates = Console.ReadLine();

                if (rx.IsMatch(coordinates))
                {

                    char column = coordinates[0];
                    int row = Convert.ToInt32(rx.Match(coordinates).Groups[1].Value);
                    shotResult = game.Shoot(column, row);
                }
                else
                {
                    shotResult = "Invalid coordinates. Try again.";
                }
                Console.Clear();
            }

            Console.WriteLine("Congratulations, you won!");
        }
    }
}
