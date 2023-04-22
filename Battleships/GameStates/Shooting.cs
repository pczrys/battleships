using Battleships.Domain.ShotResults;
using Battleships.Game;
using Battleships.UserInterface;

namespace Battleships.GameStates;

internal sealed class Shooting : IGameState
{
    private readonly char _column;
    private readonly int _row;

    public Shooting(char column, int row)
    {
        _column = column;
        _row = row;
    }

    public IGameState Move(GameContext context)
    {
        var result = context.Game.Shoot(_column, _row);

        if (result is InvalidCoordinatesResult)
            return new InvalidCoordinates();

        context.Output.PrintMessage(result.ToMessage());

        return context.Game.IsFinished 
            ? new Finished() 
            : new WaitForMove();
    }
}