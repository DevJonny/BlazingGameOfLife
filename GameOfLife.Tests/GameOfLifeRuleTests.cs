using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameOfLifeRuleTests
    {
        [Fact]
        public void Live_cell_with_less_than_two_dies()
        {
            // arrange
            var gameOfLife = new GameOfLife(5);
            gameOfLife.Seed(new[,]
            {
                { true, true, false, false, true },
                { false, false, false, false, true },
                { false, false, false, false, false },
                { false, false, false, true, false },
                { false, false, false, false, false}
            });
            
            // act
            gameOfLife.Tick();

            // assert
            gameOfLife.World.Should().BeEquivalentTo(new[,]
            {
                { false, false, false, false, false },
                { false, false, false, false, false },
                { false, false, false, false, false },
                { false, false, false, false, false },
                { false, false, false, false, false }
            });
        }
        
        [Fact]
        public void Live_cell_with_two_lives()
        {
            // arrange
            var gameOfLife = new GameOfLife(2);
            gameOfLife.Seed(new[,]
            {
                { true, false },
                { true, true }
            });
            
            // act
            gameOfLife.Tick();

            // assert
            gameOfLife.World.Should().BeEquivalentTo(new[,]
            {
                { true, true },
                { true, true }
            });
        }
        
        [Fact]
        public void Live_cell_with_three_lives()
        {
            // arrange
            var gameOfLife = new GameOfLife(3);
            gameOfLife.Seed(new[,]
            {
                { true, false, false },
                { true, true, false },
                { true, false, false }
            });
            
            // act
            gameOfLife.Tick();

            // assert
            gameOfLife.World.Should().BeEquivalentTo(new[,]
            {
                { true, true, false },
                { true, true, false },
                { true, true, false }
            });
        }
        
        [Fact]
        public void Live_cell_with_more_than_three_dies()
        {
            // arrange
            var gameOfLife = new GameOfLife(3);
            gameOfLife.Seed(new[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            });

            // act
            gameOfLife.Tick();

            // assert
            gameOfLife.World.Should().BeEquivalentTo(new[,]
            {
                { true, false, true },
                { false, false, false },
                { true, false, true }
            });
        }
        
        [Fact]
        public void Dead_cell_with_three_becomes_live()
        {
            // arrange
            var gameOfLife = new GameOfLife(3);
            gameOfLife.Seed(new[,]
            {
                { true, true, false },
                { true, false, false },
                { false, false, false }
            });

            // act
            gameOfLife.Tick();

            // assert
            gameOfLife.World.Should().BeEquivalentTo(new[,]
            {
                { true, true, false },
                { true, true, false },
                { false, false, false }
            });
        }
    }
}