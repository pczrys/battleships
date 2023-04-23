using Battleships.Domain.GameGrid;
using Shouldly;

namespace Battleships.Domain.Tests;

public class ShipTests
{
    private const string ShipName = "some-name";
    private const int ShipBlocksNumber = 10;
    private readonly IShip _ship;

    public ShipTests()
    {
        _ship = new Ship(ShipName, ShipBlocksNumber);
    }

    [Fact]
    public void AddFieldPoints_AddsField()
    {
        _ship.AddGridField(new GridField(new GridCoordinates(1, 1)));

        _ship.GridFields.ShouldBeEquivalentTo(
            new List<GridField> { new(new GridCoordinates(1, 1)) });
    }

    [Theory]
    [MemberData(nameof(HasSunkFieldsData))]
    public void HasSunk_WhenFieldsStateSet_ReturnsCorrectValue(
        IEnumerable<GridField> fields, bool expected)
    {
        foreach (var field in fields)
        {
            _ship.AddGridField(field);
        }

        _ship.HasSunk().ShouldBe(expected);
    }

    [Fact]
    public void Hit_WhenAnyFieldsIntact_UpdatesHitField()
    {
        var hitField = new GridField(new GridCoordinates(1, 2));

        _ship.AddGridField(new GridField(new GridCoordinates(1, 1)));
        _ship.AddGridField(hitField);

        _ship.Hit(hitField);

        _ship.GridFields.ShouldBeEquivalentTo(
            new List<GridField>
            {
                new(new GridCoordinates(1, 1)),
                new(new GridCoordinates(1, 2)) { State = GridFieldState.Hit }
            });
    }

    [Fact]
    public void Hit_WhenNoFieldsIntact_UpdatesFieldsToSunk()
    {
        var hitField = new GridField(new GridCoordinates(1, 2));

        _ship.AddGridField(new GridField(new GridCoordinates(1, 1)) { State = GridFieldState.Hit });
        _ship.AddGridField(hitField);

        _ship.Hit(hitField);

        _ship.GridFields.ShouldBeEquivalentTo(
            new List<GridField> {
                new(new GridCoordinates(1, 1)) {State = GridFieldState.Sunk},
                new(new GridCoordinates(1, 2)) { State = GridFieldState.Sunk } });
    }

    [Fact]
    public void ToString_ReturnsShipName()
    {
        _ship.ToString().ShouldBe(ShipName);
    }

    [Fact]
    public void BlocksNumber_ReturnsShipBlocksNumber()
    {
        _ship.BlocksNumber.ShouldBe(ShipBlocksNumber);
    }

    public static IEnumerable<object[]> HasSunkFieldsData()
    {
        yield return new object[]
        {
            new GridField[]
            {
                new(new GridCoordinates(1, 1)) { State = GridFieldState.Sunk },
                new(new GridCoordinates(2, 1)) { State = GridFieldState.Sunk },
                new(new GridCoordinates(3, 1)) { State = GridFieldState.Sunk }
            },
            true
        };
        yield return new object[]
        {
            new GridField[]
            {
                new(new GridCoordinates(1, 1)) { State = GridFieldState.Hit },
                new(new GridCoordinates(1, 2)) { State = GridFieldState.Intact }
            },
            false
        };
        yield return new object[]
        {
            new GridField[]
            {
                new(new GridCoordinates(1, 1)) { State = GridFieldState.Intact },
                new(new GridCoordinates(1, 2)) { State = GridFieldState.Intact }
            },
            false
        };
    }
}