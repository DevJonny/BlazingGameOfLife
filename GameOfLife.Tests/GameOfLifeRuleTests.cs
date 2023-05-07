namespace GameOfLife.Tests;

public class GameOfLifeRuleTests
{
    /**
         *  - - -
         *  - x -
         *  - - -
         */
    [Fact]
    public void Underpopulation()
    {
        // arrange
        var gameOfLife = new GameOfLife2dArray(3);
        gameOfLife.Seed((1, 1));
            
        // act
        gameOfLife.Tick();
            
        // assert
        // - - -
        // - - -
        // - - -
        gameOfLife.IsAlive((1, 1)).Should().BeFalse();
    }

    /**
         *  - x -
         *  x - x
         *  - x -
         */
    [Fact]
    public void Two_Neighbours()
    {
        // arrange
        var gameOfLife = new GameOfLife2dArray(3);
        gameOfLife.Seed((0, 1), (1, 0), (1, 2), (2, 1));
            
        // act
        gameOfLife.Tick();
            
        // assert
        // - x -
        // x - x
        // - x -
        gameOfLife.IsAlive((0, 1)).Should().BeTrue();
        gameOfLife.IsAlive((1, 0)).Should().BeTrue();
        gameOfLife.IsAlive((1, 2)).Should().BeTrue();
        gameOfLife.IsAlive((2, 1)).Should().BeTrue();
    }

    /**
         *  - x -
         *  x x x
         *  - x -
         */
    [Fact]
    public void Three_Neighbours()
    {
        // arrange
        var gameOfLife = new GameOfLife2dArray(3);
        gameOfLife.Seed((1, 0), (1, 1), (1, 2), (2, 1));
            
        // act
        gameOfLife.Tick();

        // assert
        // - x -
        // x - x
        // - x -
        gameOfLife.IsAlive((0, 1)).Should().BeTrue();
        gameOfLife.IsAlive((1, 0)).Should().BeTrue();
        gameOfLife.IsAlive((1, 2)).Should().BeTrue();
        gameOfLife.IsAlive((2, 1)).Should().BeTrue();
    }
        
    /**
         *  - x -
         *  x x x
         *  - x -
         */
    [Fact]
    public void Overpopulation()
    {
        // arrange
        var gameOfLife = new GameOfLife2dArray(3);
        gameOfLife.Seed((0, 1), (1, 0), (1, 1), (1, 2), (2, 1));

        // act
        gameOfLife.Tick();

        // assert
        // - x -
        // x - x
        // - x -
        gameOfLife.IsAlive((1, 1)).Should().BeFalse();
    }
        
    /**
         *  - - -
         *  x x x
         *  - x -
         */
    [Fact]
    public void Reproduction()
    {
        // arrange
        var gameOfLife = new GameOfLife2dArray(3);
        gameOfLife.Seed((1, 0), (1, 1), (1, 2), (2, 1));

        // act
        gameOfLife.Tick();

        // assert
        //  - x -
        //  x x x
        //  x x x
        gameOfLife.IsAlive((0, 1)).Should().BeTrue();
        gameOfLife.IsAlive((2, 0)).Should().BeTrue();
        gameOfLife.IsAlive((2, 2)).Should().BeTrue();
    }

    /**
         *  - x - - - -
         *  - - - - - -
         *  - x x x - -
         *  - - x - - -
         *  - - - - - -
         */
    [Fact]
    public void All_Rules()
    {
        // arrange
        var gameOfLife = new GameOfLife2dArray(6);
        gameOfLife.Seed((0, 1), (2, 1), (2, 2), (2, 3), (3, 2));
            
        // act
        gameOfLife.Tick();
            
        // assert
        // - - - - - -
        // - x - - - -
        // - x x x - -
        // - x x x - -
        // - - - - - -
        // - - - - - -
        gameOfLife.IsAlive((0, 0)).Should().BeFalse();
        gameOfLife.IsAlive((0, 1)).Should().BeFalse();
        gameOfLife.IsAlive((0, 2)).Should().BeFalse();
        gameOfLife.IsAlive((0, 3)).Should().BeFalse();
        gameOfLife.IsAlive((0, 4)).Should().BeFalse();
        gameOfLife.IsAlive((0, 5)).Should().BeFalse();
        gameOfLife.IsAlive((1, 0)).Should().BeFalse();
        gameOfLife.IsAlive((1, 1)).Should().BeTrue();
        gameOfLife.IsAlive((1, 2)).Should().BeFalse();
        gameOfLife.IsAlive((1, 3)).Should().BeFalse();
        gameOfLife.IsAlive((1, 4)).Should().BeFalse();
        gameOfLife.IsAlive((1, 5)).Should().BeFalse();
        gameOfLife.IsAlive((2, 0)).Should().BeFalse();
        gameOfLife.IsAlive((2, 1)).Should().BeTrue();
        gameOfLife.IsAlive((2, 2)).Should().BeTrue();
        gameOfLife.IsAlive((2, 3)).Should().BeTrue();
        gameOfLife.IsAlive((2, 4)).Should().BeFalse();
        gameOfLife.IsAlive((2, 5)).Should().BeFalse();
        gameOfLife.IsAlive((3, 0)).Should().BeFalse();
        gameOfLife.IsAlive((3, 1)).Should().BeTrue();
        gameOfLife.IsAlive((3, 2)).Should().BeTrue();
        gameOfLife.IsAlive((3, 3)).Should().BeTrue();
        gameOfLife.IsAlive((3, 4)).Should().BeFalse();
        gameOfLife.IsAlive((3, 5)).Should().BeFalse();
        gameOfLife.IsAlive((4, 0)).Should().BeFalse();
        gameOfLife.IsAlive((4, 1)).Should().BeFalse();
        gameOfLife.IsAlive((4, 2)).Should().BeFalse();
        gameOfLife.IsAlive((4, 3)).Should().BeFalse();
        gameOfLife.IsAlive((4, 4)).Should().BeFalse();
        gameOfLife.IsAlive((4, 5)).Should().BeFalse();
        gameOfLife.IsAlive((5, 0)).Should().BeFalse();
        gameOfLife.IsAlive((5, 1)).Should().BeFalse();
        gameOfLife.IsAlive((5, 2)).Should().BeFalse();
        gameOfLife.IsAlive((5, 3)).Should().BeFalse();
        gameOfLife.IsAlive((5, 4)).Should().BeFalse();
        gameOfLife.IsAlive((5, 5)).Should().BeFalse();
    }
}