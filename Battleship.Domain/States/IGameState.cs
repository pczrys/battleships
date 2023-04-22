namespace Battleships.Domain.States;

public interface IGameState
{
    IGameState Move(Game game);
}