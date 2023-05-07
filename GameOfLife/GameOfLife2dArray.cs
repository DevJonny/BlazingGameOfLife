namespace GameOfLife;

public class GameOfLife2dArray : IRunTheGameOfLife
{
    public int Size { get; }
    
    private readonly bool[,] _newWorld;
    
    private bool[,] _world;

    public GameOfLife2dArray(int size)
    {
        _world = new bool[size, size];
        Size = size;
        _newWorld = new bool[size,size];
    }

    public bool IsAlive((int x, int y) cell) => _world[cell.x, cell.y];

    public void RandomSeed(int percentOfAlive = 25)
    {
        var random = new Random();
            
        for (var x = 0; x < Size; x++)
        for (var y = 0; y < Size; y++)
            _world[x, y] = random.Next(100) <= percentOfAlive;
    }

    public void Seed(params (int x, int y)[] cells)
    {
        for (var x = 0; x < Size; x++)
        for (var y = 0; y < Size; y++)
            _world[x,y] = cells.Contains((x,y));
    }
        
    public void Tick()
    {
        for (var x = 0; x < Size; x++)
        {
            for (var y = 0; y < Size; y++)
            {
                var aliveNeighbours = (x,y).CalculateAliveNeighbours(Size, IsAlive);

                if (aliveNeighbours < 2)
                    _newWorld[x, y] = false;
                else if (aliveNeighbours > 3)
                    _newWorld[x, y] = false;
                else if (_world[x, y] && aliveNeighbours is 2 or 3)
                    _newWorld[x, y] = true;
                else if (aliveNeighbours is 3)
                    _newWorld[x, y] = true;
                else
                    _newWorld[x, y] = _world[x, y];
            }
        }
            
        _world = _newWorld;
    }
}