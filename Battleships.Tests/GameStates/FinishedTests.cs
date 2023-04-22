using Battleships.Domain;
using Battleships.Game;
using Battleships.GameStates;
using Battleships.UserInterface;
using Moq;
using Shouldly;

namespace Battleships.Tests.GameStates;

public class FinishedTests
{
    private readonly GameContext _gameContext;
    private readonly Mock<IGameInput> _input;

    public FinishedTests()
    {
        _input = new Mock<IGameInput>();
        _gameContext = new GameContext
        {
            Output = new Mock<IGameOutput>().Object,
            Input = _input.Object,
            Game = new Mock<IGame>().Object
        };
    }

    [Fact]
    public void Move_WhenPlayAgainPicked_ReturnsStarting()
    {
        _input.Setup(i => i.Read()).Returns("Y");

        new Finished().Move(_gameContext)
            .ShouldBeOfType<Starting>();
    }

    [Fact]
    public void Move_WhenExitPicked_ReturnsStopped()
    {
        _input.Setup(i => i.Read()).Returns("N");

        new Finished().Move(_gameContext)
            .ShouldBeOfType<Stopped>();
    }
}