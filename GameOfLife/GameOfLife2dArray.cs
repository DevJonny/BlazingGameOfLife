namespace GameOfLife;

public class GameOfLife2dArray : IRunTheGameOfLine
{
    private bool[,] _world;

    private readonly int _size;
    private readonly bool[,] _newWorld;

    public GameOfLife2dArray(int size)
    {
        _world = new bool[size, size];
        _size = size;
        _newWorld = new bool[size,size];
    }

    public bool IsAlive((int x, int y) cell) => _world[cell.x, cell.y];

    public void RandomSeed(int percentOfAlive = 25)
    {
        var random = new Random();
            
        for (var x = 0; x < _size; x++)
        for (var y = 0; y < _size; y++)
            _world[x, y] = random.Next(100) <= percentOfAlive;
    }

    public void Seed(params (int x, int y)[] cells)
    {
        for (var x = 0; x < _size; x++)
        for (var y = 0; y < _size; y++)
            _world[x,y] = cells.Contains((x,y));
    }
        
    public void Tick()
    {
        for (var x = 0; x < _size; x++)
        {
            for (var y = 0; y < _size; y++)
            {
                var aliveNeighbours = CalculateAliveNeighbours(x, y);

                if (aliveNeighbours < 2)
                    _newWorld[x, y] = false;
                else if (aliveNeighbours > 3)
                    _newWorld[x, y] = false;
                else if (_world[x, y] && (aliveNeighbours is 2 || aliveNeighbours is 3))
                    _newWorld[x, y] = true;
                else if (aliveNeighbours is 3)
                    _newWorld[x, y] = true;
                else
                    _newWorld[x, y] = _world[x, y];
            }
        }
            
        _world = _newWorld;
    }

    private int CalculateAliveNeighbours(int x, int y)
    {
        var aliveNeighbours = 0;
            
        for (var h = x-1; h <= x+1; h++)
        {
            if (IsOutOfBounds(h))
                continue;
                
            for (var v = y - 1; v <= y + 1; v++)
            {
                if (IsCurrentCell(x, y, h, v))
                    continue;
                    
                if (IsOutOfBounds(v))
                    continue;

                if (_world[h, v])
                    aliveNeighbours++;
            }
        }

        return aliveNeighbours;
    }

    private bool IsCurrentCell(int x, int y, int h, int v) => x == h && y == v;

    private bool IsOutOfBounds(int value) => value < 0 || value >= _size;
    
}