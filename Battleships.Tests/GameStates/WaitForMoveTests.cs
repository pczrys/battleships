using Battleships.Domain;
using Battleships.Domain.GameGrid;
using Battleships.Game;
using Battleships.GameStates;
using Battleships.UserInterface;
using Moq;
using Shouldly;
using GameModel = Battleships.Domain.Game;

namespace Battleships.Tests.GameStates;

public class WaitForMoveTests
{
    private readonly Mock<IGameInput> _input;
    private readonly GameContext _gameContext;

    public WaitForMoveTests()
    {
        _input = new Mock<IGameInput>();
        _gameContext = new GameContext
        {
            Output = new Mock<IGameOutput>().Object,
            Input = _input.Object,
            Game = new GameModel(new Grid(1, new RandomGenerator()), new List<IShip>())
        };
    }

    [Fact]
    public void Move_WhenCoordinatesInvalid_ReturnsInvalidCoordinates()
    {
        _input.Setup(i => i.Read()).Returns("some-invalid-coordinates");

        var result = new WaitForMove().Move(_gameContext);

        result.ShouldBeOfType<InvalidCoordinates>();
    }

    [Fact]
    public void Move_WhenCoordinatesRetrieved_ReturnsShooting()
    {
        _input.Setup(i => i.Read()).Returns("C2");

        var result = new WaitForMove().Move(_gameContext);

        result.ShouldBeOfType<Shooting>();
    }
}