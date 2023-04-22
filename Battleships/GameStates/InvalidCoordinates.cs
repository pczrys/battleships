using Battleships.Game;

namespace Battleships.GameStates;

internal sealed class InvalidCoordinates : IGameState
{
    public IGameState Move(GameContext context)
    {
        context.Output.PrintMessage("Shot coordinates are invalid. Please try again.");
        return new WaitForMove();
    }
}