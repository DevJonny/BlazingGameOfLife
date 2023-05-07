namespace GameOfLife;

public static class CoordinateExtensions
{
    public static int CalculateAliveNeighbours(this (int x, int y) cell, int size, Func<(int, int), bool> isAlive)
    {
        var (x, y) = cell;
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

                if (isAlive((h, v)))
                    aliveNeighbours++;
            }
        }

        return aliveNeighbours;

        bool IsOutOfBounds(int value)
            => value < 0 || value >= size;

        bool IsCurrentCell(int x, int y, int h, int v)
            => x == h && y == v;
    }
}