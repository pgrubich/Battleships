using System;
using Xunit;

namespace Battleships.Core
{
    public class GameTest
    {
        [Fact]
        public void ShouldReturnMissWhenFieldIsEmpty()
        {
            var game = new Game()
            {
                Board = new Board()
            };

            var score = game.Shoot("A1");

            Assert.NotNull(score);
            Assert.Equal("Miss", score);
        }
    }
}
