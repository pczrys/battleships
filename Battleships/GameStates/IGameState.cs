using Battleships.Game;

namespace Battleships.GameStates;

internal interface IGameState
{
    IGameState Move(GameContext context);
}