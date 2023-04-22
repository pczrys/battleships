using Battleships.Game;
using Battleships.UserInterface;

namespace Battleships.GameStates;

internal sealed class WaitForMove : IGameState
{
    public IGameState Move(GameContext context)
    {
        context.Output.PrintGrid(context.Game.Grid);
        context.Output.PrintEmptyLine();
        context.Output.PrintMessage("Enter shot coordinates:");

        var coordinates = context.Input.Read().AsCoordinates();
        if (coordinates == null)
            return new InvalidCoordinates();

        return new Shooting(coordinates.Value.Column, coordinates.Value.Row);
    }
}