namespace Battleships.Domain.States;

internal sealed class Stopped : IGameState
{
    public IGameState Move(Game game) => this;
}