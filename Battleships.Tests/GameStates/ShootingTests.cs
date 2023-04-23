using Battleships.Domain;
using Battleships.Domain.GameGrid;
using Battleships.Domain.ShotResults;
using Battleships.Game;
using Battleships.GameStates;
using Battleships.UserInterface;
using Moq;
using Shouldly;
using System.Data.Common;

namespace Battleships.Tests.GameStates;

public class ShootingTests
{
    private readonly GameContext _gameContext;
    private readonly Mock<IGame> _game;

    public ShootingTests()
    {
        _game = new Mock<IGame>();
        _gameContext = new GameContext
        {
            Game = _game.Object,
            Output = new Mock<IGameOutput>().Object
        };
    }

    [Fact]
    public void Move_WhenInvalidCoordinatesShot_ReturnsInvalidCoordinates()
    {
        const char column = 'Y';
        const int row = 110;
        _game.Setup(g => g.Shoot(new Coordinates(column, row))).Returns(new InvalidCoordinatesResult());

        new Shooting(new Coordinates(column, row)).Move(_gameContext)
            .ShouldBeOfType<InvalidCoordinates>();
    }

    [Fact]
    public void Move_WhenGameFinished_ReturnsFinished()
    {
        _game.Setup(g => g.Shoot(It.IsAny<Coordinates>()))
            .Returns(new HitResult(Mock.Of<IShip>()));
        _game.Setup(g => g.IsFinished).Returns(true);

        new Shooting(new Coordinates('Y', 110)).Move(_gameContext)
            .ShouldBeOfType<Finished>();
    }

    [Fact]
    public void Move_WhenGameHasNotFinished_ReturnsWaitForMove()
    {
        _game.Setup(g => g.Shoot(It.IsAny<Coordinates>()))
            .Returns(new MissResult());
        _game.Setup(g => g.IsFinished).Returns(false);

        new Shooting(new Coordinates('I', 10)).Move(_gameContext)
            .ShouldBeOfType<WaitForMove>();
    }
}