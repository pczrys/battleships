namespace Battleships.Domain.States;

internal sealed class Starting : IGameState
{
    public IGameState Move(Game game)
    {
        game.SetupGrid();
        return new WaitForMove();
    }
}