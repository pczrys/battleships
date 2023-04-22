using Battleships.Domain.GameGrid;
using Battleships.Domain.ShotResults;
using Moq;
using Shouldly;

namespace Battleships.Domain.Tests;

public class GameTests
{
    private readonly Game _game;
    private readonly Mock<IShip>[] _ships;
    private readonly Mock<IGrid> _grid;

    public GameTests()
    {
        _ships = new[] { new Mock<IShip>(), new Mock<IShip>() };
        _grid = new Mock<IGrid>();
        _grid.Setup(g => g.Size).Returns(10);
        _grid.Setup(g => g.Ships).Returns(_ships.Select(s => s.Object));
        _game = new Game(_grid.Object, _ships.Select(s => s.Object));
    }

    [Fact]
    public void IsFinished_WhenAllShipsSunk_ReturnsTrue()
    {
        foreach (var ship in _ships)
        {
            ship.Setup(s => s.HasSunk()).Returns(true);
        }
        _game.IsFinished.ShouldBe(true);
    }

    [Fact]
    public void IsFinished_WhenNotAllShipsSunk_ReturnsFalse()
    {
        _ships.First().Setup(s => s.HasSunk()).Returns(true);
        _game.IsFinished.ShouldBe(false);
    }

    [Fact]
    public void Shoot_WhenHit_ReturnsHitResult()
    {
        var ship = new Ship("some-name", 1);
        _grid.Setup(g => g.SetShot(It.IsAny<GridField>()))
            .Returns(new GridField(1, 1)
        {
            State = GridFieldState.Hit,
            Ship = ship
        });

        var result = _game.Shoot('A', 1);
        result.ShouldBeOfType<HitResult>()
            .Ship.ShouldBe(ship);
    }

    [Fact]
    public void Shoot_WhenMissed_ReturnsMissedResult()
    {
        _grid.Setup(g => g.SetShot(It.IsAny<GridField>()))
            .Returns(new GridField(1, 10)
            {
                State = GridFieldState.Missed,
            });

        var result = _game.Shoot('A', 10);
        result.ShouldBeOfType<MissResult>();
    }

    [Fact]
    public void Shoot_WhenSunk_ReturnsSunkResult()
    {
        var ship = new Ship("some-name", 2);
        _grid.Setup(g => g.SetShot(It.IsAny<GridField>()))
            .Returns(new GridField(2, 2)
            {
                State = GridFieldState.Sunk,
                Ship = ship
            });

        var result = _game.Shoot('B', 2);
        result.ShouldBeOfType<SunkResult>()
            .Ship.ShouldBe(ship);
    }

    [Theory]
    [InlineData('K', 1)]
    [InlineData('A', 11)]
    [InlineData('@', 1)]
    [InlineData('C', 0)]
    public void Shoot_WhenCoordinatesInvalid_ReturnsInvalidCoordinatesResult(char column, int row)
    {
        var result = _game.Shoot(column, row);
        result.ShouldBeOfType<InvalidCoordinatesResult>();
    }
}