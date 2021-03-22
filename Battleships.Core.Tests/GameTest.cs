using System;
using Xunit;

namespace Battleships.Core
{
    public class GameTest
    {
        private Game _game;
        private Board _board;

        public GameTest()
        {
            _game = new Game();
            _board = new Board();
            _game.Board = _board;
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
            _board.AddShip(destroyer, 'A', 1, "horizontal");

            var score = _game.Shoot('A', 1);

            Assert.NotNull(score);
            Assert.Equal("Hit. Destroyer", score);
        }
    }
}
