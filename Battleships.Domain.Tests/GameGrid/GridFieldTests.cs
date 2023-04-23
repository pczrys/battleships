using Battleships.Domain.GameGrid;
using Shouldly;

namespace Battleships.Domain.Tests.GameGrid;

public class GridFieldTests
{
    [Fact]
    public void ShipSetter_AddsGridFieldToShip()
    {
        var ship = new Ship("some-name", 4);

        var gridField = new GridField(new Coordinates('K', 10))
        {
            Ship = ship
        };

        ship.GridFields.ShouldContain(gridField);
    }

    [Fact]
    public void IsEmpty_WhenShipSet_ReturnsTrue()
    {
        var gridField = new GridField(new Coordinates('K', 10))
        {
            Ship = new Ship("some-name", 4)
        };

        gridField.IsEmpty.ShouldBeFalse();
    }

    [Fact]
    public void IsEmpty_WhenShipNotSet_ReturnsFalse()
    {
        var gridField = new GridField(new Coordinates('K', 10));

        gridField.IsEmpty.ShouldBeTrue();
    }

    [Theory]
    [InlineData(GridFieldState.Hit, true)]
    [InlineData(GridFieldState.Missed, false)]
    public void IsHit_WhenStateHit_ReturnsCorrectValue(
        GridFieldState state, bool expected)
    {
        var gridField = new GridField(new Coordinates('A', 2))
        {
            State = state
        };

        gridField.IsHit.ShouldBe(expected);
    }

    [Theory]
    [InlineData(GridFieldState.Hit, false)]
    [InlineData(GridFieldState.Missed, true)]
    public void IsHit_WhenStateMissed_ReturnsCorrectValue(
        GridFieldState state, bool expected)
    {
        var gridField = new GridField(new Coordinates('J', 10))
        {
            State = state
        };

        gridField.IsMissed.ShouldBe(expected);
    }

    [Theory]
    [InlineData(GridFieldState.Intact, false)]
    [InlineData(GridFieldState.Sunk, true)]
    public void IsHit_WhenStateSunk_ReturnsCorrectValue(
        GridFieldState state, bool expected)
    {
        var gridField = new GridField(new Coordinates('J', 2))
        {
            State = state
        };

        gridField.IsSunk.ShouldBe(expected);
    }

    [Theory]
    [InlineData(GridFieldState.Intact, true)]
    [InlineData(GridFieldState.Sunk, false)]
    public void IsHit_WhenStateIntact_ReturnsCorrectValue(
        GridFieldState state, bool expected)
    {
        var gridField = new GridField(new Coordinates('F', 4))
        {
            State = state
        };

        gridField.IsIntact.ShouldBe(expected);
    }
}