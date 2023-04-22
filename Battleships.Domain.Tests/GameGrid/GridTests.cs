using Battleships.Domain.GameGrid;
using Moq;
using Shouldly;

namespace Battleships.Domain.Tests.GameGrid;

public class GridTests
{
    private readonly IGrid _grid;
    private readonly Mock<IRandom> _random;

    public GridTests()
    {
        _random = new Mock<IRandom>();
        _grid = new Grid(5, _random.Object);
    }

    [Fact]
    public void SetShip_SetsShipAtPosition()
    {
        _random.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int min, int _) => min);

        var ship = new Ship("some-name", 2);
        _grid.SetShip(ship);

        _grid.Ships.ShouldContain(ship);
        _grid.Fields.Cast<GridField>()
            .Where(gf => gf.Ship == ship)
            .ToArray().ShouldBeEquivalentTo(
                new[]
                {
                    new GridField(1, 1) { Ship = ship },
                    new GridField(2, 1) { Ship = ship }
                });
    }

    [Fact]
    public void SetShot_WhenNoShipAtField_ChangesStateToMissed()
    {
        _grid.SetShot(new GridField(1, 5))
            .State.ShouldBe(GridFieldState.Missed);
    }

    [Fact]
    public void SetShot_WhenShipAtField_HitsShip()
    {
        _random.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int _, int max) => max - 1);

        var ship = new Mock<IShip>();
        ship.Setup(s => s.BlocksNumber).Returns(1);
        _grid.SetShip(ship.Object);

        _grid.SetShot(new GridField(5, 5));

        ship.Verify(s => s.Hit(
                It.Is<GridField>(
                    f => f.Column == 4 && f.Row == 4)),
            Times.Once);
    }
}