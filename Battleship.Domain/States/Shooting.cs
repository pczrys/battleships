namespace Battleships.Domain.States;

internal sealed class Shooting : IGameState
{
    private readonly char _column;
    private readonly int _row;

    public Shooting(char column, int row)
    {
        _column = column;
        _row = row;
    }

    public IGameState Move(Game game)
    {
        var result = game.Shoot(_column, _row);
        game.Output.PrintShotResult(result);

        return game.IsFinished ? new Finished() : new WaitForMove();
    }
}