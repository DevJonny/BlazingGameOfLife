namespace GameOfLife;

public interface IRunTheGameOfLife
{
    bool IsAlive((int x, int y) cell);
    void RandomSeed(int percentOfAlive = 25);
    void Seed(params (int x, int y)[] cells);
    void Tick();
}