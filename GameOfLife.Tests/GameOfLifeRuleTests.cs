using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameOfLifeRuleTests
    {
        [Fact]
        public void Underpopulation()
        {
            // arrange
            var gameOfLife = new GameOfLife(3);
            gameOfLife.Seed(new [,]
            {
                { false, false, false },
                { false, true,  false },
                { false, false, false }
            });
            
            // act
            gameOfLife.Tick();
            
            // assert
            gameOfLife.World.Should().BeEquivalentTo(new[,]
            {
                { false, false, false },
                { false, false, false },
                { false, false, false }
            });
        }

        [Fact]
        public void Two_Neighbours()
        {
            // arrange
            var gameOfLife = new GameOfLife(3);
            gameOfLife.Seed(new[,]
            {
                { false, true,  false },
                { true,  false, true  },
                { false, true,  false }
            });
            
            // act
            gameOfLife.Tick();
            
            // assert
            gameOfLife.World.Should().BeEquivalentTo(new[,]
            {
                { false, true,  false },
                { true,  false, true  },
                { false, true,  false }
            });
        }

        [Fact]
        public void Three_Neighbours()
        {
            // arrange
            var gameOfLife = new GameOfLife(3);
            gameOfLife.Seed(new[,]
            {
                { false, false, false },
                { true,  true,  true  },
                { false, true,  false }
            });
            
            // act
            gameOfLife.Tick();

            // assert
            gameOfLife.World[1, 0].Should().BeTrue();
            gameOfLife.World[1, 1].Should().BeTrue();
            gameOfLife.World[1, 2].Should().BeTrue();
            gameOfLife.World[2, 1].Should().BeTrue();
        }
        
        [Fact]
        public void Overpopulation()
        {
            // arrange
            var gameOfLife = new GameOfLife(3);
            gameOfLife.Seed(new[,]
            {
                { false, true, false },
                { true,  true, true  },
                { false, true, false }
            });

            // act
            gameOfLife.Tick();

            // assert
            gameOfLife.World[1, 1].Should().BeFalse();
        }
        
        [Fact]
        public void Reproduction()
        {
            // arrange
            var gameOfLife = new GameOfLife(3);
            gameOfLife.Seed(new[,]
            {
                { false, false, false },
                { true,  true,  true  },
                { false, true,  false }
            });

            // act
            gameOfLife.Tick();

            // assert
            gameOfLife.World.Should().BeEquivalentTo(new[,]
            {
                { false, true, false },
                { true,  true, true  },
                { true,  true, true  }
            });
        }

        [Fact]
        public void All_Rules()
        {
            // arrange
            var gameOfLife = new GameOfLife(6);
            gameOfLife.Seed(new [,]
            {
                { false, true,  false, false, false, false },
                { false, false, false, false, false, false },
                { false, true,  true,  true,  false, false },
                { false, false, true,  false, false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false }
            });
            
            // act
            gameOfLife.Tick();
            
            // assert
            gameOfLife.World.Should().BeEquivalentTo(new[,]
            {
                { false, false, false, false, false, false },
                { false, true,  false,  false, false, false },
                { false, true,  true,  true,  false, false },
                { false, true,  true,  true,  false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false }
            });
        }
    }
}