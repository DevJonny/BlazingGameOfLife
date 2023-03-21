using CommandLine;
using Spectre.Console;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(o =>
    {
        RunGame(o).Wait();
    });

async Task RunGame(Options options)
{
    var gameOfLife = new GameOfLife.GameOfLife(options.Size);
    gameOfLife.RandomSeed(options.Seed);
    
    var tickInterval = TimeSpan.FromMilliseconds(1000 / options.Speed);
    
    var canvas = new Canvas(options.Size, options.Size);
    
    await AnsiConsole.Live(canvas)
        .StartAsync(async ctx => 
        {
            for (;;)
            {
                for(var x = 0; x < options.Size; x++)
                    for(var y = 0; y < options.Size; y++)
                        canvas.SetPixel(x, y, gameOfLife.World[x, y] ? Color.Green : Color.Red);
                
                ctx.Refresh();

                await Task.Delay(tickInterval);
                gameOfLife.Tick();
            }
        });
}

public class Options
{
    [Option('s', "size", Required = true, HelpText = "Set size of the grid.")]
    public int Size { get; init; }

    [Option("seed", Required = false, Default = 10, HelpText = "Percentage of the board seeded with life cells")]
    public int Seed { get; init; }
    
    [Option("speed", Required = false, Default = 5, HelpText = "Refresh rate in frames per second")]
    public int Speed { get; init; }
}