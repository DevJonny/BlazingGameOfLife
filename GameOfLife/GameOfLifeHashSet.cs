namespace GameOfLife;

public class GameOfLifeHashSet : IRunTheGameOfLife
{
    private readonly int _size;
    private readonly ISet<(int X, int Y)> _newAliveCells;
    
    private ISet<(int X, int Y)> _aliveCells;

    public GameOfLifeHashSet(int size)
    {
        _size = size;
        _aliveCells = new HashSet<(int X, int Y)>(size);
        _newAliveCells = new HashSet<(int X, int Y)>(size);
    }

    public bool IsAlive((int x, int y) cell) => _aliveCells.Contains(cell);

    public void RandomSeed(int percentOfAlive = 25)
    {
        var random = new Random();
            
        for (var x = 0; x < _size; x++)
            for (var y = 0; y < _size; y++)
                if (random.Next(100) <= percentOfAlive)
                    _aliveCells.Add((x, y));
    }

    public void Seed(params (int x, int y)[] cells) 
        => _aliveCells = new HashSet<(int X, int Y)>(cells);

    public void Tick()
    {
        for (var x = 0; x < _size; x++)
        for (var y = 0; y < _size; y++)
        {
            var currentlyAlive = IsAlive((x, y));
            var aliveNeighbours = (x, y).CalculateAliveNeighbours(_size, IsAlive);
            
            if ((currentlyAlive, aliveNeighbours) switch
                {
                    (_, < 2) => false,
                    (_, > 3) => false,
                    (true, 2) => true,
                    (_, 3) => true,
                    (_, _) => IsAlive((x, y))
                })
                _newAliveCells.Add((x, y));
        }

        _aliveCells = _newAliveCells;
    }
}