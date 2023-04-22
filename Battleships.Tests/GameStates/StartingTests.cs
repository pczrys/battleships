using Battleships.Domain;
using Battleships.Domain.GameGrid;
using Battleships.Game;
using Battleships.GameStates;
using Shouldly;
using GameModel = Battleships.Domain.Game;

namespace Battleships.Tests.GameStates;

public class StartingTests
{
    [Fact]
    public void Move_SetsNewGameInContext()
    {
        var oldGame = new GameModel(
            new Grid(1, new RandomGenerator()),
            new List<IShip>());

        var context = new GameContext
        {
            Game = oldGame
        };

        new Starting().Move(context);

        context.Game.ShouldNotBeSameAs(oldGame);
    }

    [Fact]
    public void Move_ReturnsWaitForMove()
    {
        var context = new GameContext();

        var result = new Starting().Move(context);

        result.ShouldBeOfType<WaitForMove>();
    }
}