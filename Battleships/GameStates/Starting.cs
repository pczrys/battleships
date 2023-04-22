using Battleships.Domain;
using Battleships.Domain.GameGrid;
using Battleships.Game;
using GameModel = Battleships.Domain.Game;

namespace Battleships.GameStates;

internal sealed class Starting : IGameState
{
    private const int GridSize = 10;

    public IGameState Move(GameContext context)
    {
        context.Game = new GameModel(
            new Grid(GridSize, new RandomGenerator()),
            new[]
            {
                ShipFactory.Destroyer(),
                ShipFactory.Destroyer(),
                ShipFactory.Battleship()
            });

        return new WaitForMove();
    }
}