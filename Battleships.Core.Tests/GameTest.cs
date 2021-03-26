using System;
using Xunit;

namespace Battleships.Core
{
    public class GameTest
    {
        private Game _game;

        public GameTest()
        {
            _game = new Game(new Board(), new ScoreBoard());
        }

        [Fact]
        public void ShouldReturnMissWhenFieldIsEmpty()
        {
            var score = _game.Shoot('A', 1);

            Assert.NotNull(score);
            Assert.Equal("Miss", score);
        }

        [Fact]
        public void ShouldReturnHitWithCorrectShip()
        {
            var destroyer = new Ship("Destroyer", 4);
            _game.Board.AddShip(destroyer, 'A', 1, "horizontal");

            var score = _game.Shoot('A', 1);

            Assert.NotNull(score);
            Assert.Equal("Hit. Destroyer", score);
        }

        [Fact]
        public void ShouldReturnSunkWithCorrectShip()
        {
            var destroyer1 = new Ship("Destroyer", 4);
            var destroyer2 = new Ship("Destroyer", 4);
            _game.Board.AddShip(destroyer1, 'A', 1, "horizontal");
            _game.Board.AddShip(destroyer2, 'I', 7, "vertical");

            _game.Shoot('A', 1);
            _game.Shoot('B', 1);
            _game.Shoot('B', 1);
            _game.Shoot('C', 1);
            var score = _game.Shoot('D', 1);

            Assert.NotNull(score);
            Assert.Equal("Sunk. Destroyer", score);
        }

        [Fact]
        public void ShouldEndGameWhenAllShipsHasSunk()
        {
            var destroyer1 = new Ship("Destroyer", 4);
            var destroyer2 = new Ship("Destroyer", 4);
            var battleship = new Ship("Battleship", 5);
            _game.Board.AddShip(destroyer1, 'E', 7, "horizontal");
            _game.Board.AddShip(destroyer2, 'I', 7, "vertical");
            _game.Board.AddShip(battleship, 'D', 2, "horizontal");

            _game.Shoot('E', 2);
            _game.Shoot('F', 2);
            _game.Shoot('G', 2);
            _game.Shoot('H', 2);
            _game.Shoot('D', 2);

            _game.Shoot('E', 7);
            _game.Shoot('F', 7);
            _game.Shoot('G', 7);
            _game.Shoot('H', 7);

            _game.Shoot('I', 7);
            _game.Shoot('I', 8);
            _game.Shoot('I', 9);
            _game.Shoot('I', 10);

            Assert.True(_game.End);
        }
    }
}
