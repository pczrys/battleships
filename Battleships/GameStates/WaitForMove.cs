using Battleships.Game;
using Battleships.UserInterface;

namespace Battleships.GameStates;

internal sealed class WaitForMove : IGameState
{
    public IGameState Move(GameContext context)
    {
        context.Output.PrintGrid(context.Game.Grid);

        context.Output.PrintMessage("Enter shot coordinates:");

        var coordinates = context.Input.Read().AsCoordinates();
        
        return coordinates == null 
            ? new InvalidCoordinates() 
            : new Shooting(coordinates.Value);
    }
}