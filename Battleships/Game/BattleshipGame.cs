using Battleships.GameStates;
using Battleships.UserInterface;

namespace Battleships.Game;

internal sealed class BattleshipGame
{
    private IGameState _gameState;
    private readonly GameContext _gameContext;

    public bool IsStopped { get; private set; }

    public BattleshipGame()
    {
        var gameConsole = new GameConsole();
        _gameContext = new GameContext
        {
            Input = gameConsole,
            Output = gameConsole
        };
        _gameState = new Starting();
    }

    public void Move()
    {
        _gameState = _gameState.Move(_gameContext);

        if (_gameState is Stopped)
            IsStopped = true;
    }
}