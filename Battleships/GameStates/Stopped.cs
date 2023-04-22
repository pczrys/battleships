using Battleships.Game;

namespace Battleships.GameStates;

internal sealed class Stopped : IGameState
{
    public IGameState Move(GameContext _) => this;
}