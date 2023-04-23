using Battleships.Domain;
using Battleships.Domain.GameGrid;
using Battleships.Domain.ShotResults;
using Battleships.Game;
using Battleships.UserInterface;

namespace Battleships.GameStates;

internal sealed class Shooting : IGameState
{
    private readonly Coordinates _coordinates;

    public Shooting(Coordinates coordinates)
    {
        _coordinates = coordinates;
    }

    public IGameState Move(GameContext context)
    {
        var result = context.Game.Shoot(_coordinates);

        if (result is InvalidCoordinatesResult)
            return new InvalidCoordinates();

        context.Output.PrintMessage(result.ToMessage());

        return context.Game.IsFinished 
            ? new Finished() 
            : new WaitForMove();
    }
}