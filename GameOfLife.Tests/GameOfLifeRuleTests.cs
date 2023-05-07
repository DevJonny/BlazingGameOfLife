namespace GameOfLife.Tests;

public class GameOfLifeRuleTests
{
    /**
         *  - - -
         *  - x -
         *  - - -
         */
    [Theory]
    [MemberData(nameof(ThreeByThree))]
    public void Underpopulation(IRunTheGameOfLife gameOfLife)
    {
        // arrange
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
    [Theory]
    [MemberData(nameof(ThreeByThree))]
    public void Two_Neighbours(IRunTheGameOfLife gameOfLife)
    {
        // arrange
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
    [Theory]
    [MemberData(nameof(ThreeByThree))]
    public void Three_Neighbours(IRunTheGameOfLife gameOfLife)
    {
        // arrange
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
    [Theory]
    [MemberData(nameof(ThreeByThree))]
    public void Overpopulation(IRunTheGameOfLife gameOfLife)
    {
        // arrange
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
    [Theory]
    [MemberData(nameof(ThreeByThree))]
    public void Reproduction(IRunTheGameOfLife gameOfLife)
    {
        // arrange
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
    [Theory]
    [MemberData(nameof(SixBySix))]
    public void All_Rules(IRunTheGameOfLife gameOfLife)
    {
        // arrange
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

    public static IEnumerable<object[]> ThreeByThree =>
        new List<object[]>
        {
            new object[] { new GameOfLife2dArray(3) }
        };

    public static IEnumerable<object[]> SixBySix =>
        new List<object[]>
        {
            new object[] { new GameOfLife2dArray(6) }
        };
}