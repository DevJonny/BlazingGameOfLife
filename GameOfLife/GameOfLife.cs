using System;

namespace GameOfLife
{
    public class GameOfLife
    {
        public bool[,] World { get; private set; }

        private readonly int _size;
        private readonly bool[,] _newWorld;

        public GameOfLife(int size)
        {
            World = new bool[size, size];
            _size = size;
            _newWorld = World;
        }

        public void RandomSeed(int percentOfAlive = 25)
        {
            var random = new Random();
            
            for (var x = 0; x < _size; x++)
                for (var y = 0; y < _size; y++)
                    World[x, y] = random.Next(100) <= percentOfAlive;
        }

        public void Seed(bool[,] entries)
        {
            World = entries;
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
                    else if (World[x, y] && (aliveNeighbours is 2 || aliveNeighbours is 3))
                        _newWorld[x, y] = true;
                    else if (!World[x, y] && aliveNeighbours is 3)
                        _newWorld[x, y] = true;
                    else
                        _newWorld[x, y] = World[x, y];
                }
            }
            
            World = _newWorld;
        }

        private int CalculateAliveNeighbours(int x, int y)
        {
            var aliveNeighbours = 0;
            
            for (var h = x-1; h <= x+1; h++)
            {
                if (h < 0 || h >= _size)
                    continue;
                
                for (var v = y - 1; v <= y + 1; v++)
                {
                    if (v < 0 || v >= _size)
                        continue;
                    
                    if (h == x && v == y)
                        continue;

                    if (World[h, v])
                        aliveNeighbours++;
                }
            }

            return aliveNeighbours;
        }
    }
}